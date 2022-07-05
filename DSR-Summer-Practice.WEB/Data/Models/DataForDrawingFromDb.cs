namespace DSR_Summer_Practice.WEB.Data.Models
{
    public class DataForDrawingFromDb
    {
        public string? Name { get; set; }
        public IEnumerable<DateTime>? Dates { get; set; }
        public IEnumerable<double>? Values { get; set; }
        public DataForDrawingFromDb(List<ExchangeRate> list, string nameCurrency)
        {
            Name = nameCurrency;
            var dates = new List<DateTime>();
            var values = new List<double>();
            foreach (var item in list)
            {
                dates.Add(item.DateTime);
                values.Add(item.Value);
            }
            Dates = dates;
            Values = values;
        }
    }
}
