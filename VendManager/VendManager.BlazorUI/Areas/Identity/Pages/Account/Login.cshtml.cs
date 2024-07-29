using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using VendManager.BlazorUI.Contracts;
using VendManager.BlazorUI.Models;
using VendManager.BlazorUI.Services;
using VendManager.BlazorUI.Services.HttpContext;



namespace RouterManagerServer.UI.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly TokenPersistenceService _tokenService;
        private readonly ILocalStorageService _localStorage;
        private bool _loginSuccessful;
        private string _token;

        public LoginModel(HttpClient httpClient, ILocalStorageService localStorage, TokenPersistenceService tokenService)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _tokenService = tokenService;
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

        //public async Task<IActionResult> OnPostAsync()
        //{

        //    ReturnUrl = Url.Content("~/");
        //    if (ModelState.IsValid)
        //    {
        //        ClaimsPrincipal principal;

        //        _auth.Users.TryGetValue(Input.Email, out principal);

        //        if (principal != null)
        //        {

        //            var identity = principal.Identity as ClaimsIdentity;
        //            var username = identity.FindFirst(ClaimTypes.Name).Value;
        //            var password = identity.FindFirst("password")?.Value;

        //            if (Input.Password == password && Input.Email == username)
        //            {
        //                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = Input.KeepSignedIn });
        //                return LocalRedirect(ReturnUrl);
        //            }
        //            else
        //            {
        //                ErrorMessage = "Invalid login attempt.";
        //                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        //                return Page();
        //            }
        //            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = Input.KeepSignedIn });
        //            return LocalRedirect(ReturnUrl);
        //        }
        //        else
        //        {
        //            ErrorMessage = "Invalid login attempt.";
        //            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        //            return Page();
        //        }

        //    }




        //    //    var result = await _authenticationService.AuthenticateAsync(Input.Email, Input.Password);
        //    //    if (result)
        //    //    {
        //    //        return LocalRedirect(ReturnUrl);
        //    //    }
        //    //    else
        //    //    {
        //    //        ErrorMessage = "Invalid login attempt.";
        //    //        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        //    //        return Page();
        //    //    }
        //    //}
        //    return Page();


        //}

       

        public async Task<IActionResult> OnPostAsync()
        {
            ReturnUrl = Url.Content("~/");

            if (ModelState.IsValid)
            {
                var loginRequest = new { email = Input.Email, password = Input.Password };
                var response = await _httpClient.PostAsJsonAsync("https://localhost:7121/api/Auth/login", loginRequest);

                if (response.IsSuccessStatusCode)
                {
                    var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();

                    // Store the token using TokenService
                    Token = loginResponse.Token;

                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Name, Input.Email),
                        new Claim("JWT", loginResponse.Token)
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = Input.KeepSignedIn });

                    var token = loginResponse.Token;
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
