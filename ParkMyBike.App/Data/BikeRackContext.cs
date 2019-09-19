using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParkMyBike.Data.Entities;
using ParkMyBike.Enums;

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
        public DbSet<Coordinates> Coordinates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Coordinates initialCoords = new Coordinates
            {
                Id = 1,
                Longitude = -83.9569119,
                Latitude = 36.0140813
            };

            BikeRack initialBikeRack = new BikeRack
            {
                Id = 1,
                CoordinatesId = 1,
                NumberOfRacks = 1,
                LocationDescription = "My Home",
                Status = RackStatus.Installed,
                RackType = RackType.Other
            };

            modelBuilder.Entity<Coordinates>()
                .HasData(initialCoords);

            modelBuilder.Entity<BikeRack>()
                .HasData(initialBikeRack);
        }
    }
}
