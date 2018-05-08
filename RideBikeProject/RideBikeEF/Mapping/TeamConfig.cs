using System.Data.Entity.ModelConfiguration;
using RideBikeProjectDAL.Entities;

namespace RideBikeProjectDAL.Mapping
{
    class TeamConfig : EntityTypeConfiguration<Team>
    {
        public TeamConfig()
        {
            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.Location)
                .HasMaxLength(200);

            Property(x => x.Location)
                .HasMaxLength(1000);
        }
    }
}
