using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
