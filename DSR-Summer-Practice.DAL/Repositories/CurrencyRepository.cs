using DSR_Summer_Practice.DAL.Interfaces;
using DSR_Summer_Practice.DAL.Entities;
using DSR_Summer_Practice.DAL.EF;
using System.Data.Entity;

namespace DSR_Summer_Practice.DAL.Repositories
{
    public class CurrencyRepository : IRepository<Currency>
    {
        private AppDBContext dbContext;
        public CurrencyRepository(AppDBContext appDBContext)
        {
            dbContext = appDBContext;
        }
        public void Create(Currency item)
        {
            dbContext.Currencies.Add(item);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Currency currency = dbContext.Currencies.Find(id);
            if(currency != null)
            {
                dbContext.Currencies.Remove(currency);
                dbContext.SaveChanges();
            }
        }

        public IEnumerable<Currency> Find(Func<Currency, bool> predicate)
        {
            return dbContext.Currencies.Where(predicate).ToList();
        }

        public Currency Get(int id)
        {
            return dbContext.Currencies.Find(id);
        }

        public IEnumerable<Currency> GetAll()
        {
            return dbContext.Currencies;
        }

        public void Update(Currency item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
