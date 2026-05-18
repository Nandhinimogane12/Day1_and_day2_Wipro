using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ECommerceFilters.Filters
{
    /// <summary>
    /// Checks if user is logged in before allowing access
    /// </summary>
    public class CustomAuthenticationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Check session. In real apps use Identity
            var isLoggedIn = context.HttpContext.Session.GetString("UserId") != null;

            if (!isLoggedIn)
            {
                // Redirect to login if not authenticated
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }
        }
    }
}