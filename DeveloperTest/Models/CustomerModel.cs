using DeveloperTest.Enums;
using System.ComponentModel.DataAnnotations;

namespace DeveloperTest.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        [Required, MinLength(5)]
        public string Name { get; set; }
        [Required]
        public CustomerType CustomerType { get; set; }
    }
}
