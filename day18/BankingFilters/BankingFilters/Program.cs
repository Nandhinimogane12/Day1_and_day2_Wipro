using BankingFilters.Services;
using BankingFilters.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<LogActionFilter>(); // Global logging
});

builder.Services.AddScoped<ILogService, LogService>();
builder.Services.AddScoped<LogActionFilter>();
builder.Services.AddSession(); // For storing UserRole

var app = builder.Build();

app.UseSession();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();