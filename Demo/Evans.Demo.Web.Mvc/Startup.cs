using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Evans.Demo.Web.Mvc.Startup))]

namespace Evans.Demo.Web.Mvc
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
			//ViewEngineConfig.RegisterViewEngines(app);
		}
	}
}
