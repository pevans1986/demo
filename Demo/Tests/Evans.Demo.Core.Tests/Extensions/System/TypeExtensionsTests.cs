using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace Evans.Demo.Core.Extensions.System.Tests
{
	[TestFixture]
	public class TypeExtensionsTests
	{
		#region Private Interfaces

		private interface IBar { }

		private interface IFoo { }

		#endregion Private Interfaces

		#region Public Methods

		[Test]
		public void Implements_ShouldDetectIfInterfaceIsImplemented()
		{
			Type barType = typeof(Bar);
			Type fooType = typeof(Foo);
			Type fooBarType = typeof(FooBar);

			Assert.IsTrue(barType.Implements(typeof(IBar)));
			Assert.IsFalse(barType.Implements(typeof(IFoo)));

			Assert.IsFalse(fooType.Implements(typeof(IBar)));
			Assert.IsTrue(fooType.Implements(typeof(IFoo)));

			Assert.IsTrue(fooBarType.Implements(typeof(IBar)));
			Assert.IsTrue(fooBarType.Implements(typeof(IFoo)));
		}

		[Test]
		public void Implements_TypeParameter_ShouldDetectIfInterfaceIsImplemented()
		{
			Type barType = typeof(Bar);
			Type fooType = typeof(Foo);
			Type fooBarType = typeof(FooBar);

			Assert.IsTrue(barType.Implements<IBar>());
			Assert.IsFalse(barType.Implements<IFoo>());

			Assert.IsFalse(fooType.Implements<IBar>());
			Assert.IsTrue(fooType.Implements<IFoo>());

			Assert.IsTrue(fooBarType.Implements<IBar>());
			Assert.IsTrue(fooBarType.Implements<IFoo>());
		}

		#endregion Public Methods

		#region Private Classes

		private class Bar : IBar { }

		private class Foo : IFoo { }

		private class FooBar : IFoo, IBar { }

		#endregion Private Classes
	}
}