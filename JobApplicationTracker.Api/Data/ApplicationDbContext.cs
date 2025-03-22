using Microsoft.EntityFrameworkCore;
using JobApplicationTracker.Api.Models;

namespace JobApplicationTracker.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<JobApplication> JobApplications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobApplication>()
            .HasKey(j => j.Id);

            modelBuilder.Entity<JobApplication>().HasData(
                new JobApplication { Id = 1, CompanyName = "Datacom", Position = "Senior Software Engineer", Status = "Interview", DateApplied = DateTime.UtcNow.AddDays(-10) },
                new JobApplication { Id = 2, CompanyName = "Startup Inc", Position = "Full Stack Developer", Status = "Offer", DateApplied = DateTime.UtcNow.AddDays(-5) },
                new JobApplication { Id = 3, CompanyName = "Global Solutions", Position = "Backend Developer", Status = "Rejected", DateApplied = DateTime.UtcNow.AddDays(-15) }
            );
        }
    }
}