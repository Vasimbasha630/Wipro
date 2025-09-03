
namespace HotelBookingApi.DTOs
{
    public class HotelDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Description { get; set; }
    }
}
