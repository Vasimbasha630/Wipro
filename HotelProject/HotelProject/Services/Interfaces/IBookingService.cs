
using HotelBookingApi.Models;

namespace HotelBookingApi.Services.Interfaces
{
    public interface IBookingService
    {
        Task<(bool Success, string? Error, Booking? Booking)> CreateBookingAsync(int userId, int roomId, DateTime checkIn, DateTime checkOut);
        Task<IEnumerable<Booking>> GetUserBookingsAsync(int userId);
        Task<bool> CancelBookingAsync(int bookingId, int userId);
    }
}
