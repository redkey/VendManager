using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendManager.Application.Models.Identity;

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
