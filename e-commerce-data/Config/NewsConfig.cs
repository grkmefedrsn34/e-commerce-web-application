using e_commerce_core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace e_commerce_data.Config
{
    internal class NewsConfig : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(280);
            builder.Property(x => x.Description).HasMaxLength(680);
            builder.Property(x => x.Image).HasMaxLength(180);
            
        }
    }
}
