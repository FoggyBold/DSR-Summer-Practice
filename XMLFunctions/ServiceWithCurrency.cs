using DSR_Summer_Practice.Interfaces;
using DSR_Summer_Practice.Data.Models;
using System.Xml;

namespace DSR_Summer_Practice.XMLFunctions
{
    public class ServiceWithCurrency : IServiceWithCurrency
    {
        public IEnumerable<string> GetCurrencyNames(String URLString)
        {
            var res = new List<string>();
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(URLString);
            XmlNodeList nodeList = xdoc.DocumentElement.SelectNodes("Valute");
            foreach (XmlNode node in nodeList)
            {
                res.Add(node.ChildNodes[3].ChildNodes[0].Value);
            }
            return res;
        }
        public IEnumerable<ExchangeRate> GetInformationAboutExchangeRate(DateTime first, DateTime second, string currency)
        {
            return null;
        }
    }
}
