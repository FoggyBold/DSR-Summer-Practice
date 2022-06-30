namespace DSR_Summer_Practice.Interfaces
{
    public interface IServiceWithCurrency
    {
        IEnumerable<string> GetCurrencyNames(String URLString);
    }
}
