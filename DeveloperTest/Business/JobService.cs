using System;
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
        private readonly ICustomerService customerService;

        public JobService(ApplicationDbContext context,
            ICustomerService customerService)
        {
            this.context = context;
            this.customerService = customerService;
        }

        public JobModel[] GetJobs()
        {
            return context.Jobs
                .Include(j => j.Customer)
                .Select(x => new JobModel
                {
                    JobId = x.JobId,
                    Engineer = x.Engineer,
                    When = x.When,
                    CustomerName = x.Customer.Name
                }).ToArray();
        }

        public JobModel GetJob(int jobId)
        {
            return context.Jobs
                .Include(c => c.Customer)
                .Where(x => x.JobId == jobId).Select(x => new JobModel
                {
                    JobId = x.JobId,
                    Engineer = x.Engineer,
                    CustomerId = x.CustomerId.Value,
                    CustomerName = x.Customer.Name,
                    When = x.When
                }).SingleOrDefault();
        }

        public JobModel CreateJob(BaseJobModel model)
        {
            var addedJob = context.Jobs.Add(new Job
            {
                Engineer = model.Engineer,
                CustomerId = model.CustomerId.HasValue 
                    ? model.CustomerId.Value : throw new ArgumentException($"{nameof(model.CustomerId)} cannot be null"),
                When = model.When
            });

            context.SaveChanges();

            return new JobModel
            {
                JobId = addedJob.Entity.JobId,
                Engineer = addedJob.Entity.Engineer,
                When = addedJob.Entity.When
            };
        }
    }
}
