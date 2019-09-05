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
using ParkMyBike.Data;



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
                var csvFilePath = Path.Combine(_hosting.ContentRootPath, "Data/BikeRacks.csv");
                var csvData = File.ReadAllText(csvFilePath);
                _ctx.AddRange(csvData);
                _ctx.SaveChanges();
            }

        }
    }
}
