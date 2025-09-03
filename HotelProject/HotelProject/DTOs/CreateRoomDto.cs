namespace HotelProject.DTOs
{
    public class CreateRoomDto
    {
        public string RoomNumber { get; set; } = null!;
        public string Type { get; set; } = "Single";
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
