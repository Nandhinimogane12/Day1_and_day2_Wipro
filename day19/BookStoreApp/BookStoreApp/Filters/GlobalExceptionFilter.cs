using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using BookStoreApp.Services;

namespace BookStoreApp.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogService _logService;
        public GlobalExceptionFilter(ILogService logService) => _logService = logService;

        public void OnException(ExceptionContext context)
        {
            _logService.LogException(context.Exception, context.HttpContext.Request.Path);

            var result = new ViewResult { ViewName = "Error" };
            result.ViewData = new ViewDataDictionary(new Microsoft.AspNetCore.Mvc.ModelBinding.EmptyModelMetadataProvider(),
                                                     new Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary())
            {
                Model = "An error occurred. Please try again."
            };
            context.Result = result;
            context.ExceptionHandled = true;
        }
    }
}