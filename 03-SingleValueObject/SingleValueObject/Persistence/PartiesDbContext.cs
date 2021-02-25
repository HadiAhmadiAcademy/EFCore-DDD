using Microsoft.EntityFrameworkCore;
using SingleValueObject.Model;
using SingleValueObject.Persistence.Mappings;

namespace SingleValueObject.Persistence
{
    public class PartiesDbContext : DbContext
    {
        public DbSet<IndividualParty> IndividualParties { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EFCore-DDD;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IndividualPartyMapping).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}