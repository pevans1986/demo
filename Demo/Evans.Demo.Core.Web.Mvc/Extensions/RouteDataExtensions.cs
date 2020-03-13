using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace Evans.Demo.Core.Web.Mvc.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="RouteData" /> for MVC routing.
    /// </summary>
    public static class RouteDataExtensions
    {
        #region Methods

        /// <summary>
        /// Extracts the area name from the request path. If an area has not been specified or
        /// found, an empty <see cref="string" /> will be returned.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string GetAreaName(this RouteData self)
        {
            return self.Values[MvcRouter.RouteDataAreaName]
                ?.ToString()
                ?? string.Empty;
        }

        #endregion Methods
    }
}
