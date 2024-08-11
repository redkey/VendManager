using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VendManager.Application.Contracts.Identity;
using VendManager.Application.Exceptions;
using VendManager.Application.Models.Identity;
using VendManager.Identity.Models;

namespace VendManager.Identity.Services
{
    public class AuthService : IAuthService
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JWTSettings _jwtSettings;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AuthService(SignInManager<ApplicationUser> signInManager, IOptions<JWTSettings> jwtSettings, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
            _userManager = userManager;
        }

        public async Task<AuthResponse> Login(AuthRequest requests)
        {
            var user = await _userManager.FindByEmailAsync(requests.Email);
            if (user == null)
            {
                throw new NotFoundException($"User with email {requests.Email} not found", requests.Email);
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, requests.Password, false);

            if (!result.Succeeded)
            {
                throw new BadRequestException("Invalid credentials");
            }

            // Retrieve the roles
            var roles = await _userManager.GetRolesAsync(user);

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            var response = new AuthResponse
            {
                ID = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                UserName = user.Email,
                Roles = roles.ToList()
            };

            return response;

           
        }


        public async Task<RegistrationResponse> Register(RegistrationRequest requests)
        {
            var user = new ApplicationUser
            {
                Email = requests.Email,
                UserName = requests.Email,
                FirstName = requests.FirstName,
                LastName = requests.LastName,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, requests.Password);

            if (!result.Succeeded)
            {

                StringBuilder str = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    str.AppendFormat(".{0}\n" , error.Description);
                }

                throw new BadRequestException($"{str}");
            }
            else
            {

                await _userManager.AddToRoleAsync(user, requests.Role);
                return new RegistrationResponse() { UserId = user.Id, };
            }

        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            //Retrieve Roles and Claims for the user from Database
            var roles = await _userManager.GetRolesAsync(user);
            var userClaims = await _userManager.GetClaimsAsync(user);   

            //Convert roles into a list of claims
            var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();

            //Create a list of claims
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)

            }
            .Union(userClaims)
            .Union(roleClaims);

            //Create a key from the secret key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

            //Create a signing credentials object from the key
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Create a JWT token
            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryInMinutes),
                signingCredentials: creds
            );

            return token;

        }

       
    }
}
