namespace HotelProject.DTOs
{
    public class CreateHotelDto
    {
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Description { get; set; }

        // Rooms to create along with hotel
        public List<CreateRoomDto>? Rooms { get; set; }
    }
}
