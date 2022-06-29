using DSR_Summer_Practice.Data.Models;
using System.Xml;

namespace DSR_Summer_Practice.Data.Repository
{
    public class DbObjects
    {
        public static void Initial(AppDBContent content)
        {
            if (!content.Currencies.Any())
            {
                String URLString = "http://www.cbr.ru/scripts/XML_daily.asp";
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(URLString);
                XmlNodeList nodeList = xdoc.DocumentElement.SelectNodes("Valute");
                foreach (XmlNode node in nodeList)
                {
                    content.Currencies.Add(new Currency
                    {
                        Name = node.ChildNodes[3].ChildNodes[0].Value
                    });
                }
                content.SaveChanges();
            }
        }
    }
}
