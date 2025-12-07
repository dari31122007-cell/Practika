using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika.Models
{
    public class orders
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int car_id { get; set; }
        public int? status { get; set; }
        public DateTime created_at { get; set; }
    }
}
