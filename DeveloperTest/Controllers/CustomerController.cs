using System;
using Microsoft.AspNetCore.Mvc;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Models;
using System.Linq;

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
            var allowedTypes = new string[] { "Large", "Small" };
            if (!ModelState.IsValid)
            {
                return BadRequest("Name and Type fields are required and name must be minimum 5 characters");
            }
            if (!allowedTypes.Any(t => t != model.Name))
            {
                return BadRequest("Customer type should be either Large or Small");
            }

            var customer = customerService.CreateCustomer(model);

            return Created($"customer/{customer.CustomerId}", customer);
        }
    }
}