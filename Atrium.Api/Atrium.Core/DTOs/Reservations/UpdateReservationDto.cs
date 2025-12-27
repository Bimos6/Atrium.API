namespace Atrium.Core.DTOs.Reservations
{
    public class UpdateReservationDto
    {
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public int? AdultsCount { get; set; }
        public int? ChildrenCount { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? Status { get; set; }
    }
}