using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SecureTaskManager.Data;
using SecureTaskManager.Models;

var builder = WebApplication.CreateBuilder(args);

//
// DATABASE
//
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

//
// IDENTITY
//
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    // Password settings
    options.Password.RequireDigit = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequiredLength = 8;

    // Lockout settings
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

    // User settings
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

//
// COOKIE SETTINGS
//
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;

    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;

    options.Cookie.SameSite = SameSiteMode.Strict;

    options.LoginPath = "/Account/Login";

    options.AccessDeniedPath = "/Account/AccessDenied";

    options.ExpireTimeSpan = TimeSpan.FromMinutes(15);

    options.SlidingExpiration = true;
});

//
// AUTHORIZATION
//
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CanEditTaskPolicy",
        policy => policy.RequireClaim("CanEditTask", "true"));
});

//
// ANTI-FORGERY
//
builder.Services.AddAntiforgery(options =>
{
    options.HeaderName = "X-CSRF-TOKEN";
});

//
// SESSION
//
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(15);

    options.Cookie.HttpOnly = true;

    options.Cookie.IsEssential = true;

    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

//
// MVC
//
builder.Services.AddControllersWithViews();

var app = builder.Build();

//
// ERROR HANDLING
//
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

//
// HTTPS
//
app.UseHttpsRedirection();

//
// STATIC FILES
//
app.UseStaticFiles();

app.UseRouting();

//
// AUTHENTICATION
//
app.UseAuthentication();

//
// AUTHORIZATION
//
app.UseAuthorization();

//
// SESSION
//
app.UseSession();

//
// ROUTING
//
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();