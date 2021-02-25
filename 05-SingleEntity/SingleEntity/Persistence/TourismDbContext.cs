using Microsoft.EntityFrameworkCore;
using SingleEntity.Model;
using SingleEntity.Persistence.Mappings;

namespace SingleEntity.Persistence
{
    public class TourismDbContext : DbContext
    {
        public DbSet<Passenger> Passengers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EFCore-DDD;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PassengerMapping).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}