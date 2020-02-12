using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ParkMyBike.Models.Entities;

namespace ParkMyBike.Models
{
    public class BikeRackRepository : IBikeRackRepository
    {
        private readonly BikeRackContext _bikeRacksDb;
        private readonly ILogger<BikeRackRepository> _logger;

        public BikeRackRepository(BikeRackContext bikeRacksDb, ILogger<BikeRackRepository> logger)
        {
            _bikeRacksDb = bikeRacksDb;
            _logger = logger;
        }

        public BikeRack AddBikeRack(BikeRack rack)
        {
            try
            {
                _bikeRacksDb.BikeRacks.Add(rack);
                _bikeRacksDb.SaveChanges();
                return rack;
            }
            catch (Exception e)
            {
                _logger.LogError($"Add Bike Rack failed: {e.Message}");
                return null;
            }
        }

        public BikeRack DeleteBikeRack(BikeRack rack)
        {
            try
            {
                _bikeRacksDb.BikeRacks.Remove(rack);
                _bikeRacksDb.SaveChanges();
                return rack;
            }
            catch (Exception e)
            {
                _logger.LogError($"Delete Bike Rack failed: {e.Message}");
                return null;
            }
        }

        public BikeRack ViewSingleBikeRack(int rackId)
        {
            try
            {
                var result = _bikeRacksDb.BikeRacks
                    .FirstOrDefault(br => br.Id == rackId);
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError($"View Single Bike Rack failed: {e.Message}");
                return null;
            }
        }

        public IEnumerable<BikeRack> GetAllBikeRacks()
        {
            try
            {
                return _bikeRacksDb.BikeRacks.ToList();
            }
            catch (Exception e)
            {
                _logger.LogError($"Get All Bike Racks failed: {e.Message}");
                return null;
            }
        }

        public BikeRack UpdateBikeRack(BikeRack rack)
        {
            try
            {
                _bikeRacksDb.BikeRacks.Update(rack);
                _bikeRacksDb.SaveChanges();
                return rack;
            }
            catch (Exception e)
            {
                _logger.LogError($"Update Bike Rack failed: {e.Message}");
                return null;
            }
        }
    }
}
