namespace Atrium.Core.DTOs.Rooms
{
    public class RoomDto
    {
        public int Id { get; set; }
        public int RoomTypeId { get; set; }
        public int HotelId { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public int Floor { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int MaxGuests { get; set; }
    }
}