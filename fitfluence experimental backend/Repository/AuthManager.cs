using AutoMapper;
using fitfluence_experimental_backend.Contracts;
using fitfluence_experimental_backend.Data;
using fitfluence_experimental_backend.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace fitfluence_experimental_backend.Repository
{
    public class AuthManager : IAuthManager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApiUser> _userManager;

        public AuthManager(IMapper mapper, UserManager<ApiUser> userManager)
        {
            this._mapper = mapper;
            this._userManager = userManager;
        }

        public async Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto)
        {
            var user = _mapper.Map<ApiUser>(userDto);

            /*
             * Here we set the email as username.
             * This is because UserName is already fully validated
             * and we wont use a specific username.
             */
            user.UserName = userDto.Email;

            var result = await _userManager.CreateAsync(user, userDto.Password);

            // This registration is public, so users are always a customer.
            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Customer");
            }

            // Return errors if there are any.
            // We don't return the user because they would have to validate their email first and login.
            return result.Errors;
        }
    }
}
