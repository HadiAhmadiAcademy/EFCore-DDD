using CollectionOfEntities.Model;
using CollectionOfEntities.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace CollectionOfEntities.Persistence
{
    public class LoanApplicationsDbContext : DbContext
    {
        public DbSet<DecisionHierarchy> DecisionHierarchies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EFCore-DDD;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DecisionHierarchyMapping).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}