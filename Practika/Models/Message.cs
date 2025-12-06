using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika.Models
{
   
        public class Message
        {
            public int Id { get; set; }
            public int SenderId { get; set; }
            public int ReceiverId { get; set; }
            public int CarId { get; set; }
            public string Messages { get; set; } = string.Empty;
        }

    }
