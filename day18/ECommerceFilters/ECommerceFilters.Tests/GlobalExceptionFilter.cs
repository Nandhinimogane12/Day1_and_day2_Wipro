using ECommerceFilters.Filters;
using ECommerceFilters.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Moq;
using Xunit;

namespace ECommerceFilters.Tests
{
    public class GlobalExceptionFilterTests
    {
        [Fact]
        public void OnException_Should_LogException_And_HandleException()
        {
            // Arrange
            var mockLogService = new Mock<ILogService>();
            var mockEnv = new Mock<IWebHostEnvironment>();

            var filter = new GlobalExceptionFilter(mockLogService.Object, mockEnv.Object);

            var httpContext = new DefaultHttpContext();
            httpContext.Request.Path = "/Product/Details";

            var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor(), new ModelStateDictionary());
            var context = new ExceptionContext(actionContext, new List<IFilterMetadata>())
            {
                Exception = new Exception("Test error")
            };

            // Act
            filter.OnException(context);

            // Assert
            mockLogService.Verify(x => x.LogException(It.IsAny<Exception>(), "/Product/Details"), Times.Once);
            Assert.True(context.ExceptionHandled);
            Assert.IsType<ViewResult>(context.Result);
        }
    }
}