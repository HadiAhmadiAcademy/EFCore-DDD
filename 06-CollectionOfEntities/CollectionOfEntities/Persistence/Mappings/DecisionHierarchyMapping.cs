using CollectionOfEntities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CollectionOfEntities.Persistence.Mappings
{
    public class DecisionHierarchyMapping : IEntityTypeConfiguration<DecisionHierarchy>
    {
        public void Configure(EntityTypeBuilder<DecisionHierarchy> builder)
        {
            builder.ToTable("DecisionHierarchies").HasKey(a=> a.Id);
            builder.Property(a => a.Id).ValueGeneratedNever();
            builder.Property(a => a.LoanType);
            builder.HasMany(a => a.Steps)
                .WithOne()
                .IsRequired()
                .HasForeignKey("DecisionHierarchyId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}