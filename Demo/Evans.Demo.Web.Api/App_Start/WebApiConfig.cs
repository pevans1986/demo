using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

using Microsoft.Owin.Security.OAuth;

using Newtonsoft.Json;

namespace Evans.Demo.Web.Api
{
	public static class WebApiConfig
	{
		#region Public Methods

		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services Configure Web API to use only bearer token authentication.
			config.SuppressDefaultHostAuthentication();
			config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			RegisterFormatters(config);
		}

		#endregion Public Methods

		#region Private Methods

		private static void RegisterFormatters(HttpConfiguration config)
		{
			var formatter = config.Formatters.OfType<JsonMediaTypeFormatter>().FirstOrDefault();
			if (formatter == null)
			{
				formatter = new JsonMediaTypeFormatter();
			}

			config.Formatters.Clear();

			formatter.Indent = true;
			formatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
			config.Formatters.Add(formatter);
		}

		#endregion Private Methods
	}
}