﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SingleEntity.Persistence;

namespace SingleEntity.Persistence.Migrations
{
    [DbContext(typeof(TourismDbContext))]
    [Migration("20210225233042_InitialStep")]
    partial class InitialStep
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SingleEntity.Model.Passenger", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("SingleEntity.Model.Passport", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long?>("PassengerId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PassengerId")
                        .IsUnique()
                        .HasFilter("[PassengerId] IS NOT NULL");

                    b.ToTable("Passports");
                });

            modelBuilder.Entity("SingleEntity.Model.Passport", b =>
                {
                    b.HasOne("SingleEntity.Model.Passenger", null)
                        .WithOne("Passport")
                        .HasForeignKey("SingleEntity.Model.Passport", "PassengerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SingleEntity.Model.Passenger", b =>
                {
                    b.Navigation("Passport");
                });
#pragma warning restore 612, 618
        }
    }
}
