using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Evans.Demo.Web.Mvc
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			ViewEngineConfig.RegisterViewEngines(this);
			(_disposable = new ContainerConfig()).Initialize();
		}

		private ContainerConfig _disposable;

		public void Dispose()
		{
			_disposable?.Dispose();
		}
	}
}
