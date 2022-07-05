using DSR_Summer_Practice.DAL.Entities;

namespace DSR_Summer_Practice.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Currency> Currencies { get; }
        IRepository<ExchangeRate> ExchangeRates { get; }
        void Save();
    }
}
