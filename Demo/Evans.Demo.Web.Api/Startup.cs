using System;
using System.Collections.Generic;
using System.Linq;

using Evans.Demo.Web.Api;

using Microsoft.Owin;

using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Evans.Demo.Web.Api
{
	public partial class Startup
	{
		#region Public Methods

		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
		}

		#endregion Public Methods
	}
}