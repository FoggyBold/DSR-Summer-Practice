namespace DSR_Summer_Practice.Data.Models
{
    //The value at a certain point in time
    public class ExchangeRate
    {
        public int ID { get; set; }
        public int CurrencyId { get; set; }
        public DateTime DateTime { get; set; }
        public double Value { get; set; }

    }
}
