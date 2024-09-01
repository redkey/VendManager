using VendManager.Application.Models.Identity;

namespace VendManager.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<List<User>> GetDeactivatedUsers();
        Task<User> GetUser(string userId);
        Task<UserDetails> GetUserDetails(string userId);    

        //Update User Details
        Task UpdateUserDetails(UserDetails userDetails);
        Task UnDeleteUser (string userId);
        Task DeleteUser (string userId);
        Task ActivateUser (string userId);

        Task CreateUserDetails(UserDetails userDetails);
    }
}
