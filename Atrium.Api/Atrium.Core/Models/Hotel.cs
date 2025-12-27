namespace Atrium.Core.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal Rating { get; set; }
        public string Description { get; set; }
    }
}
