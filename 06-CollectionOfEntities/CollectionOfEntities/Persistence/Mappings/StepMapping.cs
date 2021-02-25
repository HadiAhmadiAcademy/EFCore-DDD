using CollectionOfEntities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CollectionOfEntities.Persistence.Mappings
{
    public class StepMapping : IEntityTypeConfiguration<Step>
    {
        public void Configure(EntityTypeBuilder<Step> builder)
        {
            builder.ToTable("DecisionHierarchySteps").HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedNever();
            builder.Property(a => a.Title);
            builder.Property(a => a.IsRequired);
            builder.Property(a => a.Level).HasColumnName("OrganizationLevel");
        }
    }
}