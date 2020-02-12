using System.Collections.Generic;
using ParkMyBike.Models.Entities;

namespace ParkMyBike.Models
{
    public interface IBikeRackRepository
    {
        IEnumerable<BikeRack> GetAllBikeRacks();
        BikeRack AddBikeRack(BikeRack rack);
        BikeRack UpdateBikeRack(BikeRack rack);
        BikeRack ViewSingleBikeRack(int rackId);
        BikeRack DeleteBikeRack(BikeRack rack);
    }
}
