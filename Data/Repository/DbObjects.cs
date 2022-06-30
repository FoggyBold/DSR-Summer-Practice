using DSR_Summer_Practice.Data.Models;
using System.Xml;
using DSR_Summer_Practice.Interfaces;

namespace DSR_Summer_Practice.Data.Repository
{
    public class DbObjects
    {
        private IServiceWithCurrency serviceWithCurrency;
        public DbObjects(IServiceWithCurrency serviceWithCurrency)
        {
            this.serviceWithCurrency = serviceWithCurrency;
        }

        public void Initial(AppDBContent content)
        {
            if (!content.Currencies.Any())
            {
                String URLString = "http://www.cbr.ru/scripts/XML_daily.asp";
                var currencyNames = serviceWithCurrency.GetCurrencyNames(URLString);
                foreach (var currency in currencyNames)
                {
                    content.Currencies.Add(new Currency
                    {
                        Name = currency
                    });
                }
                content.SaveChanges();
            }
        }
    }
}
