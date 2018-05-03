using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using RideBikeProjectDAL.Entities;

namespace RideBikeProjectDAL.Mapping
{
    class BikeTypeConfig : EntityTypeConfiguration<BikeType>
    {
        public BikeTypeConfig()
        {
            Property(x => x.Type)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}