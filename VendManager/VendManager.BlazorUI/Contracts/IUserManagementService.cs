using VendManager.BlazorUI.Services.Base;

namespace VendManager.BlazorUI.Contracts
{
    public interface IUserManagementService
    {
        Task<UserDetails> GetUserDetails(string userId);
    }
}
