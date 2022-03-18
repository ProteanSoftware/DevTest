using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.DTO.Job;

namespace DeveloperTest.Controllers
{
    [Route("api/jobs")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public async Task<IActionResult> GetJobs() => 
            Ok(await _jobService.GetJobsAsync());

        [HttpGet("{jobId:int}", Name = nameof(GetJob))]
        public async Task<IActionResult> GetJob(int jobId) => 
             Ok(await _jobService.GetJobAsync(jobId));


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateJobDto job)
        {
            if (job.When.Date < DateTime.Now.Date)
            {
                return BadRequest("Date cannot be in the past");
            }

            var createdJob = await _jobService.CreateJobAsync(job);

            return CreatedAtRoute(nameof(GetJob), new {createdJob.JobId}, createdJob);
        }
    }
}