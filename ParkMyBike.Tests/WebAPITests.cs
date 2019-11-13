﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ParkMyBike.Controllers;
using ParkMyBike.Models;
using ParkMyBike.Resources.Enums;
using ParkMyBike.ViewModels;
using System.Collections.Generic;
using Xunit;

namespace ParkMyBike.Tests
{
    public class WebAPITests : BaseTestClass
    {
        private BikeRacksController _controller;

        public WebAPITests()
        {
            _controller = new BikeRacksController(_repository, _logger, _mapper);
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
            ActionResult<BikeRack> result = _controller.Post(_mapper.Map<BikeRack, BikeRackViewModel>(newRack));
            var contentResult = new OkObjectResult(result);

            Assert.NotNull(contentResult);
            Assert.Equal(200, contentResult.StatusCode);
        }

        [Fact]
        public void UpdateNumberOfRacksReturnsSuccess()
        {
            var rack = GenerateTestBikeRack(1);
            _repository.AddBikeRack(rack);
            ActionResult<BikeRack> result = _controller.UpdateNumberOfRacks(1, 3);
            var contentResult = new OkObjectResult(result);

            Assert.NotNull(contentResult);
            Assert.Equal(200, contentResult.StatusCode);
        }

        [Fact]
        public void UpdateLocationDescriptionReturnsSuccess()
        {
            var rack = GenerateTestBikeRack(1);
            _repository.AddBikeRack(rack);
            ActionResult<BikeRack> result = _controller.UpdateLocationDescription(rack.Id, "A new description");
            var contentResult = new OkObjectResult(result);

            Assert.NotNull(contentResult);
            Assert.Equal(200, contentResult.StatusCode);
        }

        [Fact]
        public void UpdateRackStatusReturnsSuccess()
        {
            var rack = GenerateTestBikeRack(1);
            _repository.AddBikeRack(rack);
            ActionResult<BikeRack> result = _controller.UpdateRackStatus(rack.Id, RackStatus.ToBeReplaced);
            var contentResult = new OkObjectResult(result);

            Assert.NotNull(contentResult);
            Assert.Equal(200, contentResult.StatusCode);
        }

        [Fact]
        public void UpdateRackTypeReturnsSuccess()
        {
            var rack = GenerateTestBikeRack(1);
            _repository.AddBikeRack(rack);
            ActionResult<BikeRack> result = _controller.UpdateRackType(rack.Id, RackType.Hoop);
            var contentResult = new OkObjectResult(result);

            Assert.NotNull(contentResult);
            Assert.Equal(200, contentResult.StatusCode);
        }

        [Fact]
        public void DeleteReturnsSuccess()
        {
            var rack = GenerateTestBikeRack(1);
            _repository.AddBikeRack(rack);
            ActionResult<BikeRack> result = _controller.Delete(_mapper.Map<BikeRack, BikeRackViewModel>(rack));
            var contentResult = new OkObjectResult(result);

            Assert.NotNull(contentResult);
            Assert.Equal(200, contentResult.StatusCode);
        }
    }
}
