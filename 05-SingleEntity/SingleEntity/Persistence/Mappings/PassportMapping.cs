using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SingleEntity.Model;

namespace SingleEntity.Persistence.Mappings
{
    public class PassportMapping : IEntityTypeConfiguration<Passport>
    {
        public void Configure(EntityTypeBuilder<Passport> builder)
        {
            builder.ToTable("Passports").HasKey(a => a.Id);
            builder.Property(a => a.Number).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Country).HasMaxLength(50).IsRequired();
            builder.Property(a => a.ExpireDate).IsRequired();
        }
    }
}