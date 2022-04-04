using DeveloperTest.Business.Interfaces;
using DeveloperTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperTest.Controllers
{
    [ApiController, Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken token)
        {
            var customers = await _customerService.GetCustomersAsync(token);

            if (customers is null)            
                return NotFound();
            
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]int id, CancellationToken token)
        {
            var customers = await _customerService.GetCustomerAsync(id, token);

            if (customers is null)
                return NotFound();

            return Ok(customers);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BaseCustomerModel model, CancellationToken token)
        {
            var created = await _customerService.CreateCustomerAsync(model, token);

            if (created is null)
                return BadRequest(new { error = "Unable to create customer" });

            return Created($"{GetBaseUrl()}/customer/{created.Id}", created);
        }

        //Added for manual testing purposes
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
        {
            var deleted = await _customerService.DeleteCustomer(id, token);

            if (deleted)            
               return NoContent();
            
            return NotFound();
        }

        private string GetBaseUrl() 
        {
            return $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
        }
    }
}
