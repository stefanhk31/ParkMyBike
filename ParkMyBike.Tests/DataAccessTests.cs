using ParkMyBike.Data;
using ParkMyBike.Data.Entities;
using ParkMyBike.Enums;
using ParkMyBike.Models;
using System;
using System.Linq;
using Xunit;
using Moq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace ParkMyBike.Tests
{
    public class DataAccessTests
    {
        [Fact]
        public void CanAddBikeRackToDatabase()
        {
            var newRack = new Mock<BikeRack>();
            var mockSet = new Mock<DbSet<BikeRack>>();
            var mockContext = new Mock<BikeRackContext>();

            mockContext.Setup(c => c.BikeRacks).Returns(mockSet.Object);

            var repository = new BikeRackRepository(mockContext.Object);
            repository.AddBikeRack(newRack.Object);

            mockSet.Verify(m => m.Add(It.IsAny<BikeRack>()), Times.Once);
            mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Fact]
        public void CanViewSingleBikeRackFromDatabase()
        {
            var newRack = new Mock<BikeRack>();

            IQueryable<BikeRack> bikeRacks = new List<BikeRack>
            {
                newRack.Object
            }.AsQueryable();

            var mockSet = new Mock<DbSet<BikeRack>>();
            mockSet.As<IQueryable<BikeRack>>().Setup(m => m.Provider).Returns(bikeRacks.Provider);
            mockSet.As<IQueryable<BikeRack>>().Setup(m => m.Expression).Returns(bikeRacks.Expression);
            mockSet.As<IQueryable<BikeRack>>().Setup(m => m.ElementType).Returns(bikeRacks.ElementType);
            mockSet.As<IQueryable<BikeRack>>().Setup(m => m.GetEnumerator()).Returns(bikeRacks.GetEnumerator());

            var mockContext = new Mock<BikeRackContext>();
            mockContext.Setup(c => c.BikeRacks).Returns(mockSet.Object);

            var repository = new BikeRackRepository(mockContext.Object);
            repository.AddBikeRack(newRack.Object);
            var result = repository.ViewSingleBikeRack(newRack.Object.Id);

            Assert.Equal(newRack.Object.Id, result.Id);
        }

        [Fact]
        public void CanGetAllBikeRacksFromDatabase()
        {

            var newRack = new Mock<BikeRack>();
            var secondNewRack = new Mock<BikeRack>();

            IQueryable<BikeRack> bikeRacks = new List<BikeRack>
            {
                newRack.Object,
                secondNewRack.Object
            }.AsQueryable();

            var mockSet = new Mock<DbSet<BikeRack>>();
            mockSet.As<IQueryable<BikeRack>>().Setup(m => m.Provider).Returns(bikeRacks.Provider);
            mockSet.As<IQueryable<BikeRack>>().Setup(m => m.Expression).Returns(bikeRacks.Expression);
            mockSet.As<IQueryable<BikeRack>>().Setup(m => m.ElementType).Returns(bikeRacks.ElementType);
            mockSet.As<IQueryable<BikeRack>>().Setup(m => m.GetEnumerator()).Returns(bikeRacks.GetEnumerator());

            var mockContext = new Mock<BikeRackContext>();
            mockContext.Setup(c => c.BikeRacks).Returns(mockSet.Object);

            var repository = new BikeRackRepository(mockContext.Object);
            var result = repository.GetAllBikeRacks();

            Assert.Equal(2, result.Count());
            Assert.Equal(result.First().Id, newRack.Object.Id);
            Assert.Equal(result.Last().Id, secondNewRack.Object.Id);
        }

        [Fact]
        public void CanUpdateNumberOfBikeRacks()
        {
            var newRack = new Mock<BikeRack>();

            IQueryable<BikeRack> bikeRacks = new List<BikeRack>
            {
                newRack.Object
            }.AsQueryable();

            var mockSet = new Mock<DbSet<BikeRack>>();
            mockSet.As<IQueryable<BikeRack>>().Setup(m => m.Provider).Returns(bikeRacks.Provider);
            mockSet.As<IQueryable<BikeRack>>().Setup(m => m.Expression).Returns(bikeRacks.Expression);
            mockSet.As<IQueryable<BikeRack>>().Setup(m => m.ElementType).Returns(bikeRacks.ElementType);
            mockSet.As<IQueryable<BikeRack>>().Setup(m => m.GetEnumerator()).Returns(bikeRacks.GetEnumerator());

            var mockContext = new Mock<BikeRackContext>();
            mockContext.Setup(c => c.BikeRacks).Returns(mockSet.Object);

            var repository = new BikeRackRepository(mockContext.Object);
            repository.AddBikeRack(newRack.Object);
            var result = repository.UpdateNumberofRacksOnBikeRack(newRack.Object.Id, 3);

            Assert.Equal(3, result.NumberOfRacks);
            mockContext.Verify(m => m.SaveChanges(), Times.Once);

        }

        [Fact]
        public void CanRemoveBikeRackFromDatabase()
        {
            var newRack = new Mock<BikeRack>();
            var mockSet = new Mock<DbSet<BikeRack>>();
            var mockContext = new Mock<BikeRackContext>();

            mockContext.Setup(c => c.BikeRacks).Returns(mockSet.Object);

            var repository = new BikeRackRepository(mockContext.Object);
            repository.DeleteBikeRack(newRack.Object);

            mockSet.Verify(m => m.Remove(It.IsAny<BikeRack>()), Times.Once);
            mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

    }
}
