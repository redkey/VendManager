using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace VendManager.BlazorUI.Services
{
   
    public class RedirectService
    {
        private readonly NavigationManager _navigationManager;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public RedirectService(NavigationManager navigationManager, AuthenticationStateProvider authenticationStateProvider)
        {
            _navigationManager = navigationManager;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task RedirectToLoginIfNotAuthenticated()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            if (!authState.User.Identity.IsAuthenticated)
            {
                _navigationManager.NavigateTo("/login");
            }
        }
    }
}
