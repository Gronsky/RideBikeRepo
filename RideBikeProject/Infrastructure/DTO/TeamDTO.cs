using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class TeamDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Nullable<long> ImageId { get; set; }
        public string Image { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public long ChiefId { get; set; }
    }
}
