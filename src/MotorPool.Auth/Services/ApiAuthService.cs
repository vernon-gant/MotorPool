﻿using MotorPool.Auth.User;

namespace MotorPool.Auth.Services;

public interface ApiAuthService
{
    ValueTask<AuthResult> LoginAsync(LoginDTO loginDTO);

    ValueTask<AuthResult> RegisterAsync(RegisterDTO registerDTO);

    ValueTask<UserViewModel> GetUserAsync(string userId);
}