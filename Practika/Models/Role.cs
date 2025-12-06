// Practika/Models/Role.cs
namespace Practika.Models
{
    public class Role
    {
        public int IdRoles { get; set; } // в БД: id_roles
        public string EngineType { get; set; } = string.Empty; // в БД: engine_type
    }
}