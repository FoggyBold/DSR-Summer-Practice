using DSR_Summer_Practice.Data.Models;

namespace DSR_Summer_Practice.Interfaces
{
    public interface ICurrencyRepository
    {
        DataForDrawingFromDb getExchangeRate(int ID, int numberOfDays);
        IEnumerable<Currency> getAllNames();
    }
}
