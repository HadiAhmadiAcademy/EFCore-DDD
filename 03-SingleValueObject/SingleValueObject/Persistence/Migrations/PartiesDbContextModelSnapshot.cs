﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SingleValueObject.Persistence;

namespace SingleValueObject.Persistence.Migrations
{
    [DbContext(typeof(PartiesDbContext))]
    partial class PartiesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SingleValueObject.Model.IndividualParty", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SocialSecurityNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SSN");

                    b.HasKey("Id");

                    b.ToTable("IndividualParties");
                });

            modelBuilder.Entity("SingleValueObject.Model.IndividualParty", b =>
                {
                    b.OwnsOne("SingleValueObject.Model.Name", "Name", b1 =>
                        {
                            b1.Property<long>("IndividualPartyId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Firstname")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Firstname");

                            b1.Property<string>("Lastname")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Lastname");

                            b1.HasKey("IndividualPartyId");

                            b1.ToTable("IndividualParties");

                            b1.WithOwner()
                                .HasForeignKey("IndividualPartyId");
                        });

                    b.Navigation("Name");
                });
#pragma warning restore 612, 618
        }
    }
}
