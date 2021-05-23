using efcore.tests.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace efcore.tests.Domain.Context
{
    public class DbTestContext : DbContext
    {
        public DbTestContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Car> Car { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<AutoStore> AutoStore { get; set; }
    }
}