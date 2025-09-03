
using Microsoft.AspNetCore.Mvc;
using HotelBookingApi.Services.Interfaces;
using HotelBookingApi.DTOs.Auth;

namespace HotelBookingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;
        public AuthController(IAuthService auth) { _auth = auth; }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var (success, error) = await _auth.RegisterAsync(dto);
            if (!success) return BadRequest(new { error });
            return Ok(new { message = "Registered" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var (success, token, error) = await _auth.LoginAsync(dto);
            if (!success) return Unauthorized(new { error });
            return Ok(new { token });
        }
    }
}
