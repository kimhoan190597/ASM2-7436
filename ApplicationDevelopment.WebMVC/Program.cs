using ApplicationDevelopment.WebMVC.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("MVCAppConnection")
        ?? throw new InvalidOperationException("Connection string"
        + "'MVCAppConnection' not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<DataService>();

var app = builder.Build();

var isDevelopEnvironment = app.Environment.IsDevelopment();
var isProductionEnvironment = app.Environment.IsProduction();
// Configure the HTTP request pipeline.
if (!isDevelopEnvironment)
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


if (isDevelopEnvironment)
{
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Enterprise}/{action=Create}/{id?}");
} else
{
    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
}
    

app.Run();
