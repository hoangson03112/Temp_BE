
using Temp_BE.Application.Common;
using Temp_BE.Domain.DTOs;
using Temp_BE.Domain.Requests;
using Temp_BE.Domain.Responses;

namespace Temp_BE.Application.Interface.Services
{
    public interface IAuthService
    {
        Task<ApiResponse<AuthResponse>> RegisterAsync(RegisterRequest req);
        Task<ApiResponse<AuthResponse>> LoginAsync(LoginRequest req);
        Task<ApiResponse<UserDto>> GetProfileAsync(long userId);
    }
}
