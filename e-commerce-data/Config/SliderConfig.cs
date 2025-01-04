using e_commerce_core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace e_commerce_data.Config
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
