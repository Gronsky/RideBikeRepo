using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
