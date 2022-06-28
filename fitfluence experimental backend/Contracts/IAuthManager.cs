﻿using fitfluence_experimental_backend.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace fitfluence_experimental_backend.Contracts
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(ApiUserDto user);
        Task<bool> Login(LoginDto user);
    }
}
