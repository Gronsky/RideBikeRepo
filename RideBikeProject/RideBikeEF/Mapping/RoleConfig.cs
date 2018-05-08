using System.Data.Entity.ModelConfiguration;
using RideBikeProjectDAL.Entities;

namespace RideBikeProjectDAL.Mapping
{
    class RoleConfig : EntityTypeConfiguration<Role>
    {
        public RoleConfig()
        {
            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
