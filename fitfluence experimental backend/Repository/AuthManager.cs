using AutoMapper;
using fitfluence_experimental_backend.Contracts;
using fitfluence_experimental_backend.Data;
using fitfluence_experimental_backend.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace fitfluence_experimental_backend.Repository
{
    public class AuthManager : IAuthManager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApiUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthManager(IMapper mapper, UserManager<ApiUser> userManager, IConfiguration configuration)
        {
            this._mapper = mapper;
            this._userManager = userManager;
            _configuration = configuration;
        }

        public async Task<AuthResponseDto> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            var isValidUser = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            // API's are stateless, however here we could call _userManager.signin if it weren't an API.

            if (user == null || isValidUser == false)
            {
                return null;
            }

            var token = await GenerateToken(user);
            return new AuthResponseDto
            {
                Token = token,
                UserId = user.Id
            };
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
        
        private async Task<string> GenerateToken(ApiUser user)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));

            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            // Get roles from database and 'generate' claims.
            // https://docs.microsoft.com/en-us/aspnet/core/security/authorization/claims?view=aspnetcore-6.0
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();

            var tokenClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email), // subject
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
            }
            .Union(roleClaims);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: tokenClaims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtSettings:DurationInMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
