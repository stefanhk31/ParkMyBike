using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ParkMyBike.Resources.Enums;

namespace ParkMyBike.Models
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
