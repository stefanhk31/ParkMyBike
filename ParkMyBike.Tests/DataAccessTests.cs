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
        public void CanUpdateNumberOfBikeRacks()
        {
            var rack = GenerateTestBikeRack(1);
            _repository.AddBikeRack(rack);

            var result = _repository.UpdateNumberofRacksOnBikeRack(rack.Id, 3);
            Assert.Equal(3, result.NumberOfRacks);
        }

        [Fact]
        public void CanRemoveBikeRackFromDatabase()
        {
            var racks = GenerateRacks(2);

            foreach (var rack in racks)
            {
                _repository.AddBikeRack(rack);
            }
            _repository.DeleteBikeRack(racks[0]);


            var result = _repository.GetAllBikeRacks();
            Assert.Single(result);
            Assert.Equal(result.First().Id, racks[1].Id);
        }
    }
}
