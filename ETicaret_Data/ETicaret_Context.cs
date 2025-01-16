using Microsoft.EntityFrameworkCore;
using ETicaret_Core.Entities;
using ETicaret_Data.Config;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ETicaret_Data
{
    public class ETicaret_Context : DbContext
    {
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Slider> Sliders { get; set; }

        public ETicaret_Context(DbContextOptions<ETicaret_Context> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-1PSJFDO\GRKMEFEDRSN34;Initial Catalog=MCV_ETİCARET_CORE_DB;Integrated Security=True;TrustServerCertificate=True;");
                optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore
                    (RelationalEventId.PendingModelChangesWarning));
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserConfig());
            modelBuilder.ApplyConfiguration(new BrandConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new ContactConfig());
            modelBuilder.ApplyConfiguration(new NewsConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new SliderConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
