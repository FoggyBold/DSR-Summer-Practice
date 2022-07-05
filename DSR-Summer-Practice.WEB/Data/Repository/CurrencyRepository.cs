using DSR_Summer_Practice.WEB.Data.Models;
using DSR_Summer_Practice.WEB.Interfaces;

namespace DSR_Summer_Practice.WEB.Data.Repository
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly AppDBContent content;
        private readonly IXMLService serviceWithCurrency;

        public CurrencyRepository(IXMLService serviceWithCurrency, AppDBContent appDBContent)
        {
            this.serviceWithCurrency = serviceWithCurrency;
            this.content = appDBContent;
        }

        public DataForDrawingFromDb getExchangeRate(int ID, int numberOfDays)
        {
            return findInDb(ID, numberOfDays);
        }

        private void addMissingDays(ref List<ExchangeRate> list, string currency, int numberOfDays)
        {
            DateTime startDate;
            DateTime endDate; 

            if (list != null)
            {
                startDate = list[list.Count - 1].DateTime;
                endDate = DateTime.Now;
            }
            else
            {
                startDate = DateTime.Now.AddDays(numberOfDays * (-1));
                endDate = DateTime.Now;
            }
            list.AddRange(serviceWithCurrency.GetInformationAboutExchangeRate(startDate, endDate, currency));

            if(list.Count != numberOfDays)
            {
                endDate = list[0].DateTime;
                startDate = endDate.AddDays((numberOfDays - list.Count) * (-1));
                list.AddRange(serviceWithCurrency.GetInformationAboutExchangeRate(startDate, endDate, currency));
            }
        }

        private DataForDrawingFromDb findInDb(int ID, int numberOfDays)
        {
            var date = DateTime.Now.AddDays(numberOfDays * (-1));
            var samplingFromDb = content.ExchangeRates.Where(el => el.ID == ID && el.DateTime > date).ToList();
            var nameCurrency = content.Currencies.First(el => el.ID == ID).Name;

            samplingFromDb.Sort((a, b) =>
            {
                return a.DateTime.CompareTo(b.DateTime);
            });

            if (samplingFromDb.Count() != numberOfDays)
            {
                addMissingDays(ref samplingFromDb, nameCurrency, numberOfDays);
            }

            return new(samplingFromDb, nameCurrency);
        }

        public IEnumerable<Currency> getAllNames()
        {
            return content.Currencies.ToList();
        }
    }
}
