using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika.Models
{
    public class car_images
    {
        public int id { get; set; }
        public int car_id { get; set; }
        public string image_path { get; set; } = string.Empty;
    }
}