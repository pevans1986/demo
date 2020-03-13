using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evans.Demo.Core.Extensions.System.Collections.Generic
{
	public static class IEnumerableExtensions
	{
		/// <summary>
		/// Does an action for each item in the IEnumerable
		/// </summary>
		/// <typeparam name="T">Object type</typeparam>
		/// <param name="List">IEnumerable to iterate over</param>
		/// <param name="Action">Action to do</param>
		/// <returns>The original list</returns>
		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> self, Action<T> action)
		{
			if ((self != null) && (action != null))
			{
				foreach (T item in self)
				{
					action(item);
				}
			}

			return self;
		}
	}
}
