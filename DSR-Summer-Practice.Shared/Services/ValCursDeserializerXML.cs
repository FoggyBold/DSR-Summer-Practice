using DSR_Summer_Practice.Shared.Entieties;
using DSR_Summer_Practice.Shared.Interfaces;
using System.Net;
using System.Xml.Serialization;

namespace DSR_Summer_Practice.Shared.Services
{
    public class ValCursDeserializerXML : IDeserializerXML<ValCurs>
    {
        /// <summary>
        /// Downloads an xml file by URL and deserializes it
        /// </summary>
        /// <param name="url">file url</param>
        /// <returns>ValCurs</returns>
        public ValCurs deserialize(string url)
        {
            string xml;
            using (var webClient = new WebClient())
            {
                xml = webClient.DownloadString(url);
            }
            XmlSerializer serializer = new XmlSerializer(typeof(ValCurs));
            ValCurs res;
            using (StringReader reader = new StringReader(xml))
            {
                res = (ValCurs)serializer.Deserialize(reader);
            }
            return res;
        }
    }
}
