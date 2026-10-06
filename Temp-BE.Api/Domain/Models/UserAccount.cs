namespace Temp_BE.Domain.Models
{
    public class UserAccount
    {
        public long Id { get; set; }
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
        public string? FullName { get; set; }
        public string Role { get; set; } = "Customer";
        public int IsActive { get; set; } = 1;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
