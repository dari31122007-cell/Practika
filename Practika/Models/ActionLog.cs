using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika.Models
{
    public class ActionLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? ActionType { get; set; }
        public string? ActionDetails { get; set; }
        public DateTime ActionTime { get; set; }
    }
}