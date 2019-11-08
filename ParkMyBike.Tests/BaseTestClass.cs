using Microsoft.Extensions.Logging;
using Moq;
using ParkMyBike.Resources.Enums;
using ParkMyBike.Models;
using System;
using System.Collections.Generic;
using AutoMapper;

namespace ParkMyBike.Tests
{
    public class BaseTestClass : IDisposable
    {
        protected BikeRackContextFactory _factory;
        protected BikeRackContext _context;
        protected ILogger<BikeRackRepository> _logger;
        protected BikeRackRepository _repository;
        protected IMapper _mapper;

        public BaseTestClass()
        {
            _factory = new BikeRackContextFactory();
            _context = _factory.CreateContext();
            _logger = Mock.Of<ILogger<BikeRackRepository>>();
            _repository = new BikeRackRepository(_context, _logger);
            _mapper = Mock.Of<IMapper>();
        }

        public static BikeRack GenerateTestBikeRack(int rackId)
        {
            return new BikeRack()
            {
                Id = rackId,
                NumberOfRacks = 2,
                LatLong = "0.0000,0.0000",
                LocationDescription = "Test",
                Status = RackStatus.Installed,
                RackType = RackType.Hitch
            };
        }

        public static List<BikeRack> GenerateRacks(int numberOfRacksToGenerate)
        {
            var racks = new List<BikeRack>();

            for (var i = 1; i <= numberOfRacksToGenerate; i++)
            {
                racks.Add(GenerateTestBikeRack(i));
            }

            return racks;
        }

        public void Dispose()
        {
            _factory = null;
            _context = null;
            _logger = null;
            _repository = null;
        }
    }
}
