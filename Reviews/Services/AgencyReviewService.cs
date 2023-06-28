using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reviews.Domain.Models;
using Reviews.Domain.Repositories;
using Reviews.Domain.Services;
using Reviews.Domain.Services.Communication;
using Shared.Domain.Repositories;

namespace Reviews.Services
{
    public class AgencyReviewService : IAgencyReviewService
    {
        private readonly IAgencyReviewRepository _agencyReviewRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AgencyReviewService(IAgencyReviewRepository agencyReviewRepository, IUnitOfWork unitOfWork)
        {
            _agencyReviewRepository = agencyReviewRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<AgencyReview>> ListAsync()
        {
            return await _agencyReviewRepository.ListAsync();
        }

        public async Task<IEnumerable<AgencyReview>> ListByAgencyIdAsync(int agencyId)
        {
            return await _agencyReviewRepository.ListByAgencyId(agencyId);
        }

        public async Task<IEnumerable<AgencyReview>> ListByCustomerIdAsync(int customerId)
        {
            return await _agencyReviewRepository.ListByCustomerId(customerId);
        }

        public async Task<AgencyReviewResponse> GetByIdAsync(int id)
        {
            var existingAgencyReview = _agencyReviewRepository.FindByIdAsync(id);
            if (existingAgencyReview.Result == null)
                return new AgencyReviewResponse("The agency review does not exist.");
            
            return new AgencyReviewResponse(existingAgencyReview.Result);
        }

        public async Task<AgencyReviewResponse> SaveAsync(AgencyReview agencyReview)
        {
            // var existingCustomer = await _customerRepository.FindByIdAsync(agencyReview.CustomerId);
            // if (existingCustomer == null)
            //     return new AgencyReviewResponse("Customer does not exist.");
            // var exitingAgency =  await _agencyRepository.FindByIdAsync(agencyReview.AgencyId);
            // if (exitingAgency == null)
            //     return new AgencyReviewResponse("Agency does not exist.");
            try
            {
                await _agencyReviewRepository.AddAsync(agencyReview);
                await _unitOfWork.CompleteAsync();

                return new AgencyReviewResponse(agencyReview);
            }
            catch (Exception e)
            {
                return new AgencyReviewResponse($"An error occurred while saving the agency review: {e.Message}");
            }
        }

        public async Task<AgencyReviewResponse> DeleteAsync(int id)
        {
            //Validate AgencyReview
            var existingAgencyReview = await _agencyReviewRepository.FindByIdAsync(id);

            if (existingAgencyReview == null)
                return new AgencyReviewResponse("Agency review not found.");

            try
            {
                _agencyReviewRepository.Remove(existingAgencyReview);
                await _unitOfWork.CompleteAsync();

                return new AgencyReviewResponse(existingAgencyReview);
            }
            catch (Exception e)
            {
                return new AgencyReviewResponse($"An error occurred while deleting the agency review: {e.Message}");
            }
        }
    }
}