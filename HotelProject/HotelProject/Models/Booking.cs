
using System;

namespace HotelBookingApi.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }

        public int RoomId { get; set; }
        public Room? Room { get; set; }

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
