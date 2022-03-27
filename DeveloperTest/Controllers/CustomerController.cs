using System;
using Microsoft.AspNetCore.Mvc;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Models;
using System.Threading.Tasks;

namespace DeveloperTest.Controllers
{
    [ApiController, Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public async ValueTask<IActionResult> Get()
        {
            return Ok(await customerService.GetCustomersAsync());
        }

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> Get(int id)
        {
            var customer = await customerService.GetCustomerAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public async ValueTask<IActionResult> Create(BaseCustomerModel model)
        {
            const int minCustomerNameLength = 5;
            if (model.Name.Length < 5)
            {
                return BadRequest($"Customer name cannot have less than {minCustomerNameLength} characters");
            }

            var customer = await customerService.CreateCustomerAsync(model);

            return Created($"customer/{customer.CustomerId}", customer);
        }
    }
}