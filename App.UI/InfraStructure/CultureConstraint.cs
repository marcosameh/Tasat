using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;

namespace App.UI.InfraStructure
{

    public class CultureConstraint : IRouteConstraint
    {
   
        private HashSet<string> langList = new HashSet<string>()
        {
            "de",
            "es",
            "fr",
            "nl"
        };
        public bool Match(HttpContext httpContext, IRouter route, string routeKey,
                            RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (!values.ContainsKey(routeKey))
                return false;

            string locale = values[routeKey] as string;

            if (string.IsNullOrWhiteSpace(locale))
                return false;

            return langList.Any(x=> x == locale);
        }
    }

}
