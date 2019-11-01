﻿
using Microsoft.AspNetCore.Mvc;
using ParkMyBike.Controllers;
using ParkMyBike.Data.Entities;
using System.Collections.Generic;
using Xunit;

namespace ParkMyBike.Tests
{
    public class WebAPITests : BaseTestClass
    {
        private BikeRacksController _controller;

        public WebAPITests()
        {
            _controller = new BikeRacksController(_repository, _logger);
        }

        [Fact]
        public void GetAllReturnsSuccess()
        {
            ActionResult<IEnumerable<BikeRack>> result = _controller.GetAll();
            var contentResult = new OkObjectResult(result);

            Assert.NotNull(contentResult);
            Assert.Equal(200, contentResult.StatusCode);
        }

        [Fact]
        public void GetReturnsSuccess()
        {
            var rack = GenerateTestBikeRack(1);
            _repository.AddBikeRack(rack);
            ActionResult<BikeRack> result = _controller.Get(1);
            var contentResult = new OkObjectResult(result);

            Assert.NotNull(contentResult);
            Assert.Equal(200, contentResult.StatusCode);
        }

        [Fact]
        public void PostReturnsSuccess()
        {
            var newRack = GenerateTestBikeRack(1);
            _repository.AddBikeRack(newRack);
            ActionResult<BikeRack> result = _controller.Post(newRack);
            var contentResult = new OkObjectResult(result);

            Assert.NotNull(contentResult);
            Assert.Equal(200, contentResult.StatusCode);
        }

        [Fact]
        public void PutReturnsSuccess()
        {
            var rack = GenerateTestBikeRack(1);
            _repository.AddBikeRack(rack);
            ActionResult<BikeRack> result = _controller.Put(1, 3);
            var contentResult = new OkObjectResult(result);

            Assert.NotNull(contentResult);
            Assert.Equal(200, contentResult.StatusCode);
        }

        [Fact]
        public void DeleteReturnsSuccess()
        {
            var rack = GenerateTestBikeRack(1);
            _repository.AddBikeRack(rack);
            ActionResult<BikeRack> result = _controller.Delete(rack);
            var contentResult = new OkObjectResult(result);

            Assert.NotNull(contentResult);
            Assert.Equal(200, contentResult.StatusCode);
        }
    }
}
