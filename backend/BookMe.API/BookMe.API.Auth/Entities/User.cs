using System.ComponentModel.DataAnnotations;

namespace BookMe.API.Auth.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string PasswordHash { get; set; } = string.Empty;
        [Required]
        public byte[] PasswordSalt { get; set; } = new byte[32];
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public List<Service> Services { get; set; } = new List<Service>();

    }
}
