using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VendManager.BlazorUI.Contracts;
using VendManager.BlazorUI.Services.Base;
using VendManager.BlazorUI.Services.HttpContext;

namespace VendManager.BlazorUI.Services
{
   
    public class UserManagementService : BaseHttpService, IUserManagementService
    {


        private readonly IMapper _mapper;

        public UserManagementService(IClient client, TokenPersistenceService tokenService) : base(client, tokenService)
        {
        }

        public async Task ActivateUser(string userId)
        {
            await AddBearerToken();
            await _client.ActivateAsync(userId);
        }

        public async Task UnDeleteUser(string userId)
        {
            await AddBearerToken();
            await _client.UndeleteAsync(userId);
        }

        public async Task DeleteUserDetails(string userId)
        {
            await AddBearerToken();
            await _client.DeleteAsync(userId);
        }

        public async Task<UserDetails> GetUserDetails(string userId)
        {
            await AddBearerToken();
            var user = await _client.UserGETAsync(userId);
            return user;
        }

        public async Task<User> GetUsersDetails(string userId)
        {
           var user = await _client.UsersAsync(userId);
           return user;
        }

        public async Task UpdateUserDetails(UserDetails userDetails)
        {
            await AddBearerToken();
            await _client.UserPUTAsync(userDetails);
        }

        public async Task CreateUserDetails(UserDetails userDetails)
        {
            await AddBearerToken();
            await _client.CreateAsync(userDetails);
        }
    }
}
