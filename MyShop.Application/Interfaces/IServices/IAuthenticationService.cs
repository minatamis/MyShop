using MyShop.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Application.Interfaces.IServices
{
    public interface IAuthenticationService
    {
        Task Register(RegisterDto user);
        Task<(string accessToken, string refreshToken)> Login(LoginRequestDto loginRequest);
        Task<(string accessToken, string refreshToken)> Refresh(string token);
        Task Logout(string refreshToken);
    }
}
