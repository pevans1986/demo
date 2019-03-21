using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evans.Demo.Core.Tests.TestObjects
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
	public class MemberDescriptionAttribute : Attribute
	{
		#region Public Constructors

		public MemberDescriptionAttribute(string description) => Description = description;

		#endregion Public Constructors

		#region Public Properties

		public string Description { get; set; }

		#endregion Public Properties
	}
}