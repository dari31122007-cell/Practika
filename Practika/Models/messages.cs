using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika.Models
{
    public class messages
    {
        public int id { get; set; }
        public int sender_id { get; set; }
        public int receiver_id { get; set; }
        public int? car_id { get; set; }
        public string message { get; set; } = string.Empty;
        public DateTime sent_at { get; set; }
    }
}