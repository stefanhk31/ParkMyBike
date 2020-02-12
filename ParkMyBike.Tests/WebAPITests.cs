using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ParkMyBike.Controllers;
using ParkMyBike.Models;
using ParkMyBike.Resources.Enums;
using ParkMyBike.ViewModels;
using System.Collections.Generic;
using ParkMyBike.Models.Entities;
using Xunit;

namespace ParkMyBike.Tests
{
    public class WebApiTests : BaseTestClass
    {
        private readonly BikeRacksController _controller;

        public WebApiTests()
        {
            _controller = new BikeRacksController(Repository, Logger, Mapper);
        }

        [Fact]
        public void GetAllReturnsSuccess()
        {
            var result = _controller.GetAll();
            var contentResult = new OkObjectResult(result);

            Assert.NotNull(contentResult);
            Assert.Equal(200, contentResult.StatusCode);
        }

        [Fact]
        public void GetReturnsSuccess()
        {
            var rack = GenerateTestBikeRack(1);
            Repository.AddBikeRack(rack);
            var result = _controller.Get(1);
            var contentResult = new OkObjectResult(result);

            Assert.NotNull(contentResult);
            Assert.Equal(200, contentResult.StatusCode);
        }

        [Fact]
        public void PostReturnsSuccess()
        {
            var newRack = GenerateTestBikeRack(1);
            Repository.AddBikeRack(newRack);
            var result = _controller.Post(Mapper.Map<BikeRack, BikeRackViewModel>(newRack));
            var contentResult = new OkObjectResult(result);

            Assert.NotNull(contentResult);
            Assert.Equal(200, contentResult.StatusCode);
        }

        [Fact]
        public void UpdateBikeRackReturnsSuccess()
        {
            var rack = GenerateTestBikeRack(1);
            Repository.AddBikeRack(rack);
            rack.NumberOfRacks = 3;
            var result = _controller.UpdateBikeRack(Mapper.Map<BikeRack, BikeRackViewModel>(rack));
            var contentResult = new OkObjectResult(result);

            Assert.NotNull(contentResult);
            Assert.Equal(200, contentResult.StatusCode);
        }

        [Fact]
        public void DeleteReturnsSuccess()
        {
            var rack = GenerateTestBikeRack(1);
            Repository.AddBikeRack(rack);
            var result = _controller.Delete(rack.Id);
            var contentResult = new OkObjectResult(result);

            Assert.NotNull(contentResult);
            Assert.Equal(200, contentResult.StatusCode);
        }
    }
}
