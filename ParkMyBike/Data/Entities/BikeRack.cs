using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkMyBike.Enums;

namespace ParkMyBike.Data.Entities
{
    public class BikeRack
    {
        public int Id { get; set; }
        public int NumberOfRacks { get; set; }
        public string RackType { get; set; }
        public string LocationDescription { get; set; }
        public string Address { get; set; }
        public RackStatus Status { get; set; }
    }
}
