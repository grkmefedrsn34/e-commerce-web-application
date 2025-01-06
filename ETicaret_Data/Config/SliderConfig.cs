using ETicaret_Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret_Data.Config
{
    internal class SliderConfig : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(280);
            builder.Property(x => x.Description).HasMaxLength(680);
            builder.Property(x => x.Image).HasMaxLength(180);
            builder.Property(x => x.Link).HasMaxLength(180);
        }
    }
}
