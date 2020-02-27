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
                protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //add custom mapping for location here? (mb also for racktype, if necessary?)
        }

    }
}
