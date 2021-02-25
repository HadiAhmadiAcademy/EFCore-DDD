using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SingleValueObject.Model;

namespace SingleValueObject.Persistence.Mappings
{
    public class IndividualPartyMapping : IEntityTypeConfiguration<IndividualParty>
    {
        public void Configure(EntityTypeBuilder<IndividualParty> builder)
        {
            builder.ToTable("IndividualParties").HasKey(a => a.Id);
            builder.Property(a => a.SocialSecurityNumber).HasColumnName("SSN");
            builder.OwnsOne(a => a.Name).Property(p => p.Firstname).HasColumnName("Firstname");
            builder.OwnsOne(a => a.Name).Property(p => p.Lastname).HasColumnName("Lastname");
        }
    }
}