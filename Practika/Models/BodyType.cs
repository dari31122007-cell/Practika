using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Practika.Models
{
    public class BodyType
    {
        public int Id { get; set; }
        public string BodyTypeName { get; set; } = string.Empty; // в БД: body_type
    }
}
