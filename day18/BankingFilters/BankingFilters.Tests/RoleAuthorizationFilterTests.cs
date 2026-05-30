using BankingFilters.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Xunit;

namespace BankingFilters.Tests
{
    public class RoleAuthorizationFilterTests
    {
        [Fact]
        public void OnAuthorization_Should_Forbid_When_Role_Mismatch()
        {
            // Arrange
            var filter = new RoleAuthorizationFilter("Admin");
            var httpContext = new DefaultHttpContext();
            httpContext.Session = new TestSession();
            httpContext.Session.SetString("UserRole", "User"); // User, not Admin

            var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());
            var context = new AuthorizationFilterContext(actionContext, new List<IFilterMetadata>());

            // Act
            filter.OnAuthorization(context);

            // Assert
            Assert.IsType<ForbidResult>(context.Result);
        }

        public void OnAuthorization_Should_Allow_When_Role_Matches()
        {
            // Arrange
            var filter = new RoleAuthorizationFilter("Admin");
            var httpContext = new DefaultHttpContext();
            httpContext.Session = new TestSession();
            httpContext.Session.SetString("UserRole", "Admin");

            var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());
            var context = new AuthorizationFilterContext(actionContext, new List<IFilterMetadata>());

            // Act
            filter.OnAuthorization(context);

            // Assert
            Assert.Null(context.Result); // No result = allowed
        }
    }

    // Helper class for Session in unit tests
    public class TestSession : ISession
    {
        private Dictionary<string, byte[]> _sessionStorage = new();
        public bool IsAvailable => true;
        public string Id => Guid.NewGuid().ToString();
        public IEnumerable<string> Keys => _sessionStorage.Keys;
        public void Clear() => _sessionStorage.Clear();
        public Task CommitAsync(CancellationToken token = default) => Task.CompletedTask;
        public Task LoadAsync(CancellationToken token = default) => Task.CompletedTask;
        public void Remove(string key) => _sessionStorage.Remove(key);
        public void Set(string key, byte[] value) => _sessionStorage[key] = value;
        public bool TryGetValue(string key, out byte[] value) => _sessionStorage.TryGetValue(key, out value);
    }
}