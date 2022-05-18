using System;

namespace DeveloperTest.Database.Models
{
    public class Job
    {
        public int JobId { get; set; }

        public string Engineer { get; set; }

        public DateTime When { get; set; }

        //Nullable customer - jobs should be created with one, but existing jobs shouldn't crash out if they don't have one.
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; } 
    }
}
