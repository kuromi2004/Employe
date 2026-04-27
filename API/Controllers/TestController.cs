using Microsoft.AspNetCore.Mvc;

namespace Employees.API.Controllers
{
    
        [ApiController]
        [Route("api/test")]
        public class TestController : ControllerBase
        {
            [HttpGet]
            public IActionResult Get() => Ok("Funciona");
        }
    }

