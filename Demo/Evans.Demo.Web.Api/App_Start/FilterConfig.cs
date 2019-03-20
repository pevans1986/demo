using System.Web.Mvc;

namespace Evans.Demo.Web.Api
{
	public static class FilterConfig
	{
		#region Public Methods

		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}

		#endregion Public Methods
	}
}