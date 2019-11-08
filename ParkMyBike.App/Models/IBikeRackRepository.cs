using System.Collections.Generic;

namespace ParkMyBike.Models
{
    public interface IBikeRackRepository
    {
        IEnumerable<BikeRack> GetAllBikeRacks();
        BikeRack AddBikeRack(BikeRack rack);
        BikeRack UpdateNumberofRacksOnBikeRack(int rackId, int newNumberOfRacks);
        BikeRack ViewSingleBikeRack(int rackId);
        BikeRack DeleteBikeRack(BikeRack rack);

    }
}
