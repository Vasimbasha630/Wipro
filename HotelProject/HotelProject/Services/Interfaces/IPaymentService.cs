
using HotelBookingApi.Models;

namespace HotelBookingApi.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<(bool Success, string? Error, Payment? Payment)> ProcessPaymentAsync(int bookingId, decimal amount, string currency = "INR");
    }
}
