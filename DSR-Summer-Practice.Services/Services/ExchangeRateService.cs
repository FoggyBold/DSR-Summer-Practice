using DSR_Summer_Practice.Services.DataTransferObject;
using DSR_Summer_Practice.Services.Interfaces;
using DSR_Summer_Practice.DAL.Interfaces;
using DSR_Summer_Practice.Shared.Entieties;
using DSR_Summer_Practice.Shared.Repositories;
using DSR_Summer_Practice.Shared.Services;

namespace DSR_Summer_Practice.Services.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        private IUnitOfWork database;
        private Shared.Interfaces.IRepository<ValCurs> valCursRepository;
        public ExchangeRateService(IUnitOfWork datebase)
        {
            database = datebase;
            this.valCursRepository = new ValCursRepository(new ValCursDeserializerXML());
        }

        public IEnumerable<Currency> GetCurrencies()
        {
            List<Currency> res = new List<Currency>();
            var currencies = database.Currencies.GetAll();
            foreach (var cur in currencies)
            {
                res.Add(new Currency {
                    ID = cur.ID,
                    Name = cur.Name
                });
            }
            return res;
        }

        public IEnumerable<ExchangeRate> GetExchangeRates(int id, DateTime start, DateTime end)
        {
            List<ExchangeRate> rates = new List<ExchangeRate>();
            var currency = database.Currencies.Get(id);
            var exchangeRate = database.ExchangeRates.Find(el => el.CurrencyId == id && el.DateTime >= start && el.DateTime <= end);
            
            if(exchangeRate == null || exchangeRate.Count() < (end - start).TotalDays)
            {
                var newDays = valCursRepository.find(start, end);
                foreach(var day in newDays)
                {
                    var temp = new DSR_Summer_Practice.DAL.Entities.ExchangeRate {
                        CurrencyId = id,
                        DateTime = Convert.ToDateTime(day.Date),
                        Value = Convert.ToDouble(day.Valute.First(el => el.Name == currency.Name).Value)
                    };
                    if (exchangeRate == null || exchangeRate.FirstOrDefault(el => el.CurrencyId == id && el.Value == temp.Value && el.DateTime == temp.DateTime) == null)
                    {
                        database.ExchangeRates.Create(temp);
                    }
                }
            }

            exchangeRate = database.ExchangeRates.Find(el => el.CurrencyId == id && el.DateTime >= start && el.DateTime <= end);
            foreach(var rate in exchangeRate)
            {
                rates.Add(new ExchangeRate
                {
                    CurrencyName = currency.Name,
                    Value = rate.Value,
                    DateTime = rate.DateTime
                });
            }
            return rates;
        }
    }
}
