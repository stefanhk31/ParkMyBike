using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParkMyBike.Data.Entities;

namespace ParkMyBike.Data
{
    public class BikeRackContext : DbContext
    {
        public BikeRackContext()
        {
        }

        public BikeRackContext(DbContextOptions<BikeRackContext> options): base(options)
        {

        }

        public DbSet<BikeRack> BikeRacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BikeRack>()
                .HasData(new BikeRack() {
                    Id = 1,
                    NumberOfRacks = 2,
                    RackType = "Hitch",
                    LocationDescription = "Kroger",
                    Address = "2217 North Broadway, Knoxville, TN 37917",
                    Status = Enums.RackStatus.Planned
                });

        }

    }
}
