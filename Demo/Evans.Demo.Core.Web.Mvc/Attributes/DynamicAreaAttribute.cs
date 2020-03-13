using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evans.Demo.Core.Web.Mvc.Attributes
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class DynamicAreaAttribute : Attribute
	{
		#region Constructors
		
		public DynamicAreaAttribute(string areaName = "")
		{
			AreaName = areaName;
		}

		#endregion Constructors

		#region Properties

		public string AreaName { get; set; }

		#endregion Properties
	}
}
