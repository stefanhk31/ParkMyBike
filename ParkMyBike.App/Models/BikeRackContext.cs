using Microsoft.EntityFrameworkCore;
using ParkMyBike.Models.Entities;

namespace ParkMyBike.Models
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
