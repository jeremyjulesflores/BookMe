using System.ComponentModel.DataAnnotations;

namespace BookMe.API.Auth.Models.Booking
{
    public class BookingCreationViewModel
    {
        [Required]
        public DateTime TimeStart { get; set; }
        [Required]
        public DateTime TimeEnd { get; set; }
        [Required]
        public string CustomerFirstName { get; set; } = string.Empty;
        [Required]
        public string CustomerLastName { get; set; } = string.Empty;
        [Required]
        public string CustomerEmail { get; set; } = string.Empty;
        [Required]
        public string CustomerPhone { get; set; } = string.Empty;
    }
}
