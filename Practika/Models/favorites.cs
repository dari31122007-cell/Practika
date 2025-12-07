using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika.Models
{
    public class favorites
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int car_id { get; set; }
        public DateTime added_at { get; set; }
    }
}