using Reviews.Domain.Models;
using Reviews.Domain.Repositories;
using Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using Shared.Persistence.Contexts;
using System.Linq;

namespace Reviews.Persistence.Repositories
{
    public class ServiceReviewsRepository : BaseRepository, IServiceReviewRepository
    {
        public ServiceReviewsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ServiceReview>> ListAsync()
        {
            return await _context.ServiceReviews.ToListAsync();
        }

        public async Task<IEnumerable<ServiceReview>> ListByServiceId(int serviceId)
        {
            return await _context.ServiceReviews.Where(p => p.ServiceId == serviceId).ToListAsync();        }

        public async Task<IEnumerable<ServiceReview>> ListByCustomerId(int customerId)
        {
            return await _context.ServiceReviews.Where(p => p.CustomerId == customerId).ToListAsync();
        }

        public async Task AddAsync(ServiceReview serviceReview)
        {
            await _context.ServiceReviews.AddAsync(serviceReview);
        }

        public async Task<ServiceReview> FindByIdAsync(int id)
        {
            return await _context.ServiceReviews
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public void Remove(ServiceReview serviceReview)
        {
            _context.ServiceReviews.Remove(serviceReview);
        }
    }
}