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
