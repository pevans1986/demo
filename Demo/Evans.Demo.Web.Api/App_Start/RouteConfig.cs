using System.Web.Mvc;
using System.Web.Routing;

namespace Evans.Demo.Web.Api
{
	/// <summary>
	/// Defines base URL routing for the Web API.
	/// </summary>
	public static class RouteConfig
	{
		/// <summary>
		/// Registers specific URLs and URL patterns for identifying the correct API controller
		/// method that should be called to handle a given route.
		/// </summary>
		/// <param name="routes">Container for the defined explicit and pattern-based route matches.</param>
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
