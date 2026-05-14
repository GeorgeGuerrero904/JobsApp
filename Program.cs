using JobsApp.Models;
using JobsApp.Models.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var applicationConfig = builder.Configuration.Get<AppConfig>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<AppConfig>(applicationConfig);

var serverVersion = ServerVersion.AutoDetect(applicationConfig.ConnectionStrings.DefaultConnection);

// 3. Register the DbContext
builder.Services.AddDbContext<JobsContext>(options =>
    options.UseMySql(applicationConfig.ConnectionStrings.DefaultConnection, serverVersion)
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

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
