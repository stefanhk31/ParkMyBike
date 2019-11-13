using ParkMyBike.Resources.Enums;
using System.Collections.Generic;

namespace ParkMyBike.Models
{
    public interface IBikeRackRepository
    {
        IEnumerable<BikeRack> GetAllBikeRacks();
        BikeRack AddBikeRack(BikeRack rack);
        BikeRack UpdateNumberofRacksOnBikeRack(int rackId, int newNumberOfRacks);
        BikeRack UpdateBikeRackLocationDescription(int rackId, string newDescription);
        BikeRack UpdateBikeRackStatus(int rackId, RackStatus newStatus);
        BikeRack UpdateBikeRackType(int rackId, RackType newType);
        BikeRack ViewSingleBikeRack(int rackId);
        BikeRack DeleteBikeRack(BikeRack rack);

    }
}
