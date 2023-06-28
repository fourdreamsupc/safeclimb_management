using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reviews.Domain.Models;

namespace Reviews.Domain.Repositories
{
    public interface IAgencyReviewRepository
    {
        Task<IEnumerable<AgencyReview>> ListAsync();
        Task<IEnumerable<AgencyReview>> ListByAgencyId(int agencyId);
        Task<IEnumerable<AgencyReview>> ListByCustomerId(int customerId);
        Task AddAsync(AgencyReview agencyReview);
        Task<AgencyReview> FindByIdAsync(int id);
        void Remove(AgencyReview agencyReview);
    }
}