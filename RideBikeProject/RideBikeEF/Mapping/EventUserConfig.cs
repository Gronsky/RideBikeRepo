using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using RideBikeProjectDAL.Entities;

namespace RideBikeProjectDAL.Mapping
{
    class EventUserConfig : EntityTypeConfiguration<EventUser>
    {
        public EventUserConfig()
        {
            Property(x => x.EventId)
                .IsRequired();

            Property(x => x.UserId)
                .IsRequired();
        }
    }
}
