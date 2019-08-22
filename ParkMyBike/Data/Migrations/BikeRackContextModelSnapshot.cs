﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkMyBike.Data;

namespace ParkMyBike.Migrations
{
    [DbContext(typeof(BikeRackContext))]
    partial class BikeRackContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ParkMyBike.Data.Entities.BikeRack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("LocationDescription");

                    b.Property<int>("NumberOfRacks");

                    b.Property<string>("RackType");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("BikeRacks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "2217 North Broadway, Knoxville, TN 37917",
                            LocationDescription = "Kroger",
                            NumberOfRacks = 2,
                            RackType = "Hitch",
                            Status = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
