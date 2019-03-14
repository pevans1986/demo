using NUnit.Framework;
using Evans.Demo.Core.Extensions.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evans.Demo.Core.Extensions.System.Tests
{
	[TestFixture()]
	public class StringExtensionsTests
	{
		[Test]
		public void CollapseSpaces_ShouldCollapseAllInstances()
		{
			const string expectedValue = "This has multiple consecutive spaces";
			const string testValue = "This    has multiple   consecutive      spaces";
			string collapsed = testValue.CollapseSpaces();

			Assert.AreEqual(expectedValue, collapsed);
		}

		[Test]
		public void EqualsIgnoreCase_ShouldMatchStringsWithOnlyCaseDifferences()
		{
			const string value1 = "These Should Be Equal";
			const string value2 = "these should be equal";

			Assert.IsTrue(value1.EqualsIgnoreCase(value2));
		}

		[Test]
		public void EqualsIgnoreCase_ShouldNotMatchStringsWithOtherDifferences()
		{
			const string value1 = "These Should Not Be Equal";
			const string value2 = "these should n0t be equal";

			Assert.IsFalse(value1.EqualsIgnoreCase(value2));
		}

		[Test]
		public void IfBlankThen_ShouldIdentifyBlankStrings([Values("", "  ", null)] string value)
		{
			const string alternateText = "alternate";
			var result = value.IfBlankThen(alternateText);

			Assert.AreEqual(alternateText, result);
		}

		[Test]
		public void IfBlankThen_ShouldIdentifyNonBlankStrings()
		{
			var testString = "Test String";
			const string alternateText = "alternate";
			var result = testString.IfBlankThen(alternateText);

			Assert.AreEqual(testString, result);
		}

		[Test]
		public void IsBlank_ShouldIdentifyNullBlankOrEmptyStrings([Values("", " ", null)] string value)
		{
			Assert.IsTrue(value.IsBlank());
		}

		[Test]
		public void IsBlank_ShouldIdentifyNonNullBlankOrEmptyStrings()
		{
			const string testString = "Not blank";

			Assert.IsFalse(testString.IsBlank());
		}

		[Test]
		public void IsLongerThan_ShouldCheckStringLength()
		{
			Assert.IsTrue("More than 5 characters".IsLongerThan(5));
			Assert.IsFalse("123".IsLongerThan(3));
			Assert.IsFalse("123".IsLongerThan(4));
		}

		[Test]
		public void IsNonBlank_ShouldIdentifyNonBlankStrings([Values("not blank", "notblank")] string value)
		{
			Assert.IsTrue(value.IsNonBlank());
		}

		[Test]
		public void IsNonBlank_ShouldIdentifyBlankStrings([Values("", "   ", null)] string value)
		{
			Assert.IsFalse(value.IsNonBlank());
		}

		[Test]
		public void IsShorterThan_ShouldCheckStringLength()
		{
			Assert.IsFalse("More than 5 characters".IsShorterThan(5));
			Assert.IsFalse("123".IsShorterThan(3));
			Assert.IsTrue("123".IsShorterThan(4));
		}

		[Test]
		public void StartsWithIgnoreCase_ShouldMatchStringsWithCaseDifference()
		{
			Assert.IsTrue("abc".StartsWithIgnoreCase("A"));
			Assert.IsTrue("abc".StartsWithIgnoreCase("AB"));
		}

		[Test]
		public void ToSeparateWords_ShouldSplitCamelCase()
		{
			Assert.AreEqual("splitCamelCase".ToSeparateWords(), "split Camel Case");
		}

		[Test]
		public void ToSeparateWords_ShouldSplitTitleCase()
		{
			Assert.AreEqual("SplitTitleCase".ToSeparateWords(), "Split Title Case");
		}

		[Test]
		public void Truncate_ShouldReturnTruncatedString()
		{
			Assert.AreEqual("12345".Truncate(3), "123");
			Assert.AreEqual("12".Truncate(3), "12");
		}
	}
}