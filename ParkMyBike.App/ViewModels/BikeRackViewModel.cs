using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ParkMyBike.Resources.Enums;
using System.ComponentModel.DataAnnotations;

namespace ParkMyBike.ViewModels
{
    public class BikeRackViewModel
    {
        [JsonProperty("rackId")]
        public int RackId { get; set; }
        [JsonProperty("numberOfRacks")]
        [Required]
        public int NumberOfRacks { get; set; }
        [JsonProperty("latLong")]
        [Required]
        [RegularExpression(@"^[-]?([1-8]?\d(\.\d+)?|90(\.0+)?),\s*[-]?(180(\.0+)?|((1[0-7]\d)|([1-9]?\d))(\.\d+)?)$")]
        public string LatLong { get; set; }
        [JsonProperty("locationDescription")]
        public string LocationDescription { get; set; }
        [Required]
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RackStatus RackStatus { get; set; }
        [Required]
        [JsonProperty("rackType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RackType RackType { get; set; }
    }
}
