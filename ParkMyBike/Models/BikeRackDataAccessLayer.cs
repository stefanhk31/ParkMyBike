using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParkMyBike.Data;
using ParkMyBike.Data.Entities;

namespace ParkMyBike.Models
{
    public class BikeRackDataAccessLayer : IBikeRack
    {
        private BikeRackContext bikeRacksDb;

        public BikeRackDataAccessLayer(BikeRackContext _bikeRacksDb)
        {
            bikeRacksDb = _bikeRacksDb;
        }

        public int AddBikeRack(BikeRack rack) 
        {
            try
            {
                bikeRacksDb.BikeRacks.Add(rack);
                bikeRacksDb.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public int DeleteBikeRack(int id)
        {
            try
            {
                BikeRack rack = bikeRacksDb.BikeRacks.Find(id);
                bikeRacksDb.BikeRacks.Remove(rack);
                bikeRacksDb.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public BikeRack getBikeRackData(int id)
        {
            try
            {
                BikeRack rack = bikeRacksDb.BikeRacks.Find(id);
                return rack;
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<BikeRack> GetBikeRacks()
        {
            try
            {
                return bikeRacksDb.BikeRacks.ToList();
            }
            catch
            {
                throw;
            }
        }

        public int UpdateBikeRack(BikeRack rack) 
        {
            try
            {
                bikeRacksDb.Entry(rack).State = EntityState.Modified;
                bikeRacksDb.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}
