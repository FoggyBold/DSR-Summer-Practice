using DSR_Summer_Practice.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DSR_Summer_Practice.DAL.EF
{
    public class AppDBContext : DbContext
    {
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }
    }
}
