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
            using (var factory = new BikeRackContextFactory())
            {
                var logger = Mock.Of<ILogger<BikeRackRepository>>();

                using (var context = factory.CreateContext())
                {
                    var coords = GenerateTestCoordinates(1);
                    var rack = GenerateTestBikeRack(1, coords.Id);
                    var repository = new BikeRackRepository(context, logger);
                    repository.AddBikeRack(rack);

                    var result =  context.BikeRacks.Count();
                    Assert.Equal(1, result);
                }
            }
        }

        [Fact]
        public void CanViewSingleBikeRackFromDatabase()
        {
            using (var factory = new BikeRackContextFactory())
            {
                var logger = Mock.Of<ILogger<BikeRackRepository>>();

                using (var context = factory.CreateContext())
                {
                    var coords = GenerateTestCoordinates(1);
                    var rack = GenerateTestBikeRack(1, coords.Id);
                    var repository = new BikeRackRepository(context, logger);
                    repository.AddBikeRack(rack);

                    var result = repository.ViewSingleBikeRack(rack.Id);
                    Assert.Equal(rack.Id, result.Id);
                }
            }
        }

        [Fact]
        public void CanGetAllBikeRacksFromDatabase()
        {
            using (var factory = new BikeRackContextFactory())
            {
                var logger = Mock.Of<ILogger<BikeRackRepository>>();

                using (var context = factory.CreateContext())
                {
                    var coords = GenerateTestCoordinates(1);
                    var secondCoords = GenerateTestCoordinates(2);
                    var rack = GenerateTestBikeRack(1, coords.Id);
                    var secondRack = GenerateTestBikeRack(2, secondCoords.Id);
                    var repository = new BikeRackRepository(context, logger);
                    repository.AddBikeRack(rack);
                    repository.AddBikeRack(secondRack);

                    var result = repository.GetAllBikeRacks();
                    Assert.Equal(2, result.Count());
                    Assert.Equal(result.First().Id, rack.Id);
                    Assert.Equal(result.Last().Id, secondRack.Id);
                }
            }
        }

        [Fact]
        public void CanUpdateNumberOfBikeRacks()
        {
            using (var factory = new BikeRackContextFactory())
            {
                var logger = Mock.Of<ILogger<BikeRackRepository>>();

                using (var context = factory.CreateContext())
                {
                    var coords = GenerateTestCoordinates(1);
                    var rack = GenerateTestBikeRack(1, coords.Id);
                    var repository = new BikeRackRepository(context, logger);
                    repository.AddBikeRack(rack);

                    var result = repository.UpdateNumberofRacksOnBikeRack(rack.Id, 3);
                    Assert.Equal(3, result.NumberOfRacks);
                }
            }
        }

        [Fact]
        public void CanRemoveBikeRackFromDatabase()
        {
            using (var factory = new BikeRackContextFactory())
            {
                var logger = Mock.Of<ILogger<BikeRackRepository>>();

                using (var context = factory.CreateContext())
                {
                    var coords = GenerateTestCoordinates(1);
                    var secondCoords = GenerateTestCoordinates(2);
                    var rack = GenerateTestBikeRack(1, coords.Id);
                    var secondRack = GenerateTestBikeRack(2, secondCoords.Id);
                    var repository = new BikeRackRepository(context, logger);
                    repository.AddBikeRack(rack);
                    repository.AddBikeRack(secondRack);
                    repository.DeleteBikeRack(rack);

                    var result = repository.GetAllBikeRacks();
                    Assert.Single(result);
                    Assert.Equal(result.First().Id, secondRack.Id);
                }
            }
        }
    }
}
