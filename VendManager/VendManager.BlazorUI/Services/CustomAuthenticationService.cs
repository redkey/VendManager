using System.Security.Claims;

namespace VendManager.BlazorUI.Services
{
    public class CustomAuthenticationService
    {
        public Dictionary<string, ClaimsPrincipal> Users { get; set; }

        public CustomAuthenticationService() 
        {
            Users = new Dictionary<string, ClaimsPrincipal>();
        }


    }
}
