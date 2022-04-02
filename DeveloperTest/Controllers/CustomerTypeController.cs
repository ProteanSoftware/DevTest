using DeveloperTest.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperTest.Controllers
{
    [ApiController, Route("[controller]")]
    public class CustomerTypeController : ControllerBase
    {
        private readonly ICustomerTypeService _customerTypeService;

        public CustomerTypeController(ICustomerTypeService customerTypeService)
        {
            _customerTypeService = customerTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken token)
        {
            var customerTypes = await _customerTypeService.GetCustomerTypesAsync(token);

            if (customerTypes is null)
                return NotFound();

            return Ok(customerTypes);
        }
    }
}