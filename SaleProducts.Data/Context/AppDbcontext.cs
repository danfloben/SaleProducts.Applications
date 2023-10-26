using SaleProducts.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AgencyApp.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Sale> Sales { get; set; }

    }
}
