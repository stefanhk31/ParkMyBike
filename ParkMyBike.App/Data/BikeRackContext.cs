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

        public virtual DbSet<BikeRack> BikeRacks { get; set; }
        public virtual DbSet<Coordinates> Coordinates { get; set; }
    }
}
