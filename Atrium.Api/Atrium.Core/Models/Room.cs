namespace Atrium.Core.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomTypeId { get; set; }
        public int HotelId { get; set; }  
        public string RoomNumber { get; set; }
        public int Floor { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }
        public int MaxGuests { get; set; }
    }
}
