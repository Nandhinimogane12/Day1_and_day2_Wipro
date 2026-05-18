namespace ECommerceRoutingApp.Constraints
{
    public class PriceRangeConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey,
                          RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values.TryGetValue(routeKey, out var value) && value != null)
            {
                string[] prices = Convert.ToString(value)!.Split('-');
                if (prices.Length == 2 &&
                    decimal.TryParse(prices[0], out decimal min) &&
                    decimal.TryParse(prices[1], out decimal max))
                {
                    return min >= 0 && max > min;
                }
            }
            return false;
        }
    }
}