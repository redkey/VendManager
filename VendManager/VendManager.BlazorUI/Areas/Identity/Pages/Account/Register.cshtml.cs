using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Security.Claims;
using VendManager.BlazorUI.Services;




namespace RouterManagerServer.UI.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly CustomAuthenticationService _auth;
        public RegisterModel(CustomAuthenticationService auth)
        {
          _auth = auth; 
        }

        [BindProperty]
        public InputModel Input { get; set; }   
        public string ReturnUrl { get; set; }
        public void OnGet()
        {
            ReturnUrl = Url.Content("~/");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ReturnUrl = Url.Content("~/");
            if (ModelState.IsValid)
            {

                var claim = new List<Claim>();
                claim.Add(new Claim(ClaimTypes.Name, Input.Email));
                claim.Add(new Claim(ClaimTypes.Email, Input.Email));
                claim.Add(new Claim("password", Input.Password));
                claim.Add(new Claim(ClaimTypes.Role, Input.Role));


                var claimsIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);

                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                _auth.Users.Add(Input.Email, claimsPrincipal);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties { IsPersistent = Input.KeepSignedIn });
                return LocalRedirect(ReturnUrl);
            }
            return Page();
        }
        
        public class InputModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public string Role { get; set; } = "ADMIN"; // Default role is "ADMIN
            public bool KeepSignedIn { get; set; }

        }
    }
}
