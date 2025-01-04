using e_commerce_core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace e_commerce_data.Config
{
    internal class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(180);
            builder.Property(x => x.Image).HasMaxLength(180);
            builder.Property(X => X.ProductCode).HasMaxLength(50);

        }
    }
}
