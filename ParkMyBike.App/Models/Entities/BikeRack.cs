using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using ParkMyBike.Resources.Enums;

namespace ParkMyBike.Models.Entities
{
    public class BikeRack
    {
        public int Id { get; set; }
        public int? NumberOfRacks { get; set; }
        [Required]
        [JsonProperty("position")]
        public Position Position { get; set; }
        public string LocationDescription { get; set; }
        [JsonProperty("rackType")]
        public RackType RackType { get; set; }
        public string ImagePath { get; set; }

        public BikeRack(int id, Position position, RackType rackType)
        {
            Id = id;
            Position = position;
            RackType = rackType;
        }

    }

}
