using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Evans.Demo.Core.Extensions.System
{
	public static class ObjectExtensions
	{
		#region Public Methods

		/// <summary>
		/// Returns the value of this object's property identified by the given property name.
		/// </summary>
		/// <param name="self"></param>
		/// <param name="propertyName"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException">If no property given</exception>
		public static object GetPropertyValue(this object self, string propertyName)
		{
			if (string.IsNullOrWhiteSpace(propertyName))
			{
				throw new ArgumentException("A property name must be provided.", nameof(propertyName));
			}

			var property = self.GetType().GetProperty(propertyName);
			return property?.GetValue(self, index: null);
		}

		/// <summary>
		/// Returns the value of this object's property identified by the given property name,
		/// cast to type <typeparamref name="T"/>.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="self"></param>
		/// <param name="propertyName"></param>
		/// <returns></returns>
		public static T GetPropertyValue<T>(this object self, string propertyName)
		{
			return (T)self.GetPropertyValue(propertyName);
		}

		/// <summary>
		/// Convenience method that returns an array containing this object.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="self"></param>
		/// <returns></returns>
		public static T[] ToArray<T>(this T self) => new[] { self };

		#endregion Public Methods
	}
}
