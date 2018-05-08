using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class BikeDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long OwnerId { get; set; }
        public long ProducerId { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
    }
}
