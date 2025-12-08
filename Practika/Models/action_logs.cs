using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika.Models
{
  
        public class action_logs
        {
            public int id { get; set; }
            public int user_id { get; set; }
            public string? action_type { get; set; }
            public string? action_details { get; set; }
            public DateTime action_time { get; set; }
        }
}
