using ParkMyBike.Resources.Enums;
using System.Linq;
using Xunit;

namespace ParkMyBike.Tests
{
    public class DataAccessTests : BaseTestClass
    {        
        [Fact]
        public void CanAddBikeRackToDatabase()
        {
            var rack = GenerateTestBikeRack(1);
            _repository.AddBikeRack(rack);

            var result = _context.BikeRacks.Count();
            Assert.Equal(1, result);
        }

        [Fact]
        public void CanViewSingleBikeRackFromDatabase()
        {
            var rack = GenerateTestBikeRack(1);
            _repository.AddBikeRack(rack);

            var result = _repository.ViewSingleBikeRack(rack.Id);
            Assert.Equal(rack.Id, result.Id);
        }

        [Fact]
        public void CanGetAllBikeRacksFromDatabase()
        {

            var racks = GenerateRacks(2);

            foreach (var rack in racks)
            {
                _repository.AddBikeRack(rack);
            }

            var result = _repository.GetAllBikeRacks();
            Assert.Equal(2, result.Count());
            Assert.Equal(result.First().Id, racks[0].Id);
            Assert.Equal(result.Last().Id, racks[1].Id);
        }

        [Fact]
        public void CanUpdateBikeRack()
        {
            var rack = GenerateTestBikeRack(1);
            var rackToBeUpdated = _repository.AddBikeRack(rack);
            rackToBeUpdated.NumberOfRacks = 3;
            var result = _repository.UpdateBikeRack(rackToBeUpdated);
            Assert.Equal(3, result.NumberOfRacks);
        }
    }
}
