using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VendManager.Application.Contracts.Identity;
using VendManager.Application.Models.Identity;

namespace VendManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] AuthRequest request)
        {
            var response = await _authService.Login(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<RegistrationResponse>> Register([FromBody] RegistrationRequest request)
        {
            var response = await _authService.Register(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("users")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet]
        [Route("deactivatesusers")]
        public async Task<ActionResult<List<User>>> GetDeactivatedUsers()
        {
            var users = await _userService.GetDeactivatedUsers();
            return Ok(users);
        }

        [HttpGet]
        [Route("deletedusers")]
        public async Task<ActionResult<List<User>>> GetDeletedUsers()
        {
            var users = await _userService.GetDeletedUsers();
            return Ok(users);
        }

        [HttpGet]
        [Route("user/{userId}")]
        public async Task<ActionResult<UserDetails>> GetUser(string userId)
        {
            var user = await _userService.GetUserDetails(userId);
            return Ok(user);
        }

        [HttpGet]
        [Route("users/{userId}")]
        public async Task<ActionResult<User>> GetUsers(string userId)
        {
            var user = await _userService.GetUser(userId);
            return Ok(user);
        }

        [HttpPut]
        [Route("user")]
        public async Task<ActionResult> UpdateUserDetails([FromBody] UserDetails userDetails)
        {
            await _userService.UpdateUserDetails(userDetails);
            return Ok();
        }

        [HttpPut]
        [Route("undelete/{userId}")]
        public async Task<ActionResult> UnDeleteUser(string userId)
            {
            await _userService.UnDeleteUser(userId);
            return Ok();
        }

        [HttpPut]
        [Route("delete/{userId}")]
        public async Task<ActionResult> DeleteUser(string userId)
        {
            await _userService.DeleteUser(userId);
            return Ok();
        }

        [HttpPost]
        [Route("activate/{userId}")]
        public async Task<ActionResult> ActivateUser(string userId)
        {
            await _userService.ActivateUser(userId);
            return Ok();
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateUserDetails([FromBody] UserDetails userDetails)
        {
            await _userService.CreateUserDetails(userDetails);
            return Ok();
        }
    }

}
