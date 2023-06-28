using AutoMapper;
using Activities.Resources;
using Reviews.Domain.Models;
using Reviews.Resources;
using Activities.Domain.Models;

namespace Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveActivityResource, Activity>();
            CreateMap<SaveAgencyReviewResource, AgencyReview>();
            CreateMap<SaveServiceReviewResource, ServiceReview>();
        }
    }
}