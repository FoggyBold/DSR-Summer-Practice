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
                XmlTextReader reader = new XmlTextReader(URLString);
                while (reader.Read())
                {
                    if (reader.Name == "Name")
                    {
                        content.Currencies.AddRange(new Currency { Name = reader.Value });
                    }
                }
                content.SaveChanges();
            }

            content.SaveChanges();
        }
    }
}
