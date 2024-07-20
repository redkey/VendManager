﻿using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace VendManager.BlazorUI.Providers
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        public ApiAuthenticationStateProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
           var user = new ClaimsPrincipal(new ClaimsIdentity());
           var isTokenPresent = await _localStorage.ContainKeyAsync("token");
           if (!isTokenPresent)
           {
               return new AuthenticationState(user);
           }

           var savedToken = await _localStorage.GetItemAsync<string>("token");
            var tokenContent = _jwtSecurityTokenHandler.ReadJwtToken(savedToken);
            if(tokenContent.ValidTo < DateTime.Now)
            {
                await _localStorage.RemoveItemAsync("token");
                return new AuthenticationState(user);
            }

            var claims  = await GetClaims();
            user= new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
            return new AuthenticationState(user);
        }

        //Log a user in
        public async Task LoggedIn()
        {
            var claims = await GetClaims();
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
            var authState = Task.FromResult(new AuthenticationState(user));
            NotifyAuthenticationStateChanged(authState);
        }

        //Log a user out
        public async Task LoggedOut()
        {
            await _localStorage.RemoveItemAsync("token");
            var user = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(user));
            NotifyAuthenticationStateChanged(authState);
        }

        //Get Claims from the token
        private async Task<List<Claim>> GetClaims()
        {

            var savedToken = await _localStorage.GetItemAsync<string>("token");
            if (string.IsNullOrWhiteSpace(savedToken))
            {
                return new List<Claim>();
            }

            var tokenContent = _jwtSecurityTokenHandler.ReadJwtToken(savedToken);
            var claims = tokenContent.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
            return claims;
        }
    }
}