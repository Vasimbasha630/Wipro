
using System;

namespace HotelBookingApi.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public Booking? Booking { get; set; }

        public decimal Amount { get; set; }
        public string Currency { get; set; } = "INR";
        public string PaymentProvider { get; set; } = "Mock";
        public string PaymentStatus { get; set; } = "Pending";
        public string? TransactionRef { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
