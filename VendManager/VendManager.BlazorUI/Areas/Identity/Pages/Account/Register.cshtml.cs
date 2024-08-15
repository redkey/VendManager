using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using VendManager.BlazorUI.Services.Base;

namespace RouterManagerServer.UI.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly IClient _client;   
        public RegisterModel(IClient client)
        {
            _client = client;
        }

        [BindProperty]
        public InputModel Input { get; set; }   
        public string ReturnUrl { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; private set; }

        public void OnGet()
        {
            ReturnUrl = Url.Content("~/");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ReturnUrl = Url.Content("~/");

            if (ModelState.IsValid)
            {
                var loginRequest = new RegistrationRequest { Email = Input.Email, Password = Input.Password , FirstName = Input.FirstName , LastName = Input.LastName , Role = "Customer" , Enabled = false};
                var registerResponse = await _client.RegisterAsync(loginRequest);


                if (registerResponse.UserId != null)
                {


                   var response = await _client.LoginAsync(new AuthRequest { Email = Input.Email, Password = Input.Password });
                    // var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();

                    if (response.Token != null)
                    {
                        Token = response.Token;

                        var claims = new[]
                        {
                            new Claim(ClaimTypes.Name, Input.Email),
                            new Claim("JWT", response.Token),
                            new Claim("Role" , response.Roles.First())
                        };

                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = Input.KeepSignedIn });

                        var token = response.Token;
                        return LocalRedirect($"/Identity/Account/StoreToken?Token={token}");

                    }
                    else
                    {
                        ErrorMessage = "Invalid login attempt.";
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    }
                }
                else
                {
                    ErrorMessage = "Invalid Register attempt.";
                    ModelState.AddModelError(string.Empty, "Invalid Register attempt.");
                }
            }

            return Page();
        }

        public class InputModel
        {
            public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Password { get; set; }
            public string Role { get; set; } = "ADMIN"; // Default role is "ADMIN
            public bool KeepSignedIn { get; set; }

        }
    }
}
