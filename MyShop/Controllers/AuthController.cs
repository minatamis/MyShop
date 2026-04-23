using Microsoft.AspNetCore.Mvc;
using MyShop.Application.DTOs;
using MyShop.Application.Interfaces.IServices;

namespace MyShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<Response<string>>> Register(RegisterDto registerDto)
        {
            await _authenticationService.Register(registerDto);
            return Ok(Response<string>.Success("User registered successfully"));
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<Response<string>>> Login(LoginRequestDto loginRequestDto)
        {
            var (token, refreshToken) = await _authenticationService.Login(loginRequestDto);
            return Ok(Response<string>.Success(token, "Login successful"));
        }
        [HttpPost]
        [Route("refresh")]
        public async Task<ActionResult<Response<object>>> Refresh(RefreshRequestDto refreshRequestDto)
        {
            var token = await _authenticationService.Refresh(refreshRequestDto.RefreshToken);
            return Ok(Response<object>.Success(token));
        }
        [HttpPost]
        [Route("logout")]
        public async Task<ActionResult<Response<string>>> Logout(LogoutRequestDto logoutRequestDto)
        {
            await _authenticationService.Logout(logoutRequestDto.RefreshToken);
            return Ok(Response<string>.Success("Logout successful"));
        }
    }
}
