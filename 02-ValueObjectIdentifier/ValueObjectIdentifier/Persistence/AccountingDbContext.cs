using Microsoft.EntityFrameworkCore;
using ValueObjectIdentifier.Model;
using ValueObjectIdentifier.Persistence.Mappings;

namespace ValueObjectIdentifier.Persistence
{
    public class AccountingDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EFCore-DDD_02_ValueObjectIdentifier;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccountMapping).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}