using DeveloperTest.Enums;

namespace DeveloperTest.DTO.Customer;

public record CustomerDto(int Id, string Name, CustomerTypeId CustomerTypeId);