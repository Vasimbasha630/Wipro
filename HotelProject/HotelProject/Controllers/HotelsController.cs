using HotelBookingApi.Data;
using HotelBookingApi.DTOs;
using HotelBookingApi.Models;
using HotelProject.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public HotelsController(AppDbContext db) { _db = db; }

        // ✅ Get All Hotels (with Rooms)
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? city = null)
        {
            var q = _db.Hotels.AsQueryable();
            if (!string.IsNullOrWhiteSpace(city))
                q = q.Where(h => h.City != null && h.City.Contains(city));

            var list = await q.Include(h => h.Rooms).ToListAsync();

            var result = list.Select(h => new HotelDto
            {
                Id = h.Id,
                Name = h.Name,
                Address = h.Address,
                City = h.City,
                Description = h.Description
            }).ToList();

            return Ok(result);
        }

        // ✅ Create Hotel (Admin only)
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateHotelDto dto)
        {
            var hotel = new Hotel
            {
                Name = dto.Name,
                Address = dto.Address,
                City = dto.City,
                Description = dto.Description,
                Rooms = dto.Rooms?.Select(r => new Room
                {
                    RoomNumber = r.RoomNumber,
                    Type = r.Type,
                    Price = r.Price,
                    IsAvailable = r.IsAvailable
                }).ToList() ?? new List<Room>()
            };

            _db.Hotels.Add(hotel);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = hotel.Id }, new HotelDto
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Address = hotel.Address,
                City = hotel.City,
                Description = hotel.Description
            });
        }

        // ✅ Get Hotel by ID (with Rooms)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var h = await _db.Hotels.Include(x => x.Rooms).FirstOrDefaultAsync(x => x.Id == id);
            if (h == null) return NotFound();

            var dto = new HotelDto
            {
                Id = h.Id,
                Name = h.Name,
                Address = h.Address,
                City = h.City,
                Description = h.Description
            };

            return Ok(dto);
        }

        // ✅ Update Hotel (Admin only)
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateHotelDto dto)
        {
            var h = await _db.Hotels.Include(x => x.Rooms).FirstOrDefaultAsync(x => x.Id == id);
            if (h == null) return NotFound();

            h.Name = dto.Name;
            h.Address = dto.Address;
            h.City = dto.City;
            h.Description = dto.Description;

            // (optional) Update rooms if provided
            if (dto.Rooms != null && dto.Rooms.Count > 0)
            {
                _db.Rooms.RemoveRange(h.Rooms); // clear old rooms
                h.Rooms = dto.Rooms.Select(r => new Room
                {
                    RoomNumber = r.RoomNumber,
                    Type = r.Type,
                    Price = r.Price,
                    IsAvailable = r.IsAvailable
                }).ToList();
            }

            await _db.SaveChangesAsync();
            return NoContent();
        }

        // ✅ Delete Hotel (Admin only)
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var h = await _db.Hotels.FindAsync(id);
            if (h == null) return NotFound();

            _db.Hotels.Remove(h);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
