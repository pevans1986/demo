using System.Web.Mvc;

namespace Evans.Demo.Web.Api
{
	/// <summary>
	/// Initializes MVC filters
	/// </summary>
	public static class FilterConfig
	{
		#region Public Methods

		/// <summary>
		/// Initializes global MVC filters
		/// </summary>
		/// <param name="filters"></param>
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}

		#endregion Public Methods
	}
}