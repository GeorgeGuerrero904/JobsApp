using JobsApp.Models;
using JobsApp.Models.Database.Migrations;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var applicationConfig = builder.Configuration.Get<AppConfig>();
if (applicationConfig == null)
{
    throw new Exception("Failed to load application configuration.");
}

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton(applicationConfig);

//Adding authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.SlidingExpiration = true;
    });

// 3. Register the DbContext
builder.Services.AddDbContext<JobsContext>(options =>
    options.UseMySql(applicationConfig.ConnectionStrings.DefaultConnection, ServerVersion.AutoDetect(applicationConfig.ConnectionStrings.DefaultConnection))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
