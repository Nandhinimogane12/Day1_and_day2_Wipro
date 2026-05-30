using AdvancedRoutingApp.Constraints; // We will create this

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Register custom route constraint
builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("guidcheck", typeof(GuidConstraint));
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// 1. Complex Routes
app.MapControllerRoute(
    name: "product_details",
    pattern: "Products/{category}/{id:int}",
    defaults: new { controller = "Products", action = "Details" });

app.MapControllerRoute(
    name: "user_orders",
    pattern: "Users/{username}/Orders",
    defaults: new { controller = "Users", action = "Orders" });

// 2. Dynamic Route based on role - handled in controller
app.MapControllerRoute(
    name: "dashboard",
    pattern: "Dashboard",
    defaults: new { controller = "Account", action = "Dashboard" });

// 3. Route with Custom Constraint
app.MapControllerRoute(
    name: "guid_route",
    pattern: "Reports/{reportId:guidcheck}",
    defaults: new { controller = "Reports", action = "View" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
