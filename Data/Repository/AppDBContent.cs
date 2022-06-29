using DSR_Summer_Practice.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DSR_Summer_Practice.Data.Repository
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options)
                : base(options)
        {
        }
        public DbSet<Currency>? Currencies { get; set; }
        public DbSet<ExchangeRate>? ExchangeRates { get; set; }
    }
}
