using JobApplicationTracker.Api.Models;
namespace JobApplicationTracker.Api.Repositories
{
    public interface IJobApplicationRepository
    {
        Task<IEnumerable<JobApplication>> GetAllAsync();
        Task<JobApplication> GetByIdAsync(int id);
        Task<JobApplication> AddAsync(JobApplication application);
        Task<JobApplication> UpdateAsync(JobApplication application);
    }
}