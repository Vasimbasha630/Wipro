
//using Microsoft.AspNetCore.Mvc;
//using HotelBookingApi.Services.Interfaces;
//using Microsoft.AspNetCore.Authorization;
//using System.Security.Claims;

//namespace HotelBookingApi.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    [Authorize]
//    public class BookingsController : ControllerBase
//    {
//        private readonly IBookingService _bookingService;

//        public BookingsController(IBookingService bookingService)
//        {
//            _bookingService = bookingService;
//        }

//        private int GetUserId() => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

//        [HttpPost]
//        public async Task<IActionResult> Create([FromBody] CreateBookingRequest request)
//        {
//            var userId = GetUserId();
//            var (success, error, booking) = await _bookingService.CreateBookingAsync(userId, request.RoomId, request.CheckInDate, request.CheckOutDate);
//            if (!success) return BadRequest(new { error });
//            return Ok(booking);
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetMine()
//        {
//            var userId = GetUserId();
//            var list = await _bookingService.GetUserBookingsAsync(userId);
//            return Ok(list);
//        }

//        [HttpPost("{id}/cancel")]
//        public async Task<IActionResult> Cancel(int id)
//        {
//            var userId = GetUserId();
//            var ok = await _bookingService.CancelBookingAsync(id, userId);
//            if (!ok) return BadRequest(new { error = "Cannot cancel booking" });
//            return Ok();
//        }
//    }

//    public class CreateBookingRequest
//    {
//        public int RoomId { get; set; }
//        public DateTime CheckInDate { get; set; }
//        public DateTime CheckOutDate { get; set; }
//    }
//}
using Microsoft.AspNetCore.Mvc;
using HotelBookingApi.Services.Interfaces;
using HotelBookingApi.DTOs;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace HotelBookingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        private int GetUserId() => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookingRequest request)
        {
            var userId = GetUserId();
            var (success, error, bookingDto) = await _bookingService.CreateBookingAsync(userId, request.RoomId, request.CheckInDate, request.CheckOutDate);
            if (!success) return BadRequest(new { error });
            return Ok(bookingDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetMine()
        {
            var userId = GetUserId();
            var bookings = await _bookingService.GetUserBookingsAsync(userId);
            // bookings should already be BookingDto
            return Ok(bookings);
        }

        [HttpPost("{id}/cancel")]
        public async Task<IActionResult> Cancel(int id)
        {
            var userId = GetUserId();
            var ok = await _bookingService.CancelBookingAsync(id, userId);
            if (!ok) return BadRequest(new { error = "Cannot cancel booking" });
            return Ok();
        }
    }

    public class CreateBookingRequest
    {
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }
}

