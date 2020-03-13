using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Evans.Demo.Core
{
	/// <summary>
	/// Utility methods to search for Types within Assemblies via reflection.
	/// </summary>
	public static class AssemblyScanner
	{
		#region Private Fields

		private static List<Assembly> _localAssemblies = null;

		#endregion Private Fields

		#region Public Methods

		/// <summary>
		/// Searches all local assemblies using the given predicate. predicate.
		/// </summary>
		/// <typeparam name="Assembly"></typeparam>
		/// <param name="predicate"></param>
		/// <returns></returns>
		/// <seealso cref="GetLocalAssemblies" />
		public static IEnumerable<Assembly> FindAssemblies(Func<Assembly, bool> predicate)
		{
			return GetLocalAssemblies().Where(predicate);
		}

		/// <summary>
		/// Searches the current <see cref="AppDomain" /> for assemblies that are local to
		/// the calling <see cref="Assembly" />.
		/// </summary>
		/// <typeparam name="Assembly"></typeparam>
		/// <returns></returns>
		public static IEnumerable<Assembly> GetLocalAssemblies()
		{
			if (_localAssemblies == null)
			{
				string assemblyUri = GetURI(Assembly.GetCallingAssembly());

				_localAssemblies = AppDomain
					.CurrentDomain
					.GetAssemblies()
					.Where(x => !x.IsDynamic && GetURI(x).Contains(assemblyUri))
					.ToList();
			}

			return _localAssemblies;
		}

		#endregion Public Methods

		#region Private Methods

		/// <summary>
		/// Returns the directory path to use as the <see cref="Uri" /> for finding local
		/// assemblies.
		/// </summary>
		/// <param name="assembly"></param>
		/// <returns></returns>
		private static string GetURI(Assembly assembly)
		{
			string codeBase = assembly.CodeBase;

			if (!codeBase.StartsWith("file:", StringComparison.CurrentCultureIgnoreCase))
			{
				codeBase = Path.GetDirectoryName(codeBase);
				return new Uri(codeBase).AbsolutePath;
			}
			else
			{
				return Path.GetDirectoryName(new Uri(codeBase).AbsolutePath);
			}
		}

		#endregion Private Methods
	}
}
