using System.Linq;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Models;
using Microsoft.EntityFrameworkCore;

namespace DeveloperTest.Business
{
    public class JobService : IJobService
    {
        private readonly ApplicationDbContext context;
        private readonly string unknown = "Unknown";

        public JobService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public JobModel[] GetJobs()
        {
            return context.Jobs.Include(x => x.Customer).Select(x => new JobModel
            {
                JobId = x.JobId,
                Engineer = x.Engineer,
                When = x.When,
                CustomerName = x.Customer.Name ?? unknown
            }).ToArray();
        }

        public JobModel GetJob(int jobId)
        {
            var x = context.Jobs.Include(x => x.Customer).FirstOrDefault(x => x.JobId == jobId);
            return context.Jobs.Where(x => x.JobId == jobId).Select(x => new JobModel
            {
                JobId = x.JobId,
                Engineer = x.Engineer,
                When = x.When,
                CustomerName = x.Customer.Name ?? unknown,
                CustomerType = x.Customer.Type.ToString()
            }).SingleOrDefault();
        }

        public JobModel CreateJob(BaseJobModel model)
        {
            var addedJob = context.Jobs.Add(new Job
            {
                Engineer = model.Engineer,
                When = model.When,
                CustomerId = model.CustomerId
            });

            context.SaveChanges();
            var job = context.Jobs.Include(x => x.Customer).FirstOrDefault(x => x.JobId == addedJob.Entity.JobId);

            return new JobModel
            {
                JobId = job.JobId,
                Engineer = job.Engineer,
                When = job.When,
                CustomerName = job.Customer.Name ?? unknown
            };
        }
    }
}
