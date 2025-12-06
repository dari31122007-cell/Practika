using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika
{
    public class Review
    {
        public int Id { get; set; }
        public int ReviesId { get; set; }    // опечатка в БД: revies_id
        public int SellerId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }

}
