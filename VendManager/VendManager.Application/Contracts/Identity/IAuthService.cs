using VendManager.Application.Models.Identity;

namespace VendManager.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest requests);
        Task<RegistrationResponse> Register(RegistrationRequest requests);
    }
}
