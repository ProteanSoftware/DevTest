using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DeveloperTest.Enums;

namespace DeveloperTest.Database.Models;

public class Customer
{
    [Column("CustomerId")]
    public int Id { get; set; }

    [MinLength(5, ErrorMessage = "Minimum length for the Name is 5 characters.")]
    public string Name { get; set; }

    public CustomerTypeId CustomerTypeId { get; set; }

    public CustomerType CustomerType { get; set; }
}