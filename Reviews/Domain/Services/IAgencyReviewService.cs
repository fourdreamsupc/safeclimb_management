using System.Collections.Generic;
using System.Threading.Tasks;
using Reviews.Domain.Models;
using Reviews.Domain.Services.Communication;

namespace Reviews.Domain.Services
{
    public interface IAgencyReviewService
    {
        Task<IEnumerable<AgencyReview>> ListAsync();
        Task<IEnumerable<AgencyReview>> ListByAgencyIdAsync(int agencyId);
        Task<IEnumerable<AgencyReview>> ListByCustomerIdAsync(int customerId);
        Task<AgencyReviewResponse> GetByIdAsync(int id);
        Task<AgencyReviewResponse> SaveAsync(AgencyReview agencyReview);
        Task<AgencyReviewResponse> DeleteAsync(int id);
    }
}