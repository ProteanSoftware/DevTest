using System.ComponentModel.DataAnnotations;

namespace DeveloperTest.Models
{
    public class BaseCustomerModel
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }
    }
}
