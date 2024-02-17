using System.ComponentModel.DataAnnotations;

namespace BookMe.API.Auth.Entities
{
    public class Service
    {
        [Key]
        public Guid ServiceId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Required]
        public TimeOnly TimeOpen { get; set; }
        [Required]
        public TimeOnly TimeClose { get; set; }
        [Required]
        public bool isFree { get; set; } = true;
        [Required]
        public bool hasAutoConfirmation { get; set; } = false;

        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
