using HiredServices.Domain.Models;
using Shared.Domain.Services.Communication;

namespace HiredServices.Domain.Services.Communication
{
    public class HideServiceResponse : BaseResponse<HiredService>
    {
        public HideServiceResponse(string message) : base(message) {}

        public HideServiceResponse(HiredService resource) : base(resource) {}
    }
}