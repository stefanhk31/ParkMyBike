using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using EFCore.Seeder.Extensions;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ParkMyBike.Data;
using ParkMyBike.Data.Entities;



namespace ParkMyBike.Data
{
    public class BikeRackSeeder
    {
        private readonly BikeRackContext _ctx;
        private readonly IHostingEnvironment _hosting;

        public BikeRackSeeder(BikeRackContext ctx, IHostingEnvironment hosting)
        {
            _ctx = ctx;
            _hosting = hosting;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();

            if (!_ctx.BikeRacks.Any())
            {
                var racksFilePath = Path.Combine(_hosting.ContentRootPath, "Data/test-bike-racks.json");
                var racksJson = File.ReadAllText(racksFilePath);
                var racks = JsonConvert.DeserializeObject<IEnumerable<BikeRack>>(racksJson);

                _ctx.BikeRacks.AddRange(racks);
                _ctx.SaveChanges();
            }

        }
    }
}
