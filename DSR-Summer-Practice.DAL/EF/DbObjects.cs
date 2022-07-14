using DSR_Summer_Practice.Shared.Interfaces;
using DSR_Summer_Practice.Shared.Entieties;
using DSR_Summer_Practice.DAL.Entities;

namespace DSR_Summer_Practice.DAL.EF
{
    public class DbObjects
    {
        private IRepository<ValCurs> repository;
        public DbObjects(IRepository<ValCurs> repository)
        {
            this.repository = repository;
        }
        public void Initial(AppDBContext context)
        {
            if (context.Currencies == null)
            {
                var currencies = repository.get();
                foreach (var currency in currencies.Valute)
                {
                    context.Currencies.Add(new Currency
                    {
                        Name = currency.Name
                    });
                }
                context.SaveChanges();
            }
        }
    }
}
