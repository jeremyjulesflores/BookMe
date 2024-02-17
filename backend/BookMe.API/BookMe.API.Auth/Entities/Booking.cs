using System.ComponentModel.DataAnnotations;

namespace BookMe.API.Auth.Entities
{
    public class Booking
    {
        [Key]
        public Guid BookingId { get; set; }
      
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
        [Required]
        public bool isConfirmed { get; set; } = false;
        [Required]
        public bool isCancelled { get; set; } = false;
    }
}
