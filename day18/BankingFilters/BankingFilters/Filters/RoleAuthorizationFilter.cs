using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BankingFilters.Filters
{
    public class RoleAuthorizationFilter : IAuthorizationFilter
    {
        private readonly string _requiredRole;

        public RoleAuthorizationFilter(string requiredRole)
        {
            _requiredRole = requiredRole;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userRole = context.HttpContext.Session.GetString("UserRole");

            if (string.IsNullOrEmpty(userRole) || userRole != _requiredRole)
            {
                context.Result = new ForbidResult(); // 403 Forbidden
            }
        }
    }
}