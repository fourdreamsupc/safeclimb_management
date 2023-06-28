using Activities.Domain.Models;
using Activities.Domain.Repositories;
using Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Shared.Persistence.Contexts;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Activities.Persistence.Repositories
{
    public class ActivityRepository : BaseRepository, IActivityRepository
    {
        public ActivityRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Activity>> ListAsync()
        {
            return await _context.Activities.ToListAsync();
        }

        public async Task<IEnumerable<Activity>> ListById(int id)
        {
            return await _context.Activities.Where(p => p.Id == id).ToListAsync();
        }

        public async Task<IEnumerable<Activity>> ListByServiceId(int serviceId)
        {
            return await _context.Activities.Where(p => p.ServiceId == serviceId).ToListAsync();
        }

        public async Task<Activity> FindById(int id)
        {
            return await _context.Activities.FindAsync(id);
        }

        public async Task AddAsync(Activity activity)
        {
            await _context.Activities.AddAsync(activity);
        }

        public void Update(Activity activity)
        {
            _context.Activities.Update(activity);
        }

        public void Remove(Activity activity)
        {
            _context.Activities.Remove(activity);
        }
    }
}