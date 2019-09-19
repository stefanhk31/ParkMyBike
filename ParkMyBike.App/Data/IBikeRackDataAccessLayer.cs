using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkMyBike.Data.Entities;

namespace ParkMyBike.Data
{
    public interface IBikeRackDataAccessLayer
    {
        IEnumerable<BikeRack> GetBikeRacks();
        int AddBikeRack(BikeRack rack);
        int UpdateBikeRack(BikeRack rack);
        BikeRack getBikeRackData(int id);
        int DeleteBikeRack(int id);

    }
}
