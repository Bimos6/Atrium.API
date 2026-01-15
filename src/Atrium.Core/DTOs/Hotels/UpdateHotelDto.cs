namespace Atrium.Core.DTOs.Hotels
{
    public class UpdateHotelDto
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public decimal? Rating { get; set; }
        public string? Description { get; set; }
    }
}