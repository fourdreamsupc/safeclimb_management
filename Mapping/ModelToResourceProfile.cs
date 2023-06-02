using AutoMapper;
using HiredServices.Domain.Models;
using HiredServices.Resources;
using Services.Domain.Models;
using Services.Services.Resources;

namespace Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Service, ServiceResource>();
            CreateMap<HiredService, HiredServiceResource>();  
        }
    }
}