using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace ParkMyBike.Data
{
    public class BikeRackSeeder
    {
        private readonly BikeRackContext _ctx;

        public BikeRackSeeder(BikeRackContext ctx)
        {
            _ctx = ctx;
        }

        public void Seed()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "ParkMyBike.Domain.BikeRacks.csv";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    //add code to read csv files 
                }
            }

        }
    }
}
