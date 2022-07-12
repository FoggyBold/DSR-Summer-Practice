using DSR_Summer_Practice.DAL.Entities;
using DSR_Summer_Practice.Shared.Repositories;
using DSR_Summer_Practice.Shared.Services;
using DSR_Summer_Practice.Shared.Entieties;
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
