using AutoMapper;
using Atrium.Core.Models;
using Atrium.Core.DTOs.Reservations;

namespace Atrium.Core.Common.Mapping
{
    public class ReservationMappingProfile : Profile
    {
        public ReservationMappingProfile() 
        {
            CreateMap<CreateReservationDto, Reservation>();
            CreateMap<Reservation, ReservationDto>();
            CreateMap<UpdateReservationDto, Reservation>()
                .ForAllMembers(opts => opts.Condition((stc, dest, srcMember) =>
                    srcMember != null));
        }
    }
}
