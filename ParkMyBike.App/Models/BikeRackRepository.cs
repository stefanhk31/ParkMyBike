using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ParkMyBike.Resources.Enums;

namespace ParkMyBike.Models
{
    public class BikeRackRepository : IBikeRackRepository
    {
        private BikeRackContext _bikeRacksDb;
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
                    .Where(br => br.Id == rackId)
                    .FirstOrDefault();
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

        public BikeRack UpdateNumberofRacksOnBikeRack(int rackId, int newNumberOfRacks)
        {
            try
            {
                var rack = ViewSingleBikeRack(rackId);
                rack.NumberOfRacks = newNumberOfRacks;
                return rack;
            }
            catch (Exception e)
            {
                _logger.LogError($"Update Number of Bike Racks failed: {e.Message}");
                return null;
            }
        }

        public BikeRack UpdateBikeRackLocationDescription(int rackId, string newDescription)
        {
            try
            {
                var rack = ViewSingleBikeRack(rackId);
                rack.LocationDescription = newDescription;
                return rack;
            }
            catch (Exception e)
            {
                _logger.LogError($"Update Bike Rack Location Description failed: {e.Message}");
                return null;
            }
        }

        public BikeRack UpdateBikeRackStatus(int rackId, RackStatus newStatus)
        {
            try
            {
                var rack = ViewSingleBikeRack(rackId);
                rack.Status = newStatus;
                return rack;
            }
            catch (Exception e)
            {
                _logger.LogError($"Update Bike Rack Status failed: {e.Message}");
                return null;
            }
        }

        public BikeRack UpdateBikeRackType(int rackId, RackType newType)
        {
            try
            {
                var rack = ViewSingleBikeRack(rackId);
                rack.RackType = newType;
                return rack;
            }
            catch (Exception e)
            {
                _logger.LogError($"Update Bike Rack Type failed: {e.Message}");
                return null;
            }
        }
    }
}
