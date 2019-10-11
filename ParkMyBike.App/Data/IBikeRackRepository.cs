using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkMyBike.Data.Entities;

namespace ParkMyBike.Data
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
