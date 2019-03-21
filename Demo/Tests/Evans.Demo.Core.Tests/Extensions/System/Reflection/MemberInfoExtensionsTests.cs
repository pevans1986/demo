using Evans.Demo.Core.Extensions.System.Reflection;
using Evans.Demo.Core.Tests.TestObjects;
using Moq;
using NUnit.Framework;
using System;
using System.Reflection;

namespace Evans.Demo.Core.Tests.Extensions.System.Reflection
{
	[TestFixture]
	public class MemberInfoExtensionsTests
	{
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
		public void GetAttribute_ShouldReturnPropertyAttributes()
		{
			var nameMember = typeof(Foo).GetProperty(nameof(Foo.Name));
			var nameUniqueAttribute = nameMember.GetAttribute<UniqueAttribute>();
			Assert.IsNull(nameUniqueAttribute);

			var nameDescriptionAttribute = nameMember.GetAttribute<MemberDescriptionAttribute>();
			Assert.IsNotNull(nameDescriptionAttribute);
			Assert.AreEqual(Foo.NameDescriptionValue, nameDescriptionAttribute.Description);
		}

		// TODO Test attributes on methods

		//[Test]
		//public void GetAttributeOrDefault_StateUnderTest_ExpectedBehavior()
		//{
		//	// Arrange
		//	var unitUnderTest = this.CreateMemberInfoExtensions();
		//	MemberInfo self = TODO;
		//	bool inherit = TODO;

		//	// Act
		//	var result = unitUnderTest.GetAttributeOrDefault(
		//		self,
		//		inherit);

		//	// Assert
		//	Assert.Fail();
		//}

		//[Test]
		//public void GetAttributes_StateUnderTest_ExpectedBehavior()
		//{
		//	// Arrange
		//	var unitUnderTest = this.CreateMemberInfoExtensions();
		//	MemberInfo self = TODO;
		//	bool inherit = TODO;

		//	// Act
		//	var result = unitUnderTest.GetAttributes(
		//		self,
		//		inherit);

		//	// Assert
		//	Assert.Fail();
		//}

		//[Test]
		//public void HasAttribute_StateUnderTest_ExpectedBehavior()
		//{
		//	// Arrange
		//	var unitUnderTest = this.CreateMemberInfoExtensions();
		//	MemberInfo self = TODO;
		//	bool inherit = TODO;

		//	// Act
		//	var result = unitUnderTest.HasAttribute(
		//		self,
		//		inherit);

		//	// Assert
		//	Assert.Fail();
		//}

		//[Test]
		//public void HasAttribute_StateUnderTest_ExpectedBehavior1()
		//{
		//	// Arrange
		//	var unitUnderTest = this.CreateMemberInfoExtensions();
		//	MemberInfo self = TODO;
		//	Type attributeType = TODO;
		//	bool inherit = TODO;

		//	// Act
		//	var result = unitUnderTest.HasAttribute(
		//		self,
		//		attributeType,
		//		inherit);

		//	// Assert
		//	Assert.Fail();
		//}
	}
}
