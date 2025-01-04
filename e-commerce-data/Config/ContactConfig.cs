using e_commerce_core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce_data.Config
{
    internal class ContactConfig : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(80);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(80);
            builder.Property(x => x.Email).HasMaxLength(80);
            builder.Property(x => x.Phone).HasColumnType("varchar(13)").HasMaxLength(13);
            builder.Property(x => x.Message).IsRequired().HasMaxLength(580);
        }
    }
}
