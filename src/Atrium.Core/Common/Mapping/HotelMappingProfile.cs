using AutoMapper;
using Atrium.Core.Models;
using Atrium.Core.DTOs.Hotels;

namespace Atrium.Core.Common.Mapping
{
    public class HotelMappingProfile : Profile
    {
        public HotelMappingProfile() 
        {
            CreateMap<CreateHotelDto, Hotel>();
            CreateMap<Hotel, HotelDto>();
            CreateMap<UpdateHotelDto, Hotel>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                    srcMember != null));
        }
    }
}
