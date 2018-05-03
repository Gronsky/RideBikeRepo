using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using RideBikeProjectDAL.Entities;

namespace RideBikeProjectDAL.Mapping
{
    class EventTypeConfig : EntityTypeConfiguration<EventType>
    {
        EventTypeConfig()
        {
            Property(x => x.Type)
                .IsRequired()
                .HasMaxLength(30);

            Property(x => x.LongType)
                .IsRequired()
                .HasMaxLength(100);

            Property(x => x.Description)
                .HasMaxLength(1000);
        }
    }
}
