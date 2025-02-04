using ETicaret_Data;
using ETicaret_Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using DotNetOpenAuth.InfoCard;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSession( O =>
{
    O.Cookie.Name = "Eticaret.Session";
    O.Cookie.HttpOnly = true;
    O.Cookie.IsEssential = true;
    O.IdleTimeout = TimeSpan.FromDays(1);
    O.IOTimeout = TimeSpan.FromMinutes(1);
}
);

// Add services to the container.
// ETicaret_Context'i Dependency Injection'a doðru þekilde ekliyoruz.
builder.Services.AddDbContext<ETicaret_Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")+ ";TrustServerCertificate=True;"));

// Controller'lar ve View'lar için gerekli servisleri ekliyoruz.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x=>
    { x.LoginPath = "/Account/SingIn";
      x.AccessDeniedPath = "/AccessDenied";
        x.Cookie.Name = "Account";
        x.Cookie.MaxAge = TimeSpan.FromDays(7);
        x.Cookie.IsEssential = true;
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireClaim("Role", "Admin"));
    options.AddPolicy("UserPolicy", policy => policy.RequireClaim("Role", "Admin", "User", "Customer"));
});


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
app.UseSession();

app.UseAuthorization();// önce oturum açma

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
