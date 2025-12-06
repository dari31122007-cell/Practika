// Practika/Models/User.cs
namespace Practika.Models
{
    public class User
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Patronymic { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}