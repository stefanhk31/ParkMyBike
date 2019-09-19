﻿using ParkMyBike.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkMyBike.Data.Entities
{
    public class BikeRack
    {
        public int Id { get; set; }
        public int CoordinatesId { get; set; }
        public int NumberOfRacks { get; set; }
        public string LocationDescription { get; set; }
        public RackStatus Status { get; set; }
        public RackType RackType { get; set; }
    }
}
