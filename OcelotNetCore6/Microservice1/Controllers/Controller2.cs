using Microsoft.AspNetCore.Mvc;

namespace Microservice1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controller2 : ControllerBase
    {
        [Route("Method3")]
        [HttpGet]
        public async Task<IActionResult> Method3()
        {
            await Task.Delay(1);
            return Ok("Called Method3");
        }

        [Route("Method4")]
        [HttpGet]
        public async Task<IActionResult> Method4()
        {
            await Task.Delay(1);
            return Ok("Called Method4");
        }
    }
}