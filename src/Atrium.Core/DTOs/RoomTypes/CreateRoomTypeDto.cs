namespace Atrium.Core.DTOs.RoomTypes
{
    public class CreateRoomTypeDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal BasePrice { get; set; }
        public decimal Size { get; set; }
    }
}