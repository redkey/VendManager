using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Security.Claims;
using VendManager.BlazorUI.Services.Base;

namespace VendManager.BlazorUI.Services
{
   
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public UserService(IHttpContextAccessor httpContextAccessor, AuthenticationStateProvider authenticationStateProvider)
        {
            _httpContextAccessor = httpContextAccessor;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public string GetRole()
        {
            throw new NotImplementedException();
        }

        //public string GetRole()
        //{
        //    var claimsPrincipal = _httpContextAccessor.HttpContext?.User;
        //    Log.Information($"****************************** Claims Principle {claimsPrincipal.Identities.FirstOrDefault().Claims.FirstOrDefault(c => c.Type == "Role")?.Value}");

        //    var role = claimsPrincipal.Identities.FirstOrDefault().Claims.FirstOrDefault(c => c.Type == "Role")?.Value;
        //    Log.Information($"****************************** Current Role {role}");
        //    return role;
        //}

        //public string GetRole()
        //{
        //    try
        //    {
        //        var claimsPrincipal = _httpContextAccessor.HttpContext?.User;

        //        if (claimsPrincipal == null)
        //        {
        //            Log.Error("HttpContext or User is null.");
        //            return null;
        //        }

        //        var identity = claimsPrincipal.Identities.FirstOrDefault();
        //        if (identity == null)
        //        {
        //            Log.Error("ClaimsIdentity is null.");
        //            return null;
        //        }

        //        var roleClaim = identity.Claims.FirstOrDefault(c => c.Type == "Role" || c.Type == ClaimTypes.Role);
        //        if (roleClaim == null)
        //        {
        //            Log.Error("Role claim not found.");
        //            return null;
        //        }

        //        Log.Information($"Current Role: {roleClaim.Value}");
        //        return roleClaim.Value;
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex, "Failed to retrieve the role from claims.");
        //        Log.Error(ex.Message, "Message: Failed to retrieve the role from claims.");

        //        throw;
        //    }
        //}



        //public string GetUserName()
        //{
        //    var claimsPrincipal = _httpContextAccessor.HttpContext?.User;
        //    return claimsPrincipal?.FindFirst(ClaimTypes.Name)?.Value;
        //}

        // Fetch user role asynchronously
        public async Task<string> GetRoleAsync()
        {
            try
            {
                var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
                var user = authState.User;

                if (user.Identity == null || !user.Identity.IsAuthenticated)
                {
                    Log.Error("User is not authenticated.");
                    return null;
                }

                var roleClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role || c.Type == "Role");

                if (roleClaim == null)
                {
                    Log.Error("Role claim not found.");
                    return null;
                }

                Log.Information($"Current Role: {roleClaim.Value}");
                return roleClaim.Value;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to retrieve the role from claims.");
                throw;
            }
        }

        public string GetUserName()
        {
            var claimsPrincipal = _httpContextAccessor.HttpContext?.User;
            return claimsPrincipal?.FindFirst(ClaimTypes.Name)?.Value;
        }

        // Fetch user name asynchronously
        public async Task<string> GetUserNameAsync()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            return user?.FindFirst(ClaimTypes.Name)?.Value;
        }

      
    }
}
