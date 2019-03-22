using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Evans.Demo.Core.Extensions.System.Reflection
{
	/// <summary>
	/// Contains extension methods for <see cref="MemberInfo"/>.
	/// </summary>
	/// <remarks>
	/// These are mostly convenience and shortcut methods to keep code cleaner by handling null
	/// checks and other logic.
	/// </remarks>
	public static class MemberInfoExtensions
	{
		#region Public Methods

		/// <summary>
		/// If this type is annotated with the given <see cref="Attribute"/> type , that attribute is
		/// returned. Otherwise, <c>null</c>.
		/// <para>
		/// Note that this will only return a single instance of the attribute. If the attribute can
		/// be defined multiple times, use <see cref="GetAttributes{T}(MemberInfo, bool)"/> instead.
		/// </para>
		/// <para>If the attribute is defined more than once, the first one discovered will be returned.</para>
		/// </summary>
		/// <typeparam name="TAttribute">Attribute type</typeparam>
		/// <param name="self"></param>
		/// <param name="inherit">If true, all parent types well be checked as well</param>
		/// <returns></returns>
		public static TAttribute GetAttribute<TAttribute>(this MemberInfo self, bool inherit = false)
			where TAttribute : Attribute
		{
			return self.GetAttributes<TAttribute>(inherit).FirstOrDefault();
		}

		/// <summary>
		/// Returns an instance of the given <see cref="Attribute"/> type, if it is defined.
		/// Otherwise, a default instance of the attribute will be created and returned.
		/// </summary>
		/// <remarks>This method will never return <c>null</c>.</remarks>
		/// <typeparam name="TAttribute"></typeparam>
		/// <param name="self"></param>
		/// <param name="inherit">If true, all parent types well be checked as well</param>
		/// <returns></returns>
		public static TAttribute GetAttributeOrDefault<TAttribute>(this MemberInfo self, bool inherit = false)
			where TAttribute : Attribute
		{
			var attribute = self.GetAttribute<TAttribute>(inherit);

			return attribute ?? Activator.CreateInstance(typeof(TAttribute)) as TAttribute;
		}

		/// <summary>
		/// If this member is annotated at with the given <see cref="Attribute"/> type , all
		/// instances of that attribute type are returned. Otherwise, an empty list.
		/// </summary>
		/// <typeparam name="TAttribute">Attribute type</typeparam>
		/// <param name="self"></param>
		/// <param name="inherit">If true, all parent types well be checked as well</param>
		/// <returns></returns>
		public static IEnumerable<TAttribute> GetAttributes<TAttribute>(this MemberInfo self, bool inherit = false)
			where TAttribute : Attribute
		{
			var attributes = new List<TAttribute>();

			if (self.HasAttribute<TAttribute>(inherit))
			{
				attributes.AddRange(self.GetCustomAttributes<TAttribute>(inherit));
			}

			return attributes;
		}

		/// <summary>
		/// Determines whether or not this member has an <see cref="Attribute"/> of the given type defined.
		/// <para>
		/// To access the defined attribute(s), use <see cref="GetAttribute{T}(Type, bool)"/> or <see cref="GetAttributes{T}(Type, bool)"/>.
		/// </para>
		/// </summary>
		/// <typeparam name="TAttribute">Attribute Type</typeparam>
		/// <param name="self"></param>
		/// <param name="inherit">If true, all parent types well be checked as well</param>
		/// <returns></returns>
		public static bool HasAttribute<TAttribute>(this MemberInfo self, bool inherit = false)
		{
			return self.HasAttribute(typeof(TAttribute), inherit);
		}

		/// <summary>
		/// Determines whether or not this member has an <see cref="Attribute"/> of the given type defined.
		/// </summary>
		/// <para>
		/// To access the defined attribute(s), use <see cref="GetAttribute{T}(Type, bool)"/> or <see cref="GetAttributes{T}(Type, bool)"/>.
		/// </para>
		/// <param name="self"></param>
		/// <param name="attributeType">Attribute Type</param>
		/// <param name="inherit">If true, all parent types well be checked as well</param>
		/// <returns></returns>
		public static bool HasAttribute(this MemberInfo self, Type attributeType, bool inherit = false)
		{
			return self.IsDefined(attributeType, inherit);
		}

		#endregion Public Methods
	}
}