using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ParkMyBike.Enums;
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
        public int NumberOfRacks { get; set; }
        public string LatLong { get; set; }
        public string LocationDescription { get; set; }
        [JsonProperty("Status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RackStatus Status { get; set; }
        [JsonProperty("RackType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RackType RackType { get; set; }
    }
}
