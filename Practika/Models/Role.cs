using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika.Models
{
    public class Role
    {
        public int IdRoles { get; set; }
        public string RoleName { get; set; } = string.Empty; // engine_type в таблице — на самом деле название роли
    }
}