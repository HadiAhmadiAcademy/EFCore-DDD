using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersistingDomainEvents.Model;

namespace PersistingDomainEvents.Persistence.Mappings
{
    public class AuctionMapping : IEntityTypeConfiguration<Auction>
    {
        public void Configure(EntityTypeBuilder<Auction> builder)
        {
            builder.ToTable("Auctions").HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedNever();
        }
    }
}