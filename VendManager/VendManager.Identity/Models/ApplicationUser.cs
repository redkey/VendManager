using Microsoft.AspNetCore.Identity;

namespace VendManager.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool Deleted { get; set; } = false;   
        public bool Activated { get; set; } = false;

        public virtual UserDetails UserDetails { get; set; } // Navigation property for one-to-one relationship
    }
}
