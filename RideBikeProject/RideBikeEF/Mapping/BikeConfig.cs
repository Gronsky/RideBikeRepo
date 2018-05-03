﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using RideBikeProjectDAL.Entities;

namespace RideBikeProjectDAL.Mapping
{
    public class BikeConfig : EntityTypeConfiguration<Bike>
    {
        public BikeConfig()
        {
            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.Model)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.Description)
                .HasMaxLength(1000);
        }
    }
}
