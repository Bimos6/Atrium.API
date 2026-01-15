namespace Atrium.Core.DTOs.RoomTypes
{
    public class UpdateRoomTypeDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? BasePrice { get; set; }
        public decimal? Size { get; set; }
    }
}