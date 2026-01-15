namespace Atrium.Core.DTOs.Rooms
{
    public class UpdateRoomDto
    {
        public int? RoomTypeId { get; set; }
        public int? HotelId { get; set; }
        public string? RoomNumber { get; set; }
        public int? Floor { get; set; }
        public string? Status { get; set; }
        public decimal? Price { get; set; }
        public int? MaxGuests { get; set; }
    }
}