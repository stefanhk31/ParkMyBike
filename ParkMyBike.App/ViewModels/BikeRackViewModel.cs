using ParkMyBike.Enums;
using System.ComponentModel.DataAnnotations;

namespace ParkMyBike.ViewModels
{
    public class BikeRackViewModel
    {
        public int RackId { get; set; }
        [Required]
        public int NumberOfRacks { get; set; }
        [Required]
        [RegularExpression(@"^[-]?([1-8]?\d(\.\d+)?|90(\.0+)?),\s*[-]?(180(\.0+)?|((1[0-7]\d)|([1-9]?\d))(\.\d+)?)$")]
        public string LatLong { get; set; }
        public string LocationDescription { get; set; }
        [Required]
        public RackStatus RackStatus { get; set; }
        [Required]
        public RackType RackType { get; set; }
    }
}
