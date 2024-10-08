using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
using System.Security.Claims;
using VendManager.BlazorUI.Contracts;
using VendManager.BlazorUI.Models;
using VendManager.BlazorUI.Services;
using VendManager.BlazorUI.Services.Base;
using VendManager.BlazorUI.Services.HttpContext;



namespace RouterManagerServer.UI.Areas.Identity.Pages.Account
{

  
    public class LoginModel : PageModel
    {
 
        private readonly TokenPersistenceService _tokenService;
        private readonly IClient _client;
       // private readonly ILocalStorageService _localStorage;
 

        public LoginModel(TokenPersistenceService tokenService, IClient client)
        {
          //  _httpClient = httpClient;
         //   _localStorage = localStorage;
            _tokenService = tokenService;
            _client = client;
        }



        [BindProperty]
        public InputModel Input { get; set; }


        [Inject]
        public NavigationManager NavigationManager { get; set; }
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
                var loginRequest = new AuthRequest{ Email = Input.Email, Password = Input.Password };
                var response = await _client.LoginAsync(loginRequest);


                if (response.Token != null)
                {
          

                    Log.Information($"******************************************* Email {response.Email}");
                    Log.Information($"******************************************* Id {response.Id}");
                    Log.Information($"******************************************* Token {response.Token}");
                    Log.Information($"******************************************* Username{response.UserName}");
                    Log.Information($"******************************************* Role {response.Roles.First()}");

                    Token = response.Token;

                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Name, Input.Email),
                        new Claim("JWT", response.Token),
                        new Claim(ClaimTypes.Role, response.Roles.First()) // Use ClaimTypes.Role to ensure compatibility
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);


                    //var claims = new[]
                    //{
                    //    new Claim(ClaimTypes.Name, Input.Email),
                    //    new Claim("JWT", response.Token),
                    //    new Claim("Role" , response.Roles.First())
                    //};

                

                    //var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    //var principal = new ClaimsPrincipal(identity);

                    //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = Input.KeepSignedIn });

                    var token = response.Token;
                    return LocalRedirect($"/Identity/Account/StoreToken?Token={token}");
                }
                else
                {
                    ErrorMessage = "Invalid login attempt.";
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }

            return Page();
        }

        private bool IsLoading { get; set; } = false;
        public class InputModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public bool KeepSignedIn { get; set; }

        }
    }
}
