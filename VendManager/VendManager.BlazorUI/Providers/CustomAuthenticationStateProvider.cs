//using Microsoft.AspNetCore.Components.Authorization;
//using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
//using Microsoft.JSInterop;
//using System.Net.Http.Headers;
//using System.Security.Claims;
//using System.Text.Json;

//namespace VendManager.BlazorUI.Providers
//{
//    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
//    {
//        private readonly IJSRuntime _jsRuntime;
//        private readonly HttpClient _httpClient;
//        private readonly AuthenticationState _anonymous;

//        public CustomAuthenticationStateProvider(IJSRuntime jsRuntime, HttpClient httpClient)
//        {
//            _jsRuntime = jsRuntime;
//            _httpClient = httpClient;
//            _anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
//        }

//        public async Task<AuthenticationState> RetrieveAuthenticationStateAsync()
//        {
//            try
//            {
//                var result = await _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "token");
//                var token = result ?? string.Empty;

//                if (string.IsNullOrWhiteSpace(token))
//                {
//                    return new AuthenticationState(_anonymous);
//                }

//                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
//                var identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
//                var user = new ClaimsPrincipal(identity);
//                return new AuthenticationState(user);
//            }
//            catch
//            {
//                return new AuthenticationState(_anonymous);
//            }
//        }

//        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
//        {
//            if (_jsRuntime is IJSInProcessRuntime)
//            {
//                return new AuthenticationState(_anonymous);
//            }

//            return await RetrieveAuthenticationStateAsync();
//        }


//        public void UpdateAuthenticationState(AuthenticationState authState)
//        {
//            NotifyAuthenticationStateChanged(Task.FromResult(authState));
//        }

//        public void MarkUserAsAuthenticated(string username, string token)
//        {
//            var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) }, "apiauth");
//            var user = new ClaimsPrincipal(identity);

//            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));

//            _sessionStorage.SetAsync("token", token);
//        }

//        public void MarkUserAsLoggedOut()
//        {
//            var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
//            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymous)));
//            _sessionStorage.DeleteAsync("token");
//        }

//        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
//        {
//            var payload = jwt.Split('.')[1];
//            var jsonBytes = ParseBase64WithoutPadding(payload);
//            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
//            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
//        }

//        private byte[] ParseBase64WithoutPadding(string base64)
//        {
//            switch (base64.Length % 4)
//            {
//                case 2: base64 += "=="; break;
//                case 3: base64 += "="; break;
//            }
//            return Convert.FromBase64String(base64);
//        }
//    }
//}
