using Atrium.Core.Common.Mapping;
using Atrium.Core.DTOs.Guests;
using Atrium.Core.DTOs.Hotels;
using Atrium.Core.DTOs.Reservations;
using Atrium.Core.DTOs.Rooms;
using Atrium.Core.DTOs.RoomTypes;
using Atrium.Core.DTOs.Services;
using Atrium.Core.Interfaces;
using Atrium.Core.Services;
using Atrium.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Atrium.Core.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(GuestMappingProfile).Assembly);
            services.AddAutoMapper(typeof(HotelMappingProfile).Assembly);
            services.AddAutoMapper(typeof(ReservationMappingProfile).Assembly);
            services.AddAutoMapper(typeof(RoomMappingProfile).Assembly);
            services.AddAutoMapper(typeof(RoomTypeMappingProfile).Assembly);
            services.AddAutoMapper(typeof(ServiceMappingProfile).Assembly);

            services.AddScoped<IValidator<CreateGuestDto>, CreateGuestDtoValidator>();
            services.AddScoped<IValidator<UpdateGuestDto>, UpdateGuestDtoValidator>();

            services.AddScoped<IValidator<CreateHotelDto>, CreateHotelDtoValidator>();
            services.AddScoped<IValidator<UpdateHotelDto>, UpdateHotelDtoValidator>();

            services.AddScoped<IValidator<CreateReservationDto>, CreateReservationDtoValidator>();
            services.AddScoped<IValidator<UpdateReservationDto>, UpdateReservationDtoValidator>();

            services.AddScoped<IValidator<CreateRoomTypeDto>, CreateRoomTypeDtoValidator>();
            services.AddScoped<IValidator<UpdateRoomTypeDto>, UpdateRoomTypeDtoValidator>();

            services.AddScoped<IValidator<CreateRoomDto>, CreateRoomDtoValidator>();
            services.AddScoped<IValidator<UpdateRoomDto>, UpdateRoomDtoValidator>();

            services.AddScoped<IValidator<CreateServiceDto>, CreateServiceDtoValidator>();
            services.AddScoped<IValidator<UpdateServiceDto>, UpdateServiceDtoValidator>();

            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IRoomTypeService, RoomTypeService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IGuestService, GuestService>();
            services.AddScoped<IReservationService, ReservationService>();

            return services;
        }
    }
}
