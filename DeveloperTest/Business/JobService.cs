using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.DTO.Job;
using DeveloperTest.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DeveloperTest.Business
{
    public class JobService : IJobService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public JobService(
            ApplicationDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<JobDto>> GetJobsAsync() =>
            _mapper.Map<IEnumerable<JobDto>>(
                await _dbContext.Jobs.ToListAsync());

        public async Task<JobDto> GetJobAsync(int jobId)
        {
            var job = await _dbContext.Jobs.SingleOrDefaultAsync(x => x.JobId == jobId);

            if (job is null)
                throw new JobNotFoundException(jobId);

            return _mapper.Map<JobDto>(job);
        }

        public async Task<JobDto> CreateJobAsync(CreateJobDto job)
        {
            var addedJob = _mapper.Map<Job>(job);

            _dbContext.Jobs.Add(addedJob);

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<JobDto>(addedJob);
        }
    }
}
