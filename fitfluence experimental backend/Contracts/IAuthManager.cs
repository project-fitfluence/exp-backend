using fitfluence_experimental_backend.Models.Users;

namespace fitfluence_experimental_backend.Contracts
{
    public interface IAuthManager
    {
        Task<bool> Register(ApiUserDto user);
    }
}
