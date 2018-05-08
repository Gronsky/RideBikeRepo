using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RideBike.Infrastructure.Models
{
    public class EventViewModels
    {
        public long Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime DateTime { get; set; }
        public long CreatedBy { get; set; }
        public Nullable<long> ImageId { get; set; }
        public long TypeId { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        public string Image { get; set; }
        public string Team { get; set; }
        public string Type { get; set; }

    }
}