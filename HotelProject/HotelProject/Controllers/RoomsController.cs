
using Microsoft.AspNetCore.Mvc;
using HotelBookingApi.Data;
using HotelBookingApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace HotelBookingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public RoomsController(AppDbContext db) { _db = db; }

        [HttpGet("byHotel/{hotelId}")]
        public async Task<IActionResult> GetByHotel(int hotelId)
        {
            var rooms = await _db.Rooms.Where(r => r.HotelId == hotelId).ToListAsync();
            return Ok(rooms);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(Room model)
        {
            _db.Rooms.Add(model);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var r = await _db.Rooms.Include(r => r.Hotel).FirstOrDefaultAsync(r => r.Id == id);
            if (r == null) return NotFound();
            return Ok(r);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Room update)
        {
            var r = await _db.Rooms.FindAsync(id);
            if (r == null) return NotFound();

            r.RoomNumber = update.RoomNumber;
            r.Type = update.Type;
            r.Price = update.Price;
            r.IsAvailable = update.IsAvailable;
            r.UpdatedAt = DateTime.UtcNow;

            await _db.SaveChangesAsync();
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var r = await _db.Rooms.FindAsync(id);
            if (r == null) return NotFound();
            _db.Rooms.Remove(r);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
