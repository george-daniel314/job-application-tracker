using JobApplicationTracker.Api.Models;

namespace JobApplicationTracker.Api.Services
{
    public interface IJobApplicationService
    {
        Task<IEnumerable<JobApplication>> GetAllApplicationsAsync();
        Task<JobApplication?> GetApplicationByIdAsync(int id);
        Task<JobApplication> CreateApplicationAsync(JobApplication application);
        Task<JobApplication> UpdateApplicationAsync(JobApplication application);
    }
}