using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infrastructure.Models
{
    public class EventViewModels
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public System.DateTime DateTime { get; set; }
        public long CreatedBy { get; set; }
        public Nullable<long> ImageId { get; set; }
        public long TypeId { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
    }
}