using Evans.Demo.Core.Web.Mvc.ViewEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evans.Demo.Web.Mvc
{
	public class ViewEngineConfig
	{
		public static void RegisterViewEngines(MvcApplication app)
		{
			app.RemoveWebFormViewEngine();
			app.AddViewEngine(new HandlebarsViewEngine());
		}
	}
}