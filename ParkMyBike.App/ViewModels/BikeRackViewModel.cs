using ParkMyBike.Enums;
using System.ComponentModel.DataAnnotations;

namespace ParkMyBike.ViewModels
{
    public class BikeRackViewModel
    {
        [Required]
        public int RackId { get; set; }
        public int NumberOfRacks { get; set; }
        [RegularExpression(@"^(\-?d+(\.\d+)?),(\-?d+(\.\d+)?)$")]
        public string LatLong { get; set; }
        public string LocationDescription { get; set; }
        public RackStatus RackStatus { get; set; }
        public RackType RackType { get; set; }
    }
}
