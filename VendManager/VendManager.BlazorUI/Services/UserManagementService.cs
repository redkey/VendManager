using AutoMapper;
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



        public async Task<UserDetails> GetUserDetails(string userId)
        {
            var user = await _client.UserAsync(userId);
            return user;
        }
    }
}
