using Microsoft.AspNetCore.Identity;

namespace VendManager.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool Enabled { get; set; } = true;

        public virtual UserDetails UserDetails { get; set; } // Navigation property for one-to-one relationship
    }
}
