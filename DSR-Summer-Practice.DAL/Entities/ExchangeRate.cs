using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSR_Summer_Practice.DAL.Entities
{
    /// <summary>
    /// This class defines value of the currency on a certain day
    /// </summary>
    public class ExchangeRate
    {
        public int ID { get; set; }
        public int CurrencyId { get; set; }
        public DateTime DateTime { get; set; }
        public double Value { get; set; }
    }
}
