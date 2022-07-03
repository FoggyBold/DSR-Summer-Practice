using DSR_Summer_Practice.Data.Models;

namespace DSR_Summer_Practice.Interfaces
{
    public interface ICurrencyInformation
    {
        DataForDrawingFromDb get(int ID, int numberOfDays);
        void addMissingDays(ref List<ExchangeRate> list, string currency, int numberOfDays);
        DataForDrawingFromDb findInDb(int ID, int numberOfDays);
    }
}
