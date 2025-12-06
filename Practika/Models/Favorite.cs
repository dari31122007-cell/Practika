using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika.Models
{
    internal class Favorite
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public DateTime AddedAt { get; set; }
    }
}
