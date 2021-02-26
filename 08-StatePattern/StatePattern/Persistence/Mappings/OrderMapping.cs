using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StatePattern.Model;

namespace StatePattern.Persistence.Mappings
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders").HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedNever();
            builder.Property(a => a.CustomerId);
            builder.Property(a => a.IssueDate);

            builder.Property(a => a.State).HasConversion(new OrderStateValueConverter());
        }
    }
}