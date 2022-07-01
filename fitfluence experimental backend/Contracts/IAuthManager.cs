using fitfluence_experimental_backend.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace fitfluence_experimental_backend.Contracts
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(ApiUserDto user);
        Task<AuthResponseDto> Login(LoginDto user);
        Task<string> CreateRefreshToken();
        Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request);
    }
}
