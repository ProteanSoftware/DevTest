using DeveloperTest.Enums;

namespace DeveloperTest.DTO.Customer;

public record CreateCustomerDto(string Name, CustomerTypeId TypeId);