using Microsoft.AspNetCore.Mvc.Filters;
using BookStoreApp.Services;

namespace BookStoreApp.Filters
{
    public class LogActionFilter : IActionFilter
    {
        private readonly ILogService _logService;

        public LogActionFilter(ILogService logService)
        {
            _logService = logService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.Session.GetString("Username") ?? "Anonymous";
            var path = context.HttpContext.Request.Path;
            _logService.LogAction("Executing", user, path);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var user = context.HttpContext.Session.GetString("Username") ?? "Anonymous";
            var path = context.HttpContext.Request.Path;
            _logService.LogAction("Executed", user, path);
        }
    }
}