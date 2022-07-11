using DSR_Summer_Practice.DAL.Interfaces;
using DSR_Summer_Practice.DAL.Entities;
using DSR_Summer_Practice.DAL.EF;
using System.Data.Entity;

namespace DSR_Summer_Practice.DAL.Repositories
{
    public class ExchangeRateRepository : IRepository<ExchangeRate>
    {
        private AppDBContext dbContext;
        public ExchangeRateRepository(AppDBContext appDBContext)
        {
            dbContext = appDBContext;
        }
        public void Create(ExchangeRate item)
        {
            dbContext.ExchangeRates.Add(item);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            ExchangeRate exchangeRate = dbContext.ExchangeRates.Find(id);
            if (exchangeRate != null)
            {
                dbContext.ExchangeRates.Remove(exchangeRate);
                dbContext.SaveChanges();
            }
        }

        public IEnumerable<ExchangeRate> Find(Func<ExchangeRate, bool> predicate)
        {
            return dbContext.ExchangeRates.Where(predicate).ToList();
        }

        public ExchangeRate Get(int id)
        {
            return dbContext.ExchangeRates.Find(id);
        }

        public IEnumerable<ExchangeRate> GetAll()
        {
            return dbContext.ExchangeRates;
        }

        public void Update(ExchangeRate item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
