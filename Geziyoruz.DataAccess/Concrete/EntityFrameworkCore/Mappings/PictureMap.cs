﻿using Geziyoruz.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Geziyoruz.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class PictureMap : EntityMap<Picture>
    {
        public override void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.HasKey(x => x.Id);
            base.Configure(builder);
        }
    }
}
