using System.Collections.Generic;
using System.Threading.Tasks;
using DeveloperTest.DTO.Job;

namespace DeveloperTest.Business.Interfaces
{
    public interface IJobService
    {
        Task<IEnumerable<JobDto>> GetJobsAsync();

        Task<JobDto> GetJobAsync(int jobId);

        Task<JobDto> CreateJobAsync(CreateJobDto job);
    }
}
