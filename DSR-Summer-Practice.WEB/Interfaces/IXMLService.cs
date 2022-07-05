using DSR_Summer_Practice.WEB.Data.Models;

namespace DSR_Summer_Practice.WEB.Interfaces
{
    public interface IXMLService
    {
        IEnumerable<string> GetCurrencyNames(String URLString);
        IEnumerable<ExchangeRate> GetInformationAboutExchangeRate(DateTime first, DateTime second, string currency);
    }
}
