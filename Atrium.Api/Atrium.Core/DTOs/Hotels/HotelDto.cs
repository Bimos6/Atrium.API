namespace Atrium.Core.DTOs.Hotels
{
    public class HotelDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal Rating { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}