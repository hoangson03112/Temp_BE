using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temp_BE.Domain.DTOs
{
    public class UserDto
    {
        public long Id { get; set; }
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string? FullName { get; set; }
        public string Role { get; set; } = default!;
    }
    public class RegisterDto
    {
        [Required(ErrorMessage = "Username không được để trống")]
        public string UserName { get; set; } = default!;
        [Required, EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; } = default!;
        [Required, MinLength(6, ErrorMessage = "Mật khẩu tối thiểu 6 ký tự")]
        public string Password { get; set; } = default!;
        public string? FullName { get; set; }
    }
    public class LoginDto
    {
        [Required(ErrorMessage = "Username hoặc Email không được để trống")]
        public string UserNameOrEmail { get; set; } = default!;
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string Password { get; set; } = default!;
    }
    public class AuthResponseDto
    {
        public long UserId { get; set; }
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Role { get; set; } = default!;
        public string Token { get; set; } = default!;
        public DateTime ExpiresAt { get; set; }
    }
}
