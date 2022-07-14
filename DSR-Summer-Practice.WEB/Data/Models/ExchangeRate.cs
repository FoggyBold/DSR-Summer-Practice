namespace DSR_Summer_Practice.WEB.Data.Models
{
    //The value at a certain point in time
    public class ExchangeRate
    {
        public string CurrencyName { get; set; }
        public DateTime DateTime { get; set; }
        public double Value { get; set; }

    }
}
