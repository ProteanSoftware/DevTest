using System;
using System.ComponentModel.DataAnnotations;

namespace DeveloperTest.Models
{
    public class BaseJobModel
    {
        public string Engineer { get; set; }

        public DateTime When { get; set; }
        [Required(ErrorMessage = "A customer id is required to create a new job.")]
        public int? CustomerId { get; set; }
    }
}
