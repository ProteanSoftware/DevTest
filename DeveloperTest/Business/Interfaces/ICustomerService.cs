using System.Collections.Generic;
using System.Threading.Tasks;
using DeveloperTest.DTO.Customer;

namespace DeveloperTest.Business.Interfaces;

public interface ICustomerService
{
    Task<IEnumerable<CustomerDto>> GetCustomersAsync();

    Task<CustomerDto> GetCustomerAsync(int customerId);

    Task<IEnumerable<CustomerTypeDto>> GetCustomerTypesAsync();

    Task<CustomerDto> CreateCustomerAsync(CreateCustomerDto customer);
}