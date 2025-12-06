using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika.Models
{
    public class Car
    {
        public int id { get; set; }
        public int seller_id { get; set; }
        public int category_id { get; set; }
        public int brand_id { get; set; }
        public int model_id { get; set; }
        public int year { get; set; }
        public int mileage { get; set; }
        public string engine_Type { get; set; } = string.Empty;
        public string transmission { get; set; } = string.Empty;
        public int body_Type { get; set; }
        public int color_id { get; set; }
        public decimal price { get; set; }
        public string description { get; set; } = string.Empty;
        public DateTime created_at { get; set; }
        public string status { get; set; } = string.Empty;
    }

}
