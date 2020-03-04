using Microsoft.Extensions.Logging;
using Moq;
using ParkMyBike.Resources.Enums;
using ParkMyBike.Models;
using System;
using System.Collections.Generic;
using AutoMapper;
using ParkMyBike.Models.Entities;

namespace ParkMyBike.Tests
{
    public class BaseTestClass : IDisposable
    {
        protected BikeRackContextFactory Factory;
        protected BikeRackContext Context;
        protected ILogger<BikeRackRepository> Logger;
        protected BikeRackRepository Repository;
        protected IMapper Mapper;

        public BaseTestClass()
        {
            Factory = new BikeRackContextFactory();
            Context = Factory.CreateInMemoryContext();
            Logger = Mock.Of<ILogger<BikeRackRepository>>();
            Repository = new BikeRackRepository(Context, Logger);
            Mapper = Mock.Of<IMapper>();
        }

        public static BikeRack GenerateTestBikeRack(int rackId)
        {
            return new BikeRack()
            {
                Id = rackId,
                NumberOfRacks = 2,
                LocationDescription = "Test",
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
            Factory = null;
            Context = null;
            Logger = null;
            Repository = null;
        }
    }
}
