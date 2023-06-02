using Services.Domain.Models;
using Shared.Domain.Services.Communication;

namespace Services.Domain.Services.Communication
{
    public class ServiceResponse : BaseResponse<Service>
    {
        //UNHAPPY
        public ServiceResponse(string message) : base(message)
        {
        }
        //HAPPY
        public ServiceResponse(Service resource) : base(resource)
        {
        }
    }
}