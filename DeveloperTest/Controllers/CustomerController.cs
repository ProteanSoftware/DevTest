using System.Threading.Tasks;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.DTO.Customer;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperTest.Controllers;

[Route("api/customers")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomers() =>
        Ok(await _customerService.GetCustomersAsync());

    [HttpGet("{id:int}", Name = "Customer")]
    public async Task<IActionResult> GetCustomer(int id) =>
        Ok(await _customerService.GetCustomerAsync(id));

    [HttpGet, Route("types")]
    public async Task<IActionResult> GetCustomerTypes() =>
        Ok(await _customerService.GetCustomerTypesAsync());

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDto customer)
    {
        var createdCustomer = await _customerService.CreateCustomerAsync(customer);

        return CreatedAtRoute("Customer", new {createdCustomer.Id}, createdCustomer);
    }
    

}