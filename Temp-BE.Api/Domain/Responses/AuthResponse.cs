using System.Text.Json.Serialization;

namespace Temp_BE.Domain.Responses
{
    public class AuthResponse
    {
        public long UserId { get; set; }
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string? FullName { get; set; }
        public string Role { get; set; } = default!;

        [JsonIgnore]
        public string Token { get; set; } = default!;

        [JsonIgnore]
        public DateTime ExpiresAt { get; set; }
    }
}
