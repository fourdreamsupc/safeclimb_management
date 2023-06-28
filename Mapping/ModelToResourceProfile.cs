using Activities.Domain.Models;
using Activities.Resources;
using AutoMapper;
using Reviews.Domain.Models;
using Reviews.Resources;

namespace Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Activity, ActivityResource>();
            CreateMap<AgencyReview, AgencyReviewResource>();
            CreateMap<ServiceReview, ServiceReviewResource>();
        }
    }
}