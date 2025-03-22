using JobApplicationTracker.Api.Models;
using JobApplicationTracker.Api.Repositories;
using JobApplicationTracker.Api.Exceptions;

namespace JobApplicationTracker.Api.Services
{
    public class JobApplicationService : IJobApplicationService
    {
        private readonly IJobApplicationRepository _repository;

        public JobApplicationService(IJobApplicationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<JobApplication>> GetAllApplicationsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<JobApplication?> GetApplicationByIdAsync(int id)
        {
            var application = await _repository.GetByIdAsync(id);
            if (application == null)
            {
                throw new NotFoundException($"Job application with ID {id} was not found.");
            }
            return application;
        }

        public async Task<JobApplication> CreateApplicationAsync(JobApplication application)
        {
            if (application == null)
            {
                throw new CustomValidationException("Invalid job application data.");
            }

            return await _repository.AddAsync(application);
        }

        public async Task<JobApplication> UpdateApplicationAsync(JobApplication application)
        {
            var existingApplication = await _repository.GetByIdAsync(application.Id);
            if (existingApplication == null)
            {
                throw new NotFoundException($"Cannot update. Job application with ID {application.Id} not found.");
            }

            return await _repository.UpdateAsync(application);
        }
    }
}