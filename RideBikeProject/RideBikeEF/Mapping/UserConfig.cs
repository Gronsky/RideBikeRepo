using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using RideBikeProjectDAL.Entities;

namespace RideBikeProjectDAL.Mapping
{
    class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
