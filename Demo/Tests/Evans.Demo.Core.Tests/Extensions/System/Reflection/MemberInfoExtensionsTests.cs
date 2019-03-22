using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Evans.Demo.Core.Extensions.System.Reflection;
using Evans.Demo.Core.Tests.TestObjects;

using NUnit.Framework;

namespace Evans.Demo.Core.Tests.Extensions.System.Reflection
{
	[TestFixture]
	public class MemberInfoExtensionsTests
	{
		#region Public Methods

		[Test]
		public void GetAttribute_ShouldNotReturnInheritedAttributes()
		{
			var someClassAttribute = typeof(Foo).GetAttribute<SomeClassAttribute>(false);
			Assert.IsNull(someClassAttribute);
		}

		[Test]
		public void GetAttribute_ShouldReturnClassAttributes()
		{
			var descriptionAttribute = typeof(Foo).GetAttribute<MemberDescriptionAttribute>();
			Assert.IsNotNull(descriptionAttribute);
			Assert.AreEqual(Foo.ClassDescriptionValue, descriptionAttribute.Description);

			var uniqueAttribute = typeof(Foo).GetAttribute<UniqueAttribute>();
			Assert.IsNull(uniqueAttribute);
		}

		[Test]
		public void GetAttribute_ShouldReturnInheritedAttributes()
		{
			var someClassAttribute = typeof(Foo).GetAttribute<SomeClassAttribute>(true);
			Assert.IsNotNull(someClassAttribute);
		}

		[Test]
		public void GetAttribute_ShouldReturnMethodAttributes()
		{
			var nameMethod = typeof(Foo).GetMethod(nameof(Foo.GetName));
			var nameUniqueAttribute = nameMethod.GetAttribute<UniqueAttribute>();
			Assert.IsNull(nameUniqueAttribute);

			var nameDescriptionAttribute = nameMethod.GetAttribute<MemberDescriptionAttribute>();
			Assert.IsNotNull(nameDescriptionAttribute);
			Assert.AreEqual(Foo.GetNameDescriptionValue, nameDescriptionAttribute.Description);
		}

		[Test]
		public void GetAttribute_ShouldReturnPropertyAttributes()
		{
			var nameMember = typeof(Foo).GetProperty(nameof(Foo.Name));
			var nameUniqueAttribute = nameMember.GetAttribute<UniqueAttribute>();
			Assert.IsNull(nameUniqueAttribute);

			var nameDescriptionAttribute = nameMember.GetAttribute<MemberDescriptionAttribute>();
			Assert.IsNotNull(nameDescriptionAttribute);
			Assert.AreEqual(Foo.NameDescriptionValue, nameDescriptionAttribute.Description);
		}

		[Test]
		public void GetAttributeOrDefault_ShouldReturnDefaultValues()
		{
			var nameMember = typeof(Foo).GetProperty(nameof(Foo.Name));
			var nameUniqueAttribute = nameMember.GetAttributeOrDefault<UniqueAttribute>();
			Assert.IsNotNull(nameUniqueAttribute);
		}

		[Test]
		public void HasAttribute_ShouldIdentifyMemberWithAttribute()
		{
			Assert.IsTrue(typeof(Foo).HasAttribute<MemberDescriptionAttribute>());
		}

		[Test]
		public void HasAttribute_ShouldIdentifyMemberWithoutAttribute()
		{
			Assert.IsFalse(typeof(Foo).HasAttribute<SomeClassAttribute>());
		}

		#endregion Public Methods
	}
}