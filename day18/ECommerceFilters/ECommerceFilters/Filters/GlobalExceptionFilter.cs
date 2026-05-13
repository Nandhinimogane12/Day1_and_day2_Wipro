using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ECommerceFilters.Services;
using Microsoft.AspNetCore.Hosting;

namespace ECommerceFilters.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogService _logService;
        private readonly IWebHostEnvironment _env;

        public GlobalExceptionFilter(ILogService logService, IWebHostEnvironment env)
        {
            _logService = logService;
            _env = env;
        }

        public void OnException(ExceptionContext context)
        {
            _logService.LogException(context.Exception, context.HttpContext.Request.Path);
            context.Result = new ViewResult { ViewName = "Error" };
            context.ExceptionHandled = true;
        }
    }
}