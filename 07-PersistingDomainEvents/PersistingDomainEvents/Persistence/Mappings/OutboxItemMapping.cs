using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersistingDomainEvents.Persistence.Outbox;

namespace PersistingDomainEvents.Persistence.Mappings
{
    public class OutboxItemMapping : IEntityTypeConfiguration<OutboxItem>
    {
        public void Configure(EntityTypeBuilder<OutboxItem> builder)
        {
            builder.ToTable("DomainEvents").HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Body);
            builder.Property(a => a.Type);
            builder.Property(a => a.EventId);
            builder.Property(a => a.PublishDateTime);
        }
    }
}