using DSR_Summer_Practice.DAL.Entities;
using DSR_Summer_Practice.Shared.Repositories;
using DSR_Summer_Practice.Shared.Services;
using DSR_Summer_Practice.Shared.Entieties;
using System.Data.Entity;

namespace DSR_Summer_Practice.DAL.EF
{
    public class AppDBContext : DbContext
    {
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
        static AppDBContext() => Database.SetInitializer<AppDBContext>(new DbInitializer(new ValCursRepository(new ValCursDeserializerXML())));
        public AppDBContext(string connectionString)
            : base(connectionString)
        {
        }
    }
}
