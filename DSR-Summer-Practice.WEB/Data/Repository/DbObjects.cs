using DSR_Summer_Practice.WEB.Data.Models;
using System.Xml;
using DSR_Summer_Practice.WEB.Interfaces;

namespace DSR_Summer_Practice.WEB.Data.Repository
{
    public class DbObjects
    {
        private IXMLService serviceWithCurrency;
        public DbObjects(IXMLService serviceWithCurrency)
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
