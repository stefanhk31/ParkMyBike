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

        public virtual DbSet<BikeRack> BikeRacks { get; set; }
    }
}
