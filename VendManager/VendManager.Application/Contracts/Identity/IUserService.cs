using VendManager.Application.Models.Identity;

namespace VendManager.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<User> GetUser(string userId);
        Task<UserDetails> GetUserDetails(string userId);

        //Update User Details
        Task UpdateUserDetails(UserDetails userDetails);
    }
}
