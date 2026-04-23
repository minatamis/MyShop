using System.Security.Cryptography;
using MyShop.Application.DTOs;
using MyShop.Application.Interfaces.IRepositories;
using MyShop.Application.Interfaces.IServices;
using MyShop.Domain.Entities;

namespace MyShop.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly ITokenService _tokenService;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        public AuthenticationService(
            IUserRepository userRepository, 
            IPasswordService passwordService, 
            ITokenService tokenService, 
            IRefreshTokenRepository refreshTokenRepository
            )
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
            _tokenService = tokenService;
            _refreshTokenRepository = refreshTokenRepository;
        }
        public async Task Register(RegisterDto registerUser)
        {
            var verifyIfExist = await _userRepository.GetByUsername(registerUser.UserName);
            if (verifyIfExist != null)
                throw new ApplicationException("Username already exists");

            var user = new User
            {
                Username = registerUser.UserName
            };
            user.PasswordHash = _passwordService.Hash(user, registerUser.Password);
            await _userRepository.AddUser(user);
        }
        public async Task<(string accessToken, string refreshToken)> Login(LoginRequestDto loginRequest)
        {
            var user = await _userRepository.GetByUsername(loginRequest.UserName);
            if (user == null || !_passwordService.VerifyPassword(user, loginRequest.Password))
                throw new ApplicationException("Invalid user or password");

            var accessToken = _tokenService.GenerateToken(user);
            var refreshToken = new RefreshToken
            {
                Token = GenerateRefreshToken(),
                ExpiresAt = DateTime.UtcNow.AddDays(1),
                UserId = user.UserId
            };

            await _refreshTokenRepository.AddToken(refreshToken);
            return (accessToken, refreshToken.Token);
        }
        public async Task<(string accessToken, string refreshToken)> Refresh(string token)
        {
            var existing = await _refreshTokenRepository.GetRefreshToken(token);
            if (existing == null || existing.IsRevoked || existing.ExpiresAt < DateTime.UtcNow)
                throw new ApplicationException("Invalid refresh token");

            existing.IsRevoked = true;

            var newAccessToken = _tokenService.GenerateToken(existing.User);

            var newRefreshToken = new RefreshToken
            {
                Token = GenerateRefreshToken(),
                ExpiresAt = DateTime.UtcNow.AddDays(1),
                UserId = existing.UserId
            };

            await _refreshTokenRepository.AddToken(newRefreshToken);

            return (newAccessToken, newRefreshToken.Token);
        }
        public async Task Logout(string refreshToken)
        {
            var token = await _refreshTokenRepository.GetRefreshToken(refreshToken);
            if(token != null)
            {
                token.IsRevoked = true;
                await _refreshTokenRepository.SaveChanges();
            }
        }
        public string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }
    }
}
