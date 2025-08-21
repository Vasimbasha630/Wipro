using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jwtEx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeProtectedController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProtectedData()
        {
            return Ok(new { message = "This is protected data" });
        }
    }
}
