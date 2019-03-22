using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evans.Demo.Core.Tests.TestObjects
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class SomeClassAttribute : Attribute
	{
	}
}