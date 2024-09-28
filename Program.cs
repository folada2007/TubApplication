using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Philharmonic.Areas.NotCookiesProject.Models;
using Philharmonic.Areas.NotCookiesProject.Services;
using Philharmonic.Models;
using Philharmonic.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped <PasswordHasher<User>>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IAuthService, AuthenticationService>();
builder.Services.AddScoped<IFileChecking, FileChecking>();
builder.Services.AddScoped<ISaveDb, SaveDb>();
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => 
    {
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
        options.Cookie.Name = "AuthCookies";
        options.LoginPath = "/Auth/Login";
        options.LogoutPath = "/Auth/LogOut";
    });
builder.Services.AddAuthorization();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app =  builder.Build();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "AreasPage",
    pattern: "{area:exists}/{controller=home}/{action=index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=index}/{id?}");

app.Run();
