using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace RoutingApp
{
    public class MyCustomConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            values.TryGetValue(routeKey, out object value);

            if (value == null || !(value is string stringValue)) return false;

            return stringValue.StartsWith("0");
        }
    }
}
