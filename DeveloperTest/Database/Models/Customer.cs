using DeveloperTest.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeveloperTest.Database.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]        
        public CustomerTypeEnum Type { get; set; }
        [ForeignKey("Type")]
        public CustomerType CustomerType { get; set; }
    }
}
