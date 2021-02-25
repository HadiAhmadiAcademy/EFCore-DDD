using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SingleEntity.Model;

namespace SingleEntity.Persistence.Mappings
{
    public class PassengerMapping : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.ToTable("Passengers").HasKey(a=> a.Id);
            builder.Property(a => a.Id).ValueGeneratedNever();
            builder.Property(a => a.Firstname).IsRequired();
            builder.Property(a => a.Lastname).IsRequired();

            builder.HasOne(a => a.Passport)
                .WithOne()
                .IsRequired(false)
                .HasForeignKey<Passport>("PassengerId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}