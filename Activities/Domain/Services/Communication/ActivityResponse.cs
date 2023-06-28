using Activities.Domain.Models;
using Shared.Domain.Services.Communication;

namespace Activities.Domain.Services.Communication
{
    public class ActivityResponse : BaseResponse<Activity>
    {
        //UNHAPPY
        public ActivityResponse(string message) : base(message)
        {
            
        }
        //HAPPY
        public ActivityResponse(Activity resource) : base(resource)
        {
            
        }
    }
}