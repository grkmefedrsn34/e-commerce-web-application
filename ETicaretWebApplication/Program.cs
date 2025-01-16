using ETicaret_Data;
using ETicaret_Core;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// ETicaret_Context'i Dependency Injection'a doðru þekilde ekliyoruz.
builder.Services.AddDbContext<ETicaret_Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")+ ";TrustServerCertificate=True;"));

// Controller'lar ve View'lar için gerekli servisleri ekliyoruz.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // HSTS (HTTP Strict Transport Security) etkinleþtirildi.
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Statik dosyalar (CSS, JS, img) için.

app.UseRouting(); // Rota yapýlandýrmasý.

app.UseAuthorization(); // Yetkilendirme mekanizmasý.

app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
