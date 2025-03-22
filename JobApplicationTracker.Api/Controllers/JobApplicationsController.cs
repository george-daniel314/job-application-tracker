using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JobApplicationTracker.Api.Models;
using JobApplicationTracker.Api.Services;

namespace JobApplicationTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationsController : ControllerBase
    {
        private readonly IJobApplicationService _jobApplicationService;

        public JobApplicationsController(IJobApplicationService service)
        {
            _jobApplicationService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _jobApplicationService.GetAllApplicationsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var application = await _jobApplicationService.GetApplicationByIdAsync(id);
            if (application == null)
                return NotFound("Job application not found.");
            return Ok(application);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] JobApplication application)
        {
            await _jobApplicationService.CreateApplicationAsync(application);
            return CreatedAtAction(nameof(GetById), new { id = application.Id }, application);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] JobApplication application)
        {
            if (id != application.Id)
                return BadRequest("ID mismatch.");
            await _jobApplicationService.UpdateApplicationAsync(application);
            return NoContent();
        }
    }
}
