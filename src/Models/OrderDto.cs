using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
    }
}
