using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string ModelName { get; set; } = string.Empty;
    }
}