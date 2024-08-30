using System.ComponentModel.DataAnnotations;

namespace VendManager.Application.Models.Identity
{
    public class RegistrationRequest
    {

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]  
        public string Password { get; set; }

        public bool Enabled { get; set; }
        public bool Activated { get; set; }

    }
}
    