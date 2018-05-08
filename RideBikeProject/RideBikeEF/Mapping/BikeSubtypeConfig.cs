using System.Data.Entity.ModelConfiguration;
using RideBikeProjectDAL.Entities;

namespace RideBikeProjectDAL.Mapping
{
    class BikeSubtypeConfig : EntityTypeConfiguration<BikeSubtype>
    {
        public BikeSubtypeConfig()
        {
            Property(x => x.Subtype)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}