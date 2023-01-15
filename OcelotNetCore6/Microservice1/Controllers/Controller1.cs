using Microsoft.AspNetCore.Mvc;

namespace Microservice1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controller1 : ControllerBase
    {
        [Route("Method1")]
        [HttpGet]
        public async Task<IActionResult> Method1()
        {
            await Task.Delay(1);
            return Ok("Called Method1");
        }

        [Route("Method2")]
        [HttpGet]
        public async Task<IActionResult> Method2()
        {
            await Task.Delay(1);
            return Ok("Called Method2");
        }
    }
}