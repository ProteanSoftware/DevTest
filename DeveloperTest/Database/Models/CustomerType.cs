using DeveloperTest.Enums;
using System.ComponentModel.DataAnnotations;

namespace DeveloperTest.Database.Models
{
    public class CustomerType
    {
        [Key]
        public CustomerTypeEnum Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
