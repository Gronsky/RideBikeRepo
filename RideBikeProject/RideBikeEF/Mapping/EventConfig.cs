using System.Data.Entity.ModelConfiguration;
using RideBikeProjectDAL.Entities;

namespace RideBikeProjectDAL.Mapping
{
    class EventConfig : EntityTypeConfiguration<Event>
    {
        public EventConfig()
        {
            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.Location)
                .IsRequired()
                .HasMaxLength(200);

            Property(x => x.Description)
                .HasMaxLength(1000);
        }
    }
}
