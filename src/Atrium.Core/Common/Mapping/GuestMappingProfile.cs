using AutoMapper;
using Atrium.Core.Models;
using Atrium.Core.DTOs.Guests;

namespace Atrium.Core.Common.Mapping
{
    public class GuestMappingProfile : Profile
    {
        public GuestMappingProfile() 
        {
            CreateMap<CreateGuestDto, Guest>();
            CreateMap<Guest, GuestDto>();
            CreateMap<UpdateGuestDto, Guest>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                    srcMember != null));
        }
    }
}
