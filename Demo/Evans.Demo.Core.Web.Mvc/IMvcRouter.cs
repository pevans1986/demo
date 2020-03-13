using Evans.Demo.Core.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Evans.Demo.Core.Web.Mvc
{
	public interface IMvcRouter : IRouter
	{
		#region Properties

		IDictionary<string, Type> DataModelCache { get; }

		#endregion Properties

		#region Methods

		ActionResult RouteDynamicRequest(RouteInfo routeInfo);

		#endregion Methods
	}
}
