using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika.Models
{
    public class cars
    {
        public int id { get; set; }
        public int seller_id { get; set; }
        public int category_id { get; set; }
        public int brand_id { get; set; }
        public int model_id { get; set; }
        public int year { get; set; }
        public int mileage { get; set; }
        public int engine_type { get; set; }
        public int transmission_id { get; set; }
        public int? body_type_id { get; set; }
        public int color_id { get; set; }
        public decimal price { get; set; }
        public string? description { get; set; }
        public DateTime created_at { get; set; }
        public int status_id { get; set; }
    }
}
