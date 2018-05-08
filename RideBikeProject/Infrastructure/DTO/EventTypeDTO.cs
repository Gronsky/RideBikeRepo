using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class EventTypeDTO
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public string LongType { get; set; }
        public string Description { get; set; }
    }
}
