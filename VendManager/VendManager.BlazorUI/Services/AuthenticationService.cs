//using Blazored.LocalStorage;
//using Microsoft.AspNetCore.Components.Authorization;
//using VendManager.BlazorUI.Contracts;
//using VendManager.BlazorUI.Providers;
//using VendManager.BlazorUI.Services.Base;

//namespace VendManager.BlazorUI.Services
//{
//    public class AuthenticationService : BaseHttpService, IAuthenticationService
//    {
//        private readonly CustomAuthenticationStateProvider _authenticationStateProvider;
//        public AuthenticationService(IClient client,
//            ILocalStorageService localStorage,
//            CustomAuthenticationStateProvider authenticationStateProvider) : base(client, localStorage)
//        {
//            _authenticationStateProvider = authenticationStateProvider;
//        }

//        public async Task<bool> AuthenticateAsync(string email, string password)
//        {
//            try
//            {
//                AuthRequest authenticationRequest = new AuthRequest() { Email = email, Password = password };
//                var authenticationResponse = await _client.LoginAsync(authenticationRequest);
//                if (authenticationResponse.Token != string.Empty)
//                {


//                    // Set claims in Blazor and login state
//                    ((CustomAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(authenticationRequest.Email, authenticationResponse.Token);
//                    return true;
//                }
//                return false;
//            }
//            catch (Exception)
//            {
//                return false;
//            }

//        }

//        public Task AuthenticateAsync2(string email, string password)
//        {
//            throw new NotImplementedException();
//        }

//        public async Task Logout()
//        {
//            // remove claims in Blazor and invalidate login state
//            //await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedOut();
//        }

//        public async Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password)
//        {
//            RegistrationRequest registrationRequest = new RegistrationRequest() { FirstName = firstName, LastName = lastName, Email = email, Password = password };
//            var response = await _client.RegisterAsync(registrationRequest);

//            if (!string.IsNullOrEmpty(response.Email))
//            {
//                return true;
//            }
//            return false;
//        }
//    }
//}
