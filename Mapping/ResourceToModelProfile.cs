using AutoMapper;
using Services.Resources;
using HiredServices.Resources;
using HiredServices.Domain.Models;
using Services.Domain.Models;

namespace Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveServiceResource, Service>();
            CreateMap<SaveHiredServiceResource, HiredService>();
        }
    }
}