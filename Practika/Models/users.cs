using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika.Models
{
    public class users
    {
        public int id { get; set; }
        public int role_id { get; set; }
        public string username { get; set; } = string.Empty;
        public string surname { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string patronymic { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string password_hash { get; set; } = string.Empty;
        public string? phone { get; set; }
        public DateTime Date_of_birth { get; set; }
        public DateTime created_at { get; set; }
    }
}