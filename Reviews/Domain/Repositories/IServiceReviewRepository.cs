﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Reviews.Domain.Models;

namespace Reviews.Domain.Repositories
{
    public interface IServiceReviewRepository
    {
        Task<IEnumerable<ServiceReview>> ListAsync();
        Task<IEnumerable<ServiceReview>> ListByServiceId(int serviceId);
        Task<IEnumerable<ServiceReview>> ListByCustomerId(int customerId);
        Task<ServiceReview> FindByIdAsync(int id);
        Task AddAsync(ServiceReview serviceReview);
        void Remove(ServiceReview serviceReview);
    }
}