using System.Data.Entity.ModelConfiguration;
using RideBikeProjectDAL.Entities;

namespace RideBikeProjectDAL.Mapping
{
    class ProducerConfig : EntityTypeConfiguration<Producer>
    {
        public ProducerConfig()
        {
            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
