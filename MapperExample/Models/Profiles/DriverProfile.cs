using AutoMapper;
using MapperExample.Models.DTO.OutGoing;

namespace MapperExample.Models.Profiles
{
    public class DriverProfile:Profile
    {
        public DriverProfile()
        {
            CreateMap<DriverForCreation, Driver>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src => new Guid()))
                .ForMember(dest => dest.FirstName,
                    opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.Lastname,
                    opt => opt.MapFrom(src => src.Lastname))
                .ForMember(dest => dest.DriverNumber,
                    opt => opt.MapFrom(src => src.DriverNumber))
                .ForMember(dest => dest.DateAdded,
                    opt => opt.MapFrom(src =>  DateTime.Now));

        }
    }
}
