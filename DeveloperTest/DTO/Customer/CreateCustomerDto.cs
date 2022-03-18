using System.ComponentModel.DataAnnotations;
using DeveloperTest.Enums;

namespace DeveloperTest.DTO.Customer;

public record CreateCustomerDto
{
    [Required(ErrorMessage = $"{nameof(Name)} is a required field.")]
    [MinLength(5, ErrorMessage = $"Minimum length for the {nameof(Name)} is 5 characters.")]
    public string Name { get; init; }

    [Required(ErrorMessage = $"{nameof(TypeId)} is a required field.")]
    [Range(1, byte.MaxValue, ErrorMessage = $"{nameof(TypeId)} contain incorrect value")]
    public CustomerTypeId TypeId { get; init; }
}

