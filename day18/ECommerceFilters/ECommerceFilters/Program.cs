using ECommerceFilters.Filters;
using ECommerceFilters.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllersWithViews(options =>
{
    // User Story 2: Apply globally
    options.Filters.Add<LogActionFilter>();
    options.Filters.Add<GlobalExceptionFilter>();
});

// User Story 1: Register dependencies for DI
builder.Services.AddScoped<ILogService, LogService>();
builder.Services.AddScoped<CustomAuthenticationFilter>();

builder.Services.AddSession();

var app = builder.Build();

app.UseSession();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();