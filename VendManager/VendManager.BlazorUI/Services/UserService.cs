using System.Security.Claims;

namespace VendManager.BlazorUI.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetRole()
        {
            var claimsPrincipal = _httpContextAccessor.HttpContext?.User;
            var role = claimsPrincipal.Identities.FirstOrDefault().Claims.FirstOrDefault(c => c.Type == "Role")?.Value;
            //var role = claimsPrincipal?.FindFirst(ClaimTypes.Role)?.Value;
            return role;
        }

        public string GetUserName()
        {
            var claimsPrincipal = _httpContextAccessor.HttpContext?.User;
            return claimsPrincipal?.FindFirst(ClaimTypes.Name)?.Value;
        }
    }
}
