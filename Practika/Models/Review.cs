using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika.Models
{

    namespace Practika.Models
    {
        public class Review
        {
            public int Id { get; set; }
            public int ReviewsId { get; set; }
            public int SellerId { get; set; }
            public int Rating { get; set; }
            public string Comment { get; set; } = string.Empty;
            public DateTime CreatedAt { get; set; }
        }
    }
}
