using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace Evans.Demo.Core.Extensions.System.Tests
{
	[TestFixture]
	public class ObjectExtensionsTests
	{
		#region Private Fields

		private readonly Person _person = new Person
		{
			Name = "Test Person",
			Age = 30,
			Relatives = new Person[]
			{
				new Person(), new Person()
			}
		};

		#endregion Private Fields

		#region Public Methods

		[Test]
		public void GetPropertyValue_ShouldGetValueAsObject()
		{
			var name = _person.GetPropertyValue(nameof(Person.Name));
			Assert.AreEqual(_person.Name, name);
		}

		[Test]
		public void GetPropertyValue_ShouldGetValueWithType()
		{
			int age = _person.GetPropertyValue<int>(nameof(Person.Age));
			IEnumerable<Person> relatives = _person.GetPropertyValue<IEnumerable<Person>>(nameof(Person.Relatives));

			Assert.AreEqual(_person.Age, age);
			Assert.AreEqual(_person.Relatives, relatives);
		}

		#endregion Public Methods

		#region Private Classes

		private class Person
		{
			#region Public Properties

			public int Age { get; set; }

			public string Name { get; set; }

			public IEnumerable<Person> Relatives { get; set; }

			#endregion Public Properties
		}

		#endregion Private Classes
	}
}