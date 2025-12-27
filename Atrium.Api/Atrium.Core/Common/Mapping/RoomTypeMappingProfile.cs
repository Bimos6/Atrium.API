using AutoMapper;
using Atrium.Core.Models;
using Atrium.Core.DTOs.RoomTypes;

namespace Atrium.Core.Common.Mapping
{
    public class RoomTypeMappingProfile : Profile
    {
        public RoomTypeMappingProfile() 
        {
            CreateMap<CreateRoomTypeDto, RoomType>();
            CreateMap<RoomType, RoomTypeDto>();
            CreateMap<UpdateRoomTypeDto, RoomType>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                    srcMember != null));
        }
    }
}
