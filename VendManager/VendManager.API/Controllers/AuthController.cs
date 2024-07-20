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

        public AuthController(IAuthService authService)
        {
            _authService = authService;
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
    }

}
