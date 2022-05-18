using DeveloperTest.Business.Interfaces;
using DeveloperTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Get()
        {
            return Ok(customerService.GetCustomers());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = customerService.GetCustomer(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Create(BaseCustomerModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = customerService.CreateCustomer(model);
            return Created($"customer/{customer.CustomerId}", customer);
        }
    }
}
