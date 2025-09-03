
using HotelBookingApi.Data;
using HotelBookingApi.Models;
using HotelBookingApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApi.Services
{
    public class BookingService : IBookingService
    {
        private readonly AppDbContext _db;
        public BookingService(AppDbContext db) { _db = db; }

        public async Task<(bool Success, string? Error, Booking? Booking)> CreateBookingAsync(int userId, int roomId, DateTime checkIn, DateTime checkOut)
        {
            if (checkOut <= checkIn) return (false, "Checkout must be after checkin", null);

            var room = await _db.Rooms.FindAsync(roomId);
            if (room == null) return (false, "Room not found", null);

            var hasOverlap = await _db.Bookings.AnyAsync(b =>
                b.RoomId == roomId &&
                b.Status != "Cancelled" &&
                !(b.CheckOutDate <= checkIn || b.CheckInDate >= checkOut)
            );

            if (hasOverlap) return (false, "Room is already booked for the selected dates", null);

            var days = (checkOut.Date - checkIn.Date).Days;
            if (days <= 0) return (false, "Invalid dates", null);

            var amount = days * room.Price;

            var booking = new Booking
            {
                RoomId = roomId,
                UserId = userId,
                CheckInDate = checkIn,
                CheckOutDate = checkOut,
                TotalAmount = amount,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _db.Bookings.Add(booking);
            await _db.SaveChangesAsync();

            return (true, null, booking);
        }

        public async Task<IEnumerable<Booking>> GetUserBookingsAsync(int userId)
        {
            return await _db.Bookings.Include(b => b.Room).ThenInclude(r => r.Hotel)
                .Where(b => b.UserId == userId)
                .OrderByDescending(b => b.CreatedAt)
                .ToListAsync();
        }

        public async Task<bool> CancelBookingAsync(int bookingId, int userId)
        {
            var b = await _db.Bookings.FindAsync(bookingId);
            if (b == null || b.UserId != userId) return false;
            b.Status = "Cancelled";
            b.UpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
