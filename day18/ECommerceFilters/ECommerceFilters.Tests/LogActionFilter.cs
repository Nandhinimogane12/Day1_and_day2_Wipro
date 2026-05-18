using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Moq;
using ECommerceFilters.Filters;
using ECommerceFilters.Services;
using Xunit;

namespace ECommerceFilters.Tests
{
    public class LogActionFilterTests
    {
        [Fact]
        public void OnActionExecuted_CallsLogRequest_WithCorrectData()
        {
            // Arrange
            var mockLogService = new Mock<ILogService>();
            var filter = new LogActionFilter(mockLogService.Object);

            var httpContext = new DefaultHttpContext();
            httpContext.Request.Method = "GET";
            httpContext.Request.Path = "/Product/Index";
            httpContext.Response.StatusCode = 200;

            var routeData = new RouteData();
            routeData.Values["controller"] = "Product";
            routeData.Values["action"] = "Index";

            var actionContext = new ActionContext(httpContext, routeData, new ActionDescriptor());
            var context = new ActionExecutedContext(actionContext, new List<IFilterMetadata>(), null);

            // Act
            filter.OnActionExecuted(context);

            // Assert
            mockLogService.Verify(x => x.LogRequest(
                "Product", // controller
                "Index", // action 
                "GET", // method
                "/Product/Index", // url
                200), // statusCode
                Times.Once);
        }
    }
}