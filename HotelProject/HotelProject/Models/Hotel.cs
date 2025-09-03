
using System.Collections.Generic;
namespace HotelBookingApi.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Description { get; set; }

        public ICollection<Room>? Rooms { get; set; }
    }
}

