using DSR_Summer_Practice.WEB.Interfaces;
using DSR_Summer_Practice.WEB.Data.Models;
using System.Xml;
using System.Text;

namespace DSR_Summer_Practice.WEB.XMLFunctions
{
    public class XMLService : IXMLService
    {
        public IEnumerable<string> GetCurrencyNames(String URLString)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var res = new List<string>();
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(URLString);
            XmlElement? xmlRoot = xdoc.DocumentElement;
            if(xmlRoot!= null)
            {
                foreach (XmlElement xnode in xmlRoot)
                {
                    foreach(XmlNode xn in xnode.ChildNodes)
                    {
                        if(xn.Name == "Name")
                        {
                            res.Add(xn.InnerText);
                        }
                    }
                }
            }
            //foreach (XmlNode node in nodeList)
            //{
            //    foreach()
            //    res.Add(node.ChildNodes[3].ChildNodes[0].Value);
            //}
            return res;
        }
        public IEnumerable<ExchangeRate> GetInformationAboutExchangeRate(DateTime first, DateTime second, string currency)
        {
            return null;
        }
    }
}
