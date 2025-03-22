using FluentValidation;
using JobApplicationTracker.Api.Models;

namespace JobApplicationTracker.Api.Validators
{
    public class JobApplicationValidator : AbstractValidator<JobApplication>
    {
        public JobApplicationValidator()
        {
            RuleFor(j => j.CompanyName).NotEmpty().WithMessage("Company Name is required.");
            RuleFor(j => j.Position).NotEmpty().WithMessage("Position is required.");
            RuleFor(job => job.Status)
                .Must(status => new[] { "Interview", "Offer", "Rejected" }.Contains(status))
                .WithMessage("Status must be 'Interview', 'Offer', or 'Rejected'.");
            RuleFor(j => j.DateApplied).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Date cannot be in the future.");
        }
    }
}