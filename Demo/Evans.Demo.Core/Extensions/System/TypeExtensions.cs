using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evans.Demo.Core.Extensions.System
{
	/// <summary>
	/// Contains extension methods for <see cref="Type"/>. These are mostly convenience and shortcut
	/// methods to keep code cleaner by handling null checks and frequently repeated logic.
	/// </summary>
	public static class TypeExtensions
	{
		#region Public Methods

		/// <summary>
		/// Returns whether or not this Type implements the given Interface type.
		/// </summary>
		/// <typeparam name="TInterface"></typeparam>
		/// <param name="self"></param>
		/// <returns></returns>
		public static bool Implements<TInterface>(this Type self)
		{
			return self.Implements(typeof(TInterface));
		}

		/// <summary>
		/// Returns whether or not this Type implements the given Interface type.
		/// </summary>
		/// <param name="self"></param>
		/// <param name="interfaceType"></param>
		/// <returns></returns>
		public static bool Implements(this Type self, Type interfaceType)
		{
			if (interfaceType == null)
			{
				return false;
			}

			return self.GetInterface(interfaceType.Name, ignoreCase: true) != null;
		}

		#endregion Public Methods
	}
}