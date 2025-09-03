
using System;

namespace HotelBookingApi.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }

        public string RoomNumber { get; set; } = null!;
        public string Type { get; set; } = "Single";
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
