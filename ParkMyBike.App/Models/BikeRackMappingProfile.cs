using AutoMapper;
using ParkMyBike.ViewModels;

namespace ParkMyBike.Models
{
    public class BikeRackMappingProfile : Profile
    {
        public BikeRackMappingProfile()
        {
            CreateMap<BikeRack, BikeRackViewModel>()
                .ForMember(r => r.RackId, ex => ex.MapFrom(r => r.Id))
                .ReverseMap();
        }
    }
}
