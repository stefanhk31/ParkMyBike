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

            // TODO: use seeder when full dataset is available for database
            //_ctx.Database.EnsureCreated();

            //if (!_ctx.BikeRacks.Any())
            //{
            //    var filepath = Path.Combine(_hosting.ContentRootPath, "Data/attributes-dev.json");
            //    var json = File.ReadAllText(filepath);
            //    var racks = JsonConvert.DeserializeObject<IEnumerable<BikeRack>>(json);
            //    _ctx.BikeRacks.AddRange(racks);

            //    _ctx.SaveChanges();

            //}

        }
    }
}
