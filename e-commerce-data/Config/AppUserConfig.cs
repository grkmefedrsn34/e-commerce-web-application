using e_commerce_core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_commerce_data.Config
{
    internal class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasColumnType("varchar(80)").HasMaxLength(80);
            builder.Property(x => x.Surname).IsRequired().HasColumnType("varchar(80)").HasMaxLength(80);
            builder.Property(x => x.Email).IsRequired().HasColumnType("varchar(80)").HasMaxLength(80);
            builder.Property(x => x.Email).HasColumnType("varchar(13)").HasMaxLength(13);
            builder.Property(x => x.Password).IsRequired().HasColumnType("varchar(80)").HasMaxLength(80);
            builder.Property(x => x.UserName).HasColumnType("varchar(60)").HasMaxLength(60);
            builder.HasData(
                    new AppUser
                    {
                        ID = 1,
                        UserName = "Admin",
                        Email = "it@eticaret.com",
                        IsActive = true,
                        IsAdmin = true,
                        Name = "Test",
                        Password = "123456789*",
                        Surname = "TestUser"
                    }
                );
        }
    }
}
