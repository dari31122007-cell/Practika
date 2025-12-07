using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika.Models
{
    public class reviews
    {
        public int id { get; set; }
        public int reviewer_id { get; set; }
        public int seller_id { get; set; }
        public int? rating { get; set; }
        public string? comment { get; set; }
        public DateTime created_at { get; set; }
    }
}