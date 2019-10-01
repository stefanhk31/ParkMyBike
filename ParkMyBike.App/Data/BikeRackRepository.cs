using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ParkMyBike.Data;
using ParkMyBike.Data.Entities;

namespace ParkMyBike.Models
{
    public class BikeRackRepository : IBikeRackRepository
    {
        private BikeRackContext _bikeRacksDb;

        public BikeRackRepository(BikeRackContext bikeRacksDb)
        {
            _bikeRacksDb = bikeRacksDb;
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
                throw new Exception(e.Message);
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
                throw new Exception(e.Message);
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
                throw new Exception(e.Message);
            }
        }

        public List<BikeRack> GetAllBikeRacks()
        {
            try
            {
                return _bikeRacksDb.BikeRacks.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public BikeRack UpdateNumberofRacksOnBikeRack(int rackId, int newNumberOfRacks)
        {
            try
            {
                var rack = _bikeRacksDb.BikeRacks
                    .Where(br => br.Id == rackId)
                    .FirstOrDefault();
                rack.NumberOfRacks = newNumberOfRacks;
                return rack;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
