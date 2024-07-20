using Blazored.LocalStorage;
using DevExpress.CodeParser;
using Microsoft.AspNetCore.Components.Authorization;
using VendManager.BlazorUI.Contracts;
using VendManager.BlazorUI.Providers;
using VendManager.BlazorUI.Services.Base;

namespace VendManager.BlazorUI.Services
{
    public class AuthenticationService : BaseHttpService, IAuthenticationService
    {

        private readonly AuthenticationStateProvider _authenticationStateProvider;
        public AuthenticationService(IClient client, ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider) : base(client, localStorage)
        {
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> AuthenticateAsync(string email, string password)
        {


            try
            {
                AuthRequest authRequest = new AuthRequest
                {
                    Email = email,
                    Password = password
                };

                var authResponse = await _client.LoginAsync(authRequest);

                if (authResponse.Token != string.Empty)
                {
                    await _localStorage.SetItemAsync("authToken", authResponse.Token);

                    //Set claims in blazor and login state 
                    await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedIn();


                    return true;
                }

                return false;
            }
            catch (Exception)
            {

                return false;
            }
           
        }

        public async Task Logout()
        {
            await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedOut();
        }

        public async Task<bool> RegisterAsync(string firstname, string lastname, string username, string email, string password)
        {
            RegistrationRequest registrationRequest = new RegistrationRequest
            {
                Email = email,
                FirstName = firstname,
                LastName = lastname,
                Password = password
            
            };

            var response = await _client.RegisterAsync(registrationRequest);

            if (!string.IsNullOrEmpty(response.Email))
            {
                return true;
            }

            return false;
        }
    }
}
