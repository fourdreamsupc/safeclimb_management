using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Activities.Domain.Models;
using Activities.Domain.Repositories;
using Activities.Domain.Services;
using Activities.Domain.Services.Communication;
using Shared.Domain.Repositories;

namespace Activities.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IActivityRepository _activityRepository;

        public ActivityService(IUnitOfWork unitOfWork, IActivityRepository activityRepository)
        {
            _unitOfWork = unitOfWork;
            _activityRepository = activityRepository;
        }

        public async Task<IEnumerable<Activity>> ListAsync()
        {
            return await _activityRepository.ListAsync();
        }

        public async Task<ActivityResponse> GetById(int id)
        {
            var existingActivity = _activityRepository.FindById(id);
            if (existingActivity.Result == null)
                return new ActivityResponse("The activity does not exist.");
            
            return new ActivityResponse(existingActivity.Result);
        }

        public async Task<IEnumerable<Activity>> ListByServiceIdAsync(int serviceId)
        {
            return await _activityRepository.ListByServiceId(serviceId);
        }

        public async Task<ActivityResponse> SaveAsync(Activity activity)
        {
            try
            {
                await _activityRepository.AddAsync(activity);
                await _unitOfWork.CompleteAsync();
                return new ActivityResponse(activity);
            }
            catch (Exception e)
            {
                return new ActivityResponse($"An error occurred while saving the activity: {e.Message}");
            }
        }

        public async Task<ActivityResponse> UpdateAsync(int id, Activity activity)
        {
            var existingActivity = await _activityRepository.FindById(id);
            if (existingActivity == null)
                return new ActivityResponse("Activity not found");
            existingActivity.Name = activity.Name;
            existingActivity.Description = activity.Description;
            try
            {
                _activityRepository.Update(existingActivity);
                await _unitOfWork.CompleteAsync();
                return new ActivityResponse(existingActivity);
            }
            catch (Exception e)
            {
                return new ActivityResponse($"An error occurred while updating the Activity: {e.Message}");
            }
        }

        public async Task<ActivityResponse> DeleteAsync(int id)
        {
            var existingActivity = await _activityRepository.FindById(id);
            if (existingActivity == null)
                return new ActivityResponse("Activity not found");
            try
            {
                _activityRepository.Remove(existingActivity);
                await _unitOfWork.CompleteAsync();
                return new ActivityResponse(existingActivity);
            }
            catch (Exception e)
            {
                return new ActivityResponse($"An error occurred while deleting the Activity: {e.Message}");
            }
        }
    }
}