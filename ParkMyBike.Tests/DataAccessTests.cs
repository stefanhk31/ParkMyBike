using ParkMyBike.Data;
using ParkMyBike.Data.Entities;
using ParkMyBike.Models;
using System.Linq;
using System.Collections.Generic;
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

        public BikeRack GenerateTestBikeRack(int rackId, Coordinates coords)
        {
            return new BikeRack()
            {
                Id = rackId,
                CoordinatesId = coords.Id,
                NumberOfRacks = 2,
                LocationDescription = "Test",
                Status = RackStatus.Installed,
                RackType = RackType.Hitch
            };
        }

        public List<BikeRack> GenerateRacks(int numberOfRacksToGenerate)
        {
            var racks = new List<BikeRack>();

            for (var i = 1; i <= numberOfRacksToGenerate; i++)
            {
                racks.Add(GenerateTestBikeRack(i, GenerateTestCoordinates(i)));
            }

            return racks;
        }

        [Fact]
        public void CanAddBikeRackToDatabase()
        {
            var racks = GenerateRacks(1);
            _repository.AddBikeRack(racks[0]);

            var result = _context.BikeRacks.Count();
            Assert.Equal(1, result);
        }

        [Fact]
        public void CanViewSingleBikeRackFromDatabase()
        {
            var racks = GenerateRacks(1);
            _repository.AddBikeRack(racks[0]);

            var result = _repository.ViewSingleBikeRack(racks[0].Id);
            Assert.Equal(racks[0].Id, result.Id);
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
            var racks = GenerateRacks(1);
            _repository.AddBikeRack(racks[0]);

            var result = _repository.UpdateNumberofRacksOnBikeRack(racks[0].Id, 3);
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
