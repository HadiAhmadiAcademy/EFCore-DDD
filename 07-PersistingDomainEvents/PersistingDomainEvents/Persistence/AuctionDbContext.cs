using System.Linq;
using Framework.Domain;
using Microsoft.EntityFrameworkCore;
using PersistingDomainEvents.Model;
using PersistingDomainEvents.Persistence.Mappings;
using PersistingDomainEvents.Persistence.Outbox;

namespace PersistingDomainEvents.Persistence
{
    public class AuctionDbContext : DbContext
    {
        public DbSet<Auction> Auction { get; set; }
        public DbSet<OutboxItem> OutboxItems { get; set; }

        public AuctionDbContext()
        {
            this.SavingChanges += OnSavingChanges;
        }
        private void OnSavingChanges(object sender, SavingChangesEventArgs e)
        {
            var aggregateRoots = this.ChangeTracker.Entries()
                .Where(a => a.State != EntityState.Unchanged)
                .Select(a=> a.Entity)
                .OfType<IAggregateRoot>()
                .ToList();
            var itemsToAddIntoOutbox = OutboxItemFactory.CreateOutboxItemsFromAggregateRoots(aggregateRoots);
            itemsToAddIntoOutbox.ForEach(a=> OutboxItems.Add(a));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EFCore-DDD_07_PersistingDomainEvents;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuctionMapping).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }

}