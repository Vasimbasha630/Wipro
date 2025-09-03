
using Microsoft.AspNetCore.Mvc;
using HotelBookingApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace HotelBookingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _payments;

        public PaymentsController(IPaymentService payments)
        {
            _payments = payments;
        }

        [HttpPost("process")]
        public async Task<IActionResult> Process([FromBody] ProcessPaymentRequest request)
        {
            var (success, error, payment) = await _payments.ProcessPaymentAsync(request.BookingId, request.Amount, request.Currency);
            if (!success) return BadRequest(new { error });
            return Ok(payment);
        }
    }

    public class ProcessPaymentRequest
    {
        public int BookingId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "INR";
    }
}
