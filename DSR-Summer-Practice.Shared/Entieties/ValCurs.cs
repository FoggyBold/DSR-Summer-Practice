using System.Xml.Serialization;

namespace DSR_Summer_Practice.Shared.Entieties
{
    [XmlRoot(ElementName = "ValCurs")]
	public class ValCurs
	{
		[XmlElement(ElementName = "Valute")]
		public IEnumerable<Valute> Valute { get; set; }

		[XmlAttribute(AttributeName = "Date")]
		public DateTime Date { get; set; }

		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }

		[XmlText]
		public string Text { get; set; }
	}
}
