using VendManager.BlazorUI.Services.Base;

namespace VendManager.BlazorUI.Services
{
    public interface IUserService
    {
        string GetUserName();
        Task<string> GetUserNameAsync();
        string GetRole();
        Task<string> GetRoleAsync();
     

    }
}
