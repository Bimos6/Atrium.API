using AutoMapper;
using Atrium.Core.Models;
using Atrium.Core.DTOs.Rooms;

namespace Atrium.Core.Common.Mapping
{
    public class RoomMappingProfile : Profile
    {
        public RoomMappingProfile() 
        {
            CreateMap<CreateRoomDto, Room>();
            CreateMap<Room, RoomDto>();
            CreateMap<UpdateRoomDto, RoomDto>().
                ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                    srcMember != null));
        }
    }
}
