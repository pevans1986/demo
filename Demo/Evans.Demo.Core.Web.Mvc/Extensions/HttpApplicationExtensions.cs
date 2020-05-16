using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace System.Web
{ 
	public static class HttpApplicationExtensions
	{
		#region Public Methods

		public static void RemoveWebFormViewEngine(this HttpApplication self)
		{
			var webFormEngine = ViewEngines.Engines.FirstOrDefault(e => e is WebFormViewEngine);
			ViewEngines.Engines.Remove(webFormEngine);
		}

		public static void AddViewEngine(this HttpApplication self, IViewEngine viewEngine)
		{
			ViewEngines.Engines.Add(viewEngine);
		}

		#endregion Public Methods
	}
}
