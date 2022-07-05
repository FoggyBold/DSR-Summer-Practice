using DSR_Summer_Practice.WEB.Data.Models;

namespace DSR_Summer_Practice.WEB.Interfaces
{
    public interface ICurrencyRepository
    {
        DataForDrawingFromDb getExchangeRate(int ID, int numberOfDays);
        IEnumerable<Currency> getAllNames();
    }
}
