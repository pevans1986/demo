using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Evans.Demo.Core.Extensions.System
{
	public static class StringExtensions
	{
		/// <summary>
		/// Replaces any occurrences of multiple consecutive spaces with a single space.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static string CollapseSpaces(this string self)
		{
			return Regex.Replace(self, @"\s+", " ");
		}

		/// <summary>
		/// Compares this string to the given value and returns the result of an equality check using
		/// <see cref="StringComparison.CurrentCultureIgnoreCase"/>.
		/// </summary>
		/// <param name="self"></param>
		/// <param name="compValue"></param>
		/// <returns></returns>
		public static bool EqualsIgnoreCase(this string self, string compValue)
		{
			return self.Equals(compValue, StringComparison.CurrentCultureIgnoreCase);
		}

		/// <summary>
		/// If the string is null, empty, or whitespace, returns "otherText".
		/// </summary>
		public static string IfBlankThen(this string text, string otherText)
		{
			return string.IsNullOrWhiteSpace(text) ? otherText : text;
		}

		/// <summary>
		/// Returns <c>true</c> if string is <c>null</c>, empty, or contains only whitespace.
		/// </summary>
		public static bool IsBlank(this string self)
		{
			return string.IsNullOrWhiteSpace(self);
		}

		/// <summary>
		/// Returns whether or not the length of this string is greater than the given length. This
		/// method handles checking for null, blank, and empty values. Blank values are treated as a
		/// length of 0.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="length"></param>
		/// <returns></returns>
		public static bool IsLongerThan(this string value, int length)
		{
			if (value.IsBlank())
			{
				return false;
			}

			return (value.Length > length);
		}

		/// <summary>
		/// Return TRUE if string contains non-whitespace characters.
		/// </summary>
		public static bool IsNonBlank(this string text)
		{
			return !string.IsNullOrWhiteSpace(text);
		}

		/// <summary>
		/// Returns whether or not the length of this string is shorter than the given length. This
		/// method handles checking for null, blank, and empty values. Blank values are treated as a
		/// length of 0.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="length"></param>
		/// <returns></returns>
		public static bool IsShorterThan(this string value, int length)
		{
			if (value.IsBlank())
			{
				return true;
			}

			return value.Length < length;
		}

		/// <summary>
		/// Checks if this <c>string</c> starts with the given value, ignoring case.
		/// </summary>
		/// <param name="self"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <seealso cref="string.StartsWith(string)"/>
		/// <seealso cref="StringComparison.CurrentCultureIgnoreCase"/>
		public static bool StartsWithIgnoreCase(this string self, string value)
		{
			return self.StartsWith(value, StringComparison.CurrentCultureIgnoreCase);
		}

		/// <summary>
		/// Converts CamelCase strings to Separate Words (e.g. Camel Case).
		/// </summary>
		public static string ToSeparateWords(this string value)
		{
			return Regex.Replace(value, "([A-Z][a-z])", " $1").Trim();
		}

		/// <summary>
		/// If the value of this <see cref="string"/> is longer than the given maximum number of
		/// characters, the value will be truncated to the maximum length.
		/// </summary>
		/// <param name="self"></param>
		/// <param name="maxLength"></param>
		/// <returns></returns>
		public static string Truncate(this string self, int maxLength)
		{
			if (self.IsLongerThan(maxLength))
			{
				return self.Substring(0, maxLength);
			}

			return self;
		}
	}
}
