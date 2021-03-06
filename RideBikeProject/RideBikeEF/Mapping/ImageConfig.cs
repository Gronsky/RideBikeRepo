﻿using System.Data.Entity.ModelConfiguration;
using RideBikeProjectDAL.Entities;

namespace RideBikeProjectDAL.Mapping
{
    class ImageConfig : EntityTypeConfiguration<Image>
    {
        public ImageConfig()
        {
            Property(x => x.Source)
                .IsRequired()
                .HasMaxLength(1000);
        }
    }
}