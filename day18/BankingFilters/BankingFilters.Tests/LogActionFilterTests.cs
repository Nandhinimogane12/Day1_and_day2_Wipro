using BankingFilters.Filters;
using BankingFilters.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Moq;
using Xunit;

namespace BankingFilters.Tests
{
    public class LogActionFilterTests
    {
        [Fact]
        public void OnActionExecuting_Should_LogAction_With_Executing()
        {
            // Arrange
            var mockLogService = new Mock<ILogService>();
            var filter = new LogActionFilter(mockLogService.Object);

            var httpContext = new DefaultHttpContext();
            httpContext.Session = new TestSession();
            httpContext.Session.SetString("UserRole", "Admin");
            httpContext.Request.Path = "/Account/DeleteAccount";

            var actionContext = new ActionContext(
                httpContext,
                new RouteData(),
                new ActionDescriptor()
            );

            var context = new ActionExecutingContext(
                actionContext,
                new List<IFilterMetadata>(),
                new Dictionary<string, object?>(),
                new Mock<Controller>().Object
            );

            // Act
            filter.OnActionExecuting(context);

            // Assert
            mockLogService.Verify(x => x.LogAction("Executing", "Admin", "/Account/DeleteAccount"), Times.Once);
        }

        public void OnActionExecuted_Should_LogAction_With_Executed()
        {
            // Arrange
            var mockLogService = new Mock<ILogService>();
            var filter = new LogActionFilter(mockLogService.Object);

            var httpContext = new DefaultHttpContext();
            httpContext.Session = new TestSession();
            httpContext.Session.SetString("UserRole", "User");
            httpContext.Request.Path = "/Account/ViewBalance";

            var actionContext = new ActionContext(
                httpContext,
                new RouteData(),
                new ActionDescriptor()
            );

            var context = new ActionExecutedContext(
                actionContext,
                new List<IFilterMetadata>(),
                new Mock<Controller>().Object
            );

            // Act
            filter.OnActionExecuted(context);

            // Assert
            mockLogService.Verify(x => x.LogAction("Executed", "User", "/Account/ViewBalance"), Times.Once);
        }
    }
}