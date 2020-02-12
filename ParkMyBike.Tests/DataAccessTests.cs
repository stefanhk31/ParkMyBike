using System.Linq;
using ParkMyBike.Models.Entities;
using Xunit;

namespace ParkMyBike.Tests
{
    public class DataAccessTests : BaseTestClass
    {        
        [Fact]
        public void CanAddBikeRackToDatabase()
        {
            var rack = GenerateTestBikeRack(1);
            Repository.AddBikeRack(rack);

            var result = Context.BikeRacks.Count();
            Assert.Equal(1, result);
        }

        [Fact]
        public void CanViewSingleBikeRackFromDatabase()
        {
            var rack = GenerateTestBikeRack(1);
            Repository.AddBikeRack(rack);

            var result = Repository.ViewSingleBikeRack(rack.Id);
            Assert.Equal(rack.Id, result.Id);
        }

        [Fact]
        public void CanGetAllBikeRacksFromDatabase()
        {

            var racks = GenerateRacks(2);

            foreach (var rack in racks)
            {
                Repository.AddBikeRack(rack);
            }

            var result = Repository.GetAllBikeRacks();
            var bikeRacks = result as BikeRack[] ?? result.ToArray();
            Assert.Equal(2, bikeRacks.Count());
            Assert.Equal(bikeRacks.First().Id, racks[0].Id);
            Assert.Equal(bikeRacks.Last().Id, racks[1].Id);
        }

        [Fact]
        public void CanUpdateBikeRack()
        {
            var rack = GenerateTestBikeRack(1);
            var rackToBeUpdated = Repository.AddBikeRack(rack);
            rackToBeUpdated.NumberOfRacks = 3;
            var result = Repository.UpdateBikeRack(rackToBeUpdated);
            Assert.Equal(3, result.NumberOfRacks);
        }
    }
}
