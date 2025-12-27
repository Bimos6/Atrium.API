using AutoMapper;
using Atrium.Core.Models;
using Atrium.Core.DTOs.Services;

namespace Atrium.Core.Common.Mapping
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile() 
        {
            CreateMap<CreateServiceDto, Service>();
            CreateMap<Service, ServiceDto>();
            CreateMap<UpdateServiceDto, Service>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                    srcMember != null));
        }
    }
}
