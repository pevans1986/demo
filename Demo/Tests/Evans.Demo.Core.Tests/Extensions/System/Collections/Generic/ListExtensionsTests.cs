using Evans.Demo.Core.Extensions.System.Collections.Generic;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Evans.Demo.Core.Tests.Extensions.System.Collections.Generic
{
	[TestFixture]
	public class ListExtensionsTests
	{
		#region Private Fields

		private List<string> _list;

		#endregion Private Fields

		#region Public Methods

		[Test]
		public void AddIfUnique_ShouldAddUniqueItems()
		{
			string item1 = "Test1";
			string item2 = "Test2";

			_list.AddIfUnique(item1);
			Assert.AreEqual(1, _list.Count);

			_list.AddIfUnique(item2);
			Assert.AreEqual(2, _list.Count);
		}

		[Test]
		public void AddIfUnique_ShouldNotAddExistingItems()
		{
			string item = "Test";

			_list.AddIfUnique(item);
			Assert.AreEqual(1, _list.Count);

			_list.AddIfUnique(item);
			Assert.AreEqual(1, _list.Count);
		}

		[SetUp]
		public void Setup()
		{
			_list = new List<string>();
		}

		#endregion Public Methods
	}
}