using CollectionOfValueObjects.Model;
using CollectionOfValueObjects.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace CollectionOfValueObjects.Persistence
{
    public class ShopDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EFCore-DDD_04_CollectionOfValueObjects;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderMapping).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}