using ParkMyBike.Resources.Enums;
using System.Collections.Generic;

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
