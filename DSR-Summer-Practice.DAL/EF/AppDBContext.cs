using DSR_Summer_Practice.DAL.Entities;
using System.Data.Entity;

namespace DSR_Summer_Practice.DAL.EF
{
    public class AppDBContext : DbContext
    {
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
        static AppDBContext() => Database.SetInitializer<AppDBContext>(new DbInitializer());
        public AppDBContext(string connectionString)
            : base(connectionString)
        {
        }
    }
}
