using VendManager.BlazorUI.Services.Base;

namespace VendManager.BlazorUI.Contracts
{
    public interface IAuthenticationService
    {
    
        Task AuthenticateAsync2(string email, string password);
        Task<bool> AuthenticateAsync(string email, string password);
        Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password);
        Task Logout();

        Task<User> GetUsersAsync();
    }
}
