using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Temp_BE.Domain.DTOs;
using Temp_BE.Infrastructure.Persistence.DbMappings;

namespace Temp_BE.Application.Interface.Services
{
    public interface IAuthService
    {
        Task<ApiResponse<AuthResponseDto>> RegisterAsync(RegisterDto dto);
        Task<ApiResponse<AuthResponseDto>> LoginAsync(LoginDto dto);
        Task<ApiResponse<UserDto>> GetProfileAsync(long userId);
    }
}
