using Reviews.Domain.Models;
using Shared.Domain.Services.Communication;

namespace Reviews.Domain.Services.Communication
{
    public class ServiceReviewResponse : BaseResponse<ServiceReview>
    {
        //UNHAPPY
        public ServiceReviewResponse(string message) : base(message)
        {
        }
        //HAPPY
        public ServiceReviewResponse(ServiceReview resource) : base(resource)
        {
        }
    }
}