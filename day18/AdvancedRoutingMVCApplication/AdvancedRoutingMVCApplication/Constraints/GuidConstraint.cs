namespace AdvancedRoutingApp.Constraints
{
    // Custom constraint: checks if parameter is valid GUID
    public class GuidConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey,
                          RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values.TryGetValue(routeKey, out var value) && value != null)
            {
                string valueString = Convert.ToString(value)!;
                return Guid.TryParse(valueString, out _);
            }
            return false;
        }
    }
}