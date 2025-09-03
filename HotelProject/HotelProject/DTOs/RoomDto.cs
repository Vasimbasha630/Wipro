namespace HotelProject.DTOs
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; } = null!;
        public string Type { get; set; } = "Single";
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
    }
}
