﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DSR_Summer_Practice.Shared.Entieties
{
	//https://www.cbr.ru/scripts/XML_daily.asp?date_req=02/03/2000
	[XmlRoot(ElementName = "Valute")]
	public class Valute
	{
		[XmlElement(ElementName = "NumCode")]
		public int NumCode { get; set; }

		[XmlElement(ElementName = "CharCode")]
		public string CharCode { get; set; }

		[XmlElement(ElementName = "Nominal")]
		public int Nominal { get; set; }

		[XmlElement(ElementName = "Name")]
		public string Name { get; set; }

		[XmlElement(ElementName = "Value")]
		public double Value { get; set; }

		[XmlAttribute(AttributeName = "ID")]
		public string ID { get; set; }

		[XmlText]
		public string Text { get; set; }
	}
}