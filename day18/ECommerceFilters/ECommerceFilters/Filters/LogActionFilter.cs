using Microsoft.AspNetCore.Mvc.Filters;
using ECommerceFilters.Services;

namespace ECommerceFilters.Filters
{
    /// <summary>
    /// Logs request and response details using dependency injection
    /// </summary>
    public class LogActionFilter : IActionFilter
    {
        private readonly ILogService _logService;

        public LogActionFilter(ILogService logService)
        {
            _logService = logService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Before action executes - can log incoming request
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // After action executes - log details
            var controller = context.RouteData.Values["controller"]?.ToString();
            var action = context.RouteData.Values["action"]?.ToString();
            var method = context.HttpContext.Request.Method;
            var url = context.HttpContext.Request.Path;
            var statusCode = context.HttpContext.Response.StatusCode;

            _logService.LogRequest(controller, action, method, url, statusCode);
        }
    }
}