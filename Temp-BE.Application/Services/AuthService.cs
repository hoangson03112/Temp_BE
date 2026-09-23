using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Temp_BE.Application.Interface.Repositories;
using Temp_BE.Application.Interface.Services;
using Temp_BE.Domain.DTOs;
using Temp_BE.Infrastructure.Persistence.DbMappings;

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

        public async Task<ApiResponse<AuthResponseDto>> RegisterAsync(RegisterDto dto)
        {
            if (await _authRepo.ExistsByUserNameOrEmailAsync(dto.UserName, dto.Email))
            {
                return ApiResponse<AuthResponseDto>.Fail(400, "Username hoặc Email đã được sử dụng.");
            }

            var newUser = new UserDb
            {
                UserName = dto.UserName.Trim(),
                Email = dto.Email.Trim().ToLower(),
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                FullName = dto.FullName,
                Role = "Customer",
                IsActive = 1,
                CreatedAt = DateTime.Now
            };

            await _authRepo.CreateAsync(newUser);

            var token = GenerateJwtToken(newUser, out DateTime expires);

            return ApiResponse<AuthResponseDto>.Created(new AuthResponseDto
            {
                UserId = newUser.Id,
                UserName = newUser.UserName,
                Email = newUser.Email,
                Role = newUser.Role,
                Token = token,
                ExpiresAt = expires
            }, "Đăng ký tài khoản thành công.");
        }

        public async Task<ApiResponse<AuthResponseDto>> LoginAsync(LoginDto dto)
        {
            var user = await _authRepo.GetByUserNameOrEmailAsync(dto.UserNameOrEmail.Trim());
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            {
                return ApiResponse<AuthResponseDto>.Fail(401, "Tài khoản hoặc mật khẩu không chính xác.");
            }

            if (user.IsActive == 0)
            {
                return ApiResponse<AuthResponseDto>.Fail(403, "Tài khoản của bạn đã bị khóa.");
            }

            var token = GenerateJwtToken(user, out DateTime expires);

            return ApiResponse<AuthResponseDto>.Ok(new AuthResponseDto
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
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

        private string GenerateJwtToken(UserDb user, out DateTime expires)
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