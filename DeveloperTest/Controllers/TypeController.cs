using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DeveloperTest.Controllers
{
    [ApiController, Route("[controller]")]
    public class TypeController : ControllerBase
    {
        private static readonly string[] Types = { "Large", "Small"};

        private readonly ILogger<TypeController> _logger;

        public TypeController(ILogger<TypeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Types;
        }
    }
}
