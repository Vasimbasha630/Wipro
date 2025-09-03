
using HotelBookingApi.Data;
using HotelBookingApi.Models;
using HotelBookingApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApi.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly AppDbContext _db;
        public PaymentService(AppDbContext db) { _db = db; }

        public async Task<(bool Success, string? Error, Payment? Payment)> ProcessPaymentAsync(int bookingId, decimal amount, string currency = "INR")
        {
            var booking = await _db.Bookings.FindAsync(bookingId);
            if (booking == null) return (false, "Booking not found", null);
            if (booking.TotalAmount != amount) return (false, "Amount mismatch", null);

            var payment = new Payment
            {
                BookingId = bookingId,
                Amount = amount,
                Currency = currency,
                PaymentProvider = "MockGateway",
                PaymentStatus = "Completed",
                TransactionRef = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _db.Payments.Add(payment);
            booking.Status = "Confirmed";
            booking.UpdatedAt = DateTime.UtcNow;

            await _db.SaveChangesAsync();
            return (true, null, payment);
        }
    }
}
