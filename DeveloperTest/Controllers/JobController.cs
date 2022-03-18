using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.DTO.Job;

namespace DeveloperTest.Controllers
{
    [ApiController, Route("[controller]")]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _jobService.GetJobsAsync());
        }

        [HttpGet("{id}", Name = "Job")]
        public async Task<IActionResult> Get(int id)
        {
            var job = await _jobService.GetJobAsync(id);

            if (job == null)
            {
                return NotFound();
            }

            return Ok(job);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateJobDto model)
        {
            if (model.When.Date < DateTime.Now.Date)
            {
                return BadRequest("Date cannot be in the past");
            }

            var createdJob = await _jobService.CreateJobAsync(model);

            return CreatedAtRoute("Job", new {createdJob.JobId}, createdJob);
        }
    }
}