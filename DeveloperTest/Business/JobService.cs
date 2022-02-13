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

        public JobService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public JobModel[] GetJobs()
        {
            var jbs = (from j in context.Jobs
                     from c in context.Customers
                        .Where(c => c.CustomerId == j.CustomerId)
                        .DefaultIfEmpty()
                     select new JobModel
                        {
                            JobId = j.JobId,
                            Engineer = j.Engineer,
                            When = j.When,
                            CustName = c.CustomerName
                        }).ToArray();

            return jbs;
        }

        public JobModel GetJob(int jobId)
        {
            var jb = (from j in context.Jobs.Where(x => x.JobId == jobId)
                      from c in context.Customers
                          .Where(c => c.CustomerId == j.CustomerId)
                          .DefaultIfEmpty()
                       select new JobModel
                       {
                           JobId = j.JobId,
                           Engineer = j.Engineer,
                           When = j.When,
                           CustName = c.CustomerName,
                             CustType = c.Type
                       }).SingleOrDefault();

            return jb;
        }

        public JobModel CreateJob(BaseJobModel model)
        {
            var addedJob = context.Jobs.Add(new Job
            {
                Engineer = model.Engineer,
                When = model.When,
                 CustomerId = model.CustID
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
