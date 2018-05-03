using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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