using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VendManager.Application.Contracts.Identity;
using VendManager.Application.Models.Identity;

namespace VendManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        [Route("login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] AuthRequest request)
        {
            var response = await _authService.Login(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<RegistrationRequest>> Register([FromBody] RegistrationRequest request)
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
        [Route("user/{userId}")]
        public async Task<ActionResult<UserDetails>> GetUser(string userId)
        {
            var user = await _userService.GetUserDetails(userId);
            return Ok(user);
        }
    }

}
