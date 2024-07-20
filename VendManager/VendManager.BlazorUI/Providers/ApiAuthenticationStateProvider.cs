﻿using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace VendManager.BlazorUI.Providers
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorage;
        private readonly JwtSecurityTokenHandler jwtSecurityTokenHandler;
        private bool _isInitialized = false;

        public ApiAuthenticationStateProvider(ILocalStorageService localStorage)
        {
            this.localStorage = localStorage;
            jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (!_isInitialized)
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            return await GetAuthenticationStateInternalAsync();
        }

        private async Task<AuthenticationState> GetAuthenticationStateInternalAsync()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity());
            var isTokenPresent = await localStorage.ContainKeyAsync("token");
            if (!isTokenPresent)
            {
                return new AuthenticationState(user);
            }

            var savedToken = await localStorage.GetItemAsync<string>("token");
            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(savedToken);

            if (tokenContent.ValidTo < DateTime.Now)
            {
                await localStorage.RemoveItemAsync("token");
                return new AuthenticationState(user);
            }

            var claims = await GetClaims();

            user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));

            return new AuthenticationState(user);
        }

        public async Task InitializeAsync()
        {
            _isInitialized = true;
            NotifyAuthenticationStateChanged(GetAuthenticationStateInternalAsync());
        }

        public async Task LoggedIn()
        {
            var claims = await GetClaims();
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
            var authState = Task.FromResult(new AuthenticationState(user));
            NotifyAuthenticationStateChanged(authState);
        }

        public async Task LoggedOut()
        {
            await localStorage.RemoveItemAsync("token");
            var nobody = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(nobody));
            NotifyAuthenticationStateChanged(authState);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var savedToken = await localStorage.GetItemAsync<string>("token");
            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(savedToken);
            var claims = tokenContent.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
            return claims;
        }
    }
}
