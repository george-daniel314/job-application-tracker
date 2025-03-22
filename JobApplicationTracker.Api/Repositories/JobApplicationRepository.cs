using JobApplicationTracker.Api.Data;
using JobApplicationTracker.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationTracker.Api.Repositories
{
    public class JobApplicationRepository : IJobApplicationRepository
    {
        private readonly ApplicationDbContext _context;

        public JobApplicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<JobApplication>> GetAllAsync()
        {
            return await _context.JobApplications.ToListAsync();
        }

        public async Task<JobApplication> GetByIdAsync(int id)
        {
            return await _context.JobApplications.AsNoTracking().FirstOrDefaultAsync(j => j.Id == id);
        }

        public async Task<JobApplication> AddAsync(JobApplication application)
        {
            await _context.JobApplications.AddAsync(application);
            await _context.SaveChangesAsync();
            return application;
        }

        public async Task<JobApplication> UpdateAsync(JobApplication application)
        {
            _context.Entry(application).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return application;

        }
    }
}