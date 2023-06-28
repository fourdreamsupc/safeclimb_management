using Reviews.Domain.Models;
using Shared.Domain.Services.Communication;

namespace Reviews.Domain.Services.Communication
{
    public class AgencyReviewResponse : BaseResponse<AgencyReview>
    {
        //UNHAPPY
        public AgencyReviewResponse(string message) : base(message)
        {
        }
        //HAPPY
        public AgencyReviewResponse(AgencyReview resource) : base(resource)
        {
        }
    }
}