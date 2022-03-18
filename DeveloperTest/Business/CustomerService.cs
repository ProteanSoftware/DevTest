using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.DTO.Customer;
using DeveloperTest.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DeveloperTest.Business;

public class CustomerService : ICustomerService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public CustomerService(
        ApplicationDbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CustomerDto>> GetCustomersAsync() =>
        _mapper.Map<IEnumerable<CustomerDto>>(
            await _dbContext.Customers.ToListAsync());

    public async Task<CustomerDto> GetCustomerAsync(int customerId)
    {
        var customer = await _dbContext.Customers.SingleOrDefaultAsync(x => x.Id == customerId);

        if (customer is null)
            throw new CustomerNotFoundException(customerId);
            
        return _mapper.Map<CustomerDto>(
            await _dbContext.Customers.SingleOrDefaultAsync(x => x.Id == customerId));
    }

    public async Task<IEnumerable<CustomerTypeDto>> GetCustomerTypesAsync() =>
        _mapper.Map<IEnumerable<CustomerTypeDto>>(
            await _dbContext.CustomerTypes.ToListAsync());

    public async Task<CustomerDto> CreateCustomerAsync(CreateCustomerDto customer)
    {
        var customerEntity = _mapper.Map<Customer>(customer);

        _dbContext.Customers.Add(customerEntity);

        await _dbContext.SaveChangesAsync();

        return _mapper.Map<CustomerDto>(customerEntity);
    }
}