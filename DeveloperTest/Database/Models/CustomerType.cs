using System.ComponentModel.DataAnnotations.Schema;
using DeveloperTest.Enums;

namespace DeveloperTest.Database.Models;

public class CustomerType
{
    [Column("CustomerTypeId")]
    public CustomerTypeId Id { get; set; }

    public string Name { get; set; }
}