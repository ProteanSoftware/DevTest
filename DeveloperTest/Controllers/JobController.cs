using Microsoft.AspNetCore.Mvc;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Models;

namespace DeveloperTest.Controllers
{
    [ApiController, Route("[controller]")]
    public class JobController : ControllerBase
    {
        private readonly IJobService jobService;

        public JobController(IJobService jobService)
        {
            this.jobService = jobService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(jobService.GetJobs());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var job = jobService.GetJob(id);

            if (job == null)
            {
                return NotFound();
            }

            return Ok(job);
        }

        [HttpPost]
        public IActionResult Create(BaseJobModel model)
        {
            var job = jobService.CreateJob(model);

            if (job is null)
                return BadRequest(new { error = "Unable to create job" });

            return Created($"{GetBaseUrl}/job/{job.JobId}", job);
        }
        private string GetBaseUrl()
        {
            return $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
        }
    }
}