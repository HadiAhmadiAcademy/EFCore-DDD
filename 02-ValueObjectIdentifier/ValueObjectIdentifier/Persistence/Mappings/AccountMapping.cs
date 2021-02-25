using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ValueObjectIdentifier.Model;

namespace ValueObjectIdentifier.Persistence.Mappings
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .ValueGeneratedNever()
                .HasConversion(new AccountIdValueConverter());

            builder.Property(a => a.Code);
        }
    }
}