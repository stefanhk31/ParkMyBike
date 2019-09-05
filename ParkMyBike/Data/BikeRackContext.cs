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

            modelBuilder.Entity<BikeRack>().HasData(new BikeRack()
            {
                Id = 1,
                Address = "2225 Estelle Circle",
                LocationDescription = "Will Skelton Greenway",
                NumberOfRacks = 1,
                RackType = "Hoop",
                Status = "Installed"
            });
        }
    }
}
