using DeveloperTest.Enums;
using System.ComponentModel.DataAnnotations;

namespace DeveloperTest.Models
{
    public class BaseCustomerModel
    {
        [Required, MinLength(5, ErrorMessage = "Name must be at least 5 characters in length.")]
        public string Name { get; set; }
        [EnumDataType(typeof(CustomerType), ErrorMessage = "Invalid enum value.")]
        public CustomerType CustomerType { get; set; }
    }
}
