using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class EventUserDTO
    {
        public long Id { get; set; }
        public long EventId { get; set; }
        public long UserId { get; set; }
        public Nullable<long> BikeId { get; set; }
    }
}
