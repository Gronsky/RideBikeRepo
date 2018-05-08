using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class BikeSubtypeDTO
    {
        public long Id { get; set; }
        public string Subtype { get; set; }
        public long TypeId { get; set; }
    }
}
