using ParkMyBike.Data;
using ParkMyBike.Data.Entities;
using ParkMyBike.Models;
using System.Linq;
using Xunit;
using ParkMyBike.Enums;
using Moq;
using Microsoft.Extensions.Logging;

namespace ParkMyBike.Tests
{
    public class DataAccessTests
    {

        private BikeRackContextFactory _factory;
        private BikeRackContext _context;
        private ILogger<BikeRackRepository> _logger;
        private BikeRackRepository _repository;

        public DataAccessTests()
        {
            _factory = new BikeRackContextFactory();
            _context = _factory.CreateContext();
            _logger = Mock.Of<ILogger<BikeRackRepository>>();
            _repository = new BikeRackRepository(_context, _logger);
        }

        public Coordinates GenerateTestCoordinates(int id)
        {
            return new Coordinates()
            {
                Id = id,
                Latitude = 0.00,
                Longitude = 0.00
            };
        }

        public BikeRack GenerateTestBikeRack(int rackId, int coordsId)
        {
            return new BikeRack()
            {
                Id = rackId,
                CoordinatesId = coordsId,
                NumberOfRacks = 2,
                LocationDescription = "Test",
                Status = RackStatus.Installed,
                RackType = RackType.Hitch
            };
        }

        [Fact]
        public void CanAddBikeRackToDatabase()
        {
            var coords = GenerateTestCoordinates(1);
            var rack = GenerateTestBikeRack(1, coords.Id);
            _repository.AddBikeRack(rack);

            var result = _context.BikeRacks.Count();
            Assert.Equal(1, result);
        }

        [Fact]
        public void CanViewSingleBikeRackFromDatabase()
        {
            var coords = GenerateTestCoordinates(1);
            var rack = GenerateTestBikeRack(1, coords.Id);
            _repository.AddBikeRack(rack);

            var result = _repository.ViewSingleBikeRack(rack.Id);
            Assert.Equal(rack.Id, result.Id);
        }

        [Fact]
        public void CanGetAllBikeRacksFromDatabase()
        {
            var coords = GenerateTestCoordinates(1);
            var secondCoords = GenerateTestCoordinates(2);
            var rack = GenerateTestBikeRack(1, coords.Id);
            var secondRack = GenerateTestBikeRack(2, secondCoords.Id);
            _repository.AddBikeRack(rack);
            _repository.AddBikeRack(secondRack);

            var result = _repository.GetAllBikeRacks();
            Assert.Equal(2, result.Count());
            Assert.Equal(result.First().Id, rack.Id);
            Assert.Equal(result.Last().Id, secondRack.Id);
        }

        [Fact]
        public void CanUpdateNumberOfBikeRacks()
        {
            var coords = GenerateTestCoordinates(1);
            var rack = GenerateTestBikeRack(1, coords.Id);
            _repository.AddBikeRack(rack);

            var result = _repository.UpdateNumberofRacksOnBikeRack(rack.Id, 3);
            Assert.Equal(3, result.NumberOfRacks);
        }

        [Fact]
        public void CanRemoveBikeRackFromDatabase()
        {
            var coords = GenerateTestCoordinates(1);
            var secondCoords = GenerateTestCoordinates(2);
            var rack = GenerateTestBikeRack(1, coords.Id);
            var secondRack = GenerateTestBikeRack(2, secondCoords.Id);
            _repository.AddBikeRack(rack);
            _repository.AddBikeRack(secondRack);
            _repository.DeleteBikeRack(rack);

            var result = _repository.GetAllBikeRacks();
            Assert.Single(result);
            Assert.Equal(result.First().Id, secondRack.Id);
        }
    }
}
