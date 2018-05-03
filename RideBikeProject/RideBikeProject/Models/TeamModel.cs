using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RideBikeProjectWEB.Models
{
    public class TeamModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Nullable<long> ImageId { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public long ChiefId { get; set; }
    }
}