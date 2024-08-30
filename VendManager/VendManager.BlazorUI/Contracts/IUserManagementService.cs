using VendManager.BlazorUI.Services.Base;

namespace VendManager.BlazorUI.Contracts
{
    public interface IUserManagementService
    {
        Task<UserDetails> GetUserDetails(string userId);
        Task<User> GetUsersDetails(string userId);
        Task UpdateUserDetails(UserDetails userDetails);

        Task DeleteUserDetails(string userId);  
        Task ActivateUser(string userId);
    }
}
