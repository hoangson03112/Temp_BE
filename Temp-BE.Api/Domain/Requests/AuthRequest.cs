

using System.ComponentModel.DataAnnotations;

namespace Temp_BE.Domain.Requests
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Username hoặc Email không được để trống")]
        public string UserNameOrEmail { get; set; } = default!;
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string Password { get; set; } = default!;
    }
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Username không được để trống")]
        public string UserName { get; set; } = default!;
        [Required, EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; } = default!;
        [Required, MinLength(6, ErrorMessage = "Mật khẩu tối thiểu 6 ký tự")]
        public string Password { get; set; } = default!;
        public string? FullName { get; set; }
    }
}
