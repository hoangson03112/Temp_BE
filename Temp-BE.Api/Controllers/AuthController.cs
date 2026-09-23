using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Temp_BE.Application.Interface.Services;
using Temp_BE.Domain.DTOs;

namespace Temp_BE.Api.Controllers
{
    [Route("api/auth")]
    public class AuthController : BaseApiController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var result = await _authService.RegisterAsync(dto);
            if (result.Success && result.Data != null)
            {
                SetTokenCookie(result.Data.Token, result.Data.ExpiresAt);
            }
            return HandleResult(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var result = await _authService.LoginAsync(dto);
            SetTokenCookie(result.Data.Token, result.Data.ExpiresAt);

            return HandleResult(result);
        }

        [Authorize]
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!long.TryParse(userIdStr, out long userId))
            {
                return Unauthorized();
            }

            var result = await _authService.GetProfileAsync(userId);
            return HandleResult(result);
        }
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("access_token", new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None
            });
            return Ok(new { success = true, message = "Đăng xuất thành công." });
        }
        private void SetTokenCookie(string token, DateTime expires)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true, 
                Secure = true,   
                SameSite = SameSiteMode.None, 
                Expires = expires
            };
            Response.Cookies.Append("access_token", token, cookieOptions);
        }
    }
}