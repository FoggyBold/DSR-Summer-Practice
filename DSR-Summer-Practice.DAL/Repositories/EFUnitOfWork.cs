using DSR_Summer_Practice.DAL.Interfaces;
using DSR_Summer_Practice.DAL.Entities;
using DSR_Summer_Practice.DAL.EF;
using System.Data.Entity;

namespace DSR_Summer_Practice.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private AppDBContext dbContext;
        private CurrencyRepository currencyRepository;
        private ExchangeRateRepository exchangeRateRepository;
        public IRepository<Currency> Currencies
        {
            get
            {
                if(currencyRepository == null)
                {
                    currencyRepository = new(dbContext);
                }
                return currencyRepository;
            }
        }

        public IRepository<ExchangeRate> ExchangeRates
        {
            get
            {
                if (exchangeRateRepository == null)
                {
                    exchangeRateRepository = new(dbContext);
                }
                return exchangeRateRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
