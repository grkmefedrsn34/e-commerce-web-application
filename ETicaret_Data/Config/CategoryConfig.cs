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
    internal class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(80);
            builder.Property(x => x.Image).HasMaxLength(50);
            builder.HasData(
                    new Category
                    {
                        Name = "Elektronik",
                        ID = 1,
                        IsActive = true,
                        IsTopMenu = true,
                        ParentID = 0,
                        OrderNo = 1,
                    },
                    new Category
                    {
                        Name = "Bilgisayar",
                        ID = 1907,
                        IsActive = true,
                        IsTopMenu = true,
                        ParentID = 1881,
                        OrderNo = 1907,
                    }
                );
        }
    }
}
