using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Temp_BE.Application.Common;
using Temp_BE.Application.Interface.Repositories;
using Temp_BE.Application.Interface.Services;
using Temp_BE.Domain.DTOs;
using Temp_BE.Domain.Models;
using Temp_BE.Domain.Requests;
using Temp_BE.Domain.Responses;

namespace Temp_BE.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepo;
        private readonly IConfiguration _config;

        public AuthService(IAuthRepository authRepo, IConfiguration config)
        {
            _authRepo = authRepo;
            _config = config;
        }

        public async Task<ApiResponse<AuthResponse>> RegisterAsync(RegisterRequest req)
        {
            if (await _authRepo.ExistsByUserNameOrEmailAsync(req.UserName, req.Email))
            {
                return ApiResponse<AuthResponse>.Fail(400, "Username hoặc Email đã được sử dụng.");
            }
            var newUser = new UserAccount
            {
                UserName = req.UserName.Trim(),
                Email = req.Email.Trim().ToLower(),
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(req.Password),
                FullName = req.FullName,
                Role = "Customer",
                IsActive = 1,
                CreatedAt = DateTime.Now
            };

            await _authRepo.CreateAsync(newUser);

            var token = GenerateJwtToken(newUser, out DateTime expires);

            return ApiResponse<AuthResponse>.Created(new AuthResponse
            {
                UserId = newUser.Id,
                UserName = newUser.UserName,
                Email = newUser.Email,
                FullName = newUser.FullName,
                Role = newUser.Role,
                Token = token,
                ExpiresAt = expires
            }, "Đăng ký tài khoản thành công.");
        }

        public async Task<ApiResponse<AuthResponse>> LoginAsync(LoginRequest req)
        {
            var user = await _authRepo.GetByUserNameOrEmailAsync(req.UserNameOrEmail.Trim());
            if (user == null || !BCrypt.Net.BCrypt.Verify(req.Password, user.PasswordHash))
            {
                return ApiResponse<AuthResponse>.Fail(401, "Tài khoản hoặc mật khẩu không chính xác.");
            }

            if (user.IsActive == 0)
            {
                return ApiResponse<AuthResponse>.Fail(403, "Tài khoản của bạn đã bị khóa.");
            }

            var token = GenerateJwtToken(user, out DateTime expires);

            return ApiResponse<AuthResponse>.Ok(new AuthResponse
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FullName = user.FullName,
                Role = user.Role,
                Token = token,
                ExpiresAt = expires
            }, "Đăng nhập thành công.");
        }

        public async Task<ApiResponse<UserDto>> GetProfileAsync(long userId)
        {
            var user = await _authRepo.GetByIdAsync(userId);
            if (user == null) return ApiResponse<UserDto>.Fail(404, "Không tìm thấy người dùng.");

            return ApiResponse<UserDto>.Ok(new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FullName = user.FullName,
                Role = user.Role
            });
        }

        private string GenerateJwtToken(UserAccount user, out DateTime expires)
        {
            var jwtConfig = _config.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig["Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            expires = DateTime.UtcNow.AddHours(double.Parse(jwtConfig["ExpireHours"] ?? "24"));

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
                issuer: jwtConfig["Issuer"],
                audience: jwtConfig["Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}