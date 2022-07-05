using DSR_Summer_Practice.DAL.Entities;
using System.Data.Entity;
using System.Xml;

namespace DSR_Summer_Practice.DAL.EF
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<AppDBContext>
    {
        protected override void Seed(AppDBContext context)
        {
            String URLString = "http://www.cbr.ru/scripts/XML_daily.asp";
            var currencyNames = new List<string>();
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(URLString);
            XmlElement? xmlRoot = xdoc.DocumentElement;
            if (xmlRoot != null)
            {
                foreach (XmlElement xnode in xmlRoot)
                {
                    foreach (XmlNode xn in xnode.ChildNodes)
                    {
                        if (xn.Name == "Name")
                        {
                            currencyNames.Add(xn.InnerText);
                        }
                    }
                }
            }

            foreach (var currency in currencyNames)
            {
                context.Currencies.Add(new Currency
                {
                    Name = currency
                });
            }
            context.SaveChanges();
        }
    }
}
