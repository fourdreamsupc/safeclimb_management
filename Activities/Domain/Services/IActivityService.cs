using System.Collections.Generic;
using System.Threading.Tasks;
using Activities.Domain.Models;
using Activities.Domain.Services.Communication;

namespace Activities.Domain.Services
{
    public interface IActivityService
    {
        Task<IEnumerable<Activity>> ListAsync();
        Task<ActivityResponse> GetById(int id);
        Task<IEnumerable<Activity>> ListByServiceIdAsync(int serviceId);
        Task<ActivityResponse> SaveAsync(Activity activity);
        Task<ActivityResponse> UpdateAsync(int id, Activity activity);
        Task<ActivityResponse> DeleteAsync(int id);
    }
}