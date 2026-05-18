using ECommerceRoutingApp.Constraints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("pricerange", typeof(PriceRangeConstraint));
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// User Story 1: Complex route
app.MapControllerRoute(
    name: "product_details",
    pattern: "Products/{category}/{id:int}",
    defaults: new { controller = "Products", action = "Details" });

// User Story 2: Dynamic route for checkout
app.MapControllerRoute(
    name: "checkout",
    pattern: "Checkout",
    defaults: new { controller = "Cart", action = "Checkout" });

// User Story 3: Custom constraint for filter
app.MapControllerRoute(
    name: "product_filter",
    pattern: "Products/Filter/{category}/{priceRange:pricerange}",
    defaults: new { controller = "Products", action = "Filter" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
public partial class Program { }
