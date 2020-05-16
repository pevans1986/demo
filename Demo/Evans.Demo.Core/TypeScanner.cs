using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Evans.Demo.Core.Extensions.System;
using Evans.Demo.Core.Extensions.System.Reflection;

namespace Evans.Demo.Core
{
	/// <summary>
	/// Utility methods for accessing Types via reflection.
	/// </summary>
	public static class TypeScanner
	{
		#region Methods

		public static Type FindTypeByName(string typeFullName)
		{
			return FindTypeByName(typeFullName, AssemblyScanner.GetLocalAssemblies());
		}

		public static Type FindTypeByName(string typeFullName, Assembly assembly)
		{
			return FindTypeByName(typeFullName, assembly.ToArray());
		}

		public static Type FindTypeByName(string typeFullName, IEnumerable<Assembly> assemblies)
		{
			return assemblies
				.FirstOrDefault(assembly => assembly.DefinedTypes.Any(t => string.Equals(t.FullName, typeFullName, StringComparison.OrdinalIgnoreCase)))?
				.GetType(typeFullName);
		}

		/// <summary>
		/// Finds every <see cref="Type" /> that has the given <see cref="Attribute" /> defined at
		/// the <see cref="Type" /> level.
		/// </summary>
		/// <typeparam name="TAttribute"></typeparam>
		/// <returns></returns>
		public static IEnumerable<Type> GetDecoratedWith<TAttribute>()
			where TAttribute : Attribute
		{
			return GetDecoratedWith<TAttribute>(AssemblyScanner.GetLocalAssemblies());
		}

		/// <summary>
		/// Returns all Types within the given Assemblies that have the indicated Attribute type
		/// defined at the class level.
		/// </summary>
		/// <typeparam name="TAttribute">The type of the attribute.</typeparam>
		/// <param name="assemblies">The assemblies to check.</param>
		/// <returns></returns>
		public static IEnumerable<Type> GetDecoratedWith<TAttribute>(IEnumerable<Assembly> assemblies)
			where TAttribute : Attribute
		{
			return assemblies
				.SelectMany(x => x.GetTypes())
				.Where(x => x.HasAttribute<TAttribute>())
				.ToList();
		}

		/// <summary>
		/// Searches local assemblies for types that extend the given <see cref="Type" />.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		/// <seealso cref="GetDerivedTypes(Type)" />
		/// <seealso cref="AssemblyScanner.GetLocalAssemblies" />
		public static IEnumerable<Type> GetDerivedTypes<T>()
		{
			return GetDerivedTypes(typeof(T));
		}

		/// <summary>
		/// Searches local assemblies for types that extend the given <see cref="Type" />.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns></returns>
		/// <seealso cref="GetDerivedTypes{T}()" />
		/// <seealso cref="AssemblyScanner.GetLocalAssemblies" />
		public static IEnumerable<Type> GetDerivedTypes(Type type)
		{
			return GetDerivedTypes(type, AssemblyScanner.GetLocalAssemblies());
		}

		/// <summary>
		/// Searches the given <see cref="Assembly" /> for types that extend the given
		/// <see cref="Type" />.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="assembly">The assembly.</param>
		/// <returns></returns>
		/// <seealso cref="GetDerivedTypes{T}(IEnumerable{Assembly})" />
		public static IEnumerable<Type> GetDerivedTypes<T>(Assembly assembly)
		{
			return GetDerivedTypes<T>(assembly.ToArray());
		}

		/// <summary>
		/// Searches the given assemblies for types that extend the given <see cref="Type" />.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="assemblies">The assemblies.</param>
		/// <returns></returns>
		/// <seealso cref="GetDerivedTypes(Type, IEnumerable{Assembly})" />
		public static IEnumerable<Type> GetDerivedTypes<T>(IEnumerable<Assembly> assemblies)
		{
			return GetDerivedTypes(typeof(T), assemblies);
		}

		/// <summary>
		/// Searches the given assemblies for types that extend the given <see cref="Type" />.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="assemblies">The assemblies.</param>
		/// <returns></returns>
		/// <seealso cref="GetDerivedTypes{T}(IEnumerable{Assembly})" />
		public static IEnumerable<Type> GetDerivedTypes(Type type, IEnumerable<Assembly> assemblies)
		{
			return assemblies
				.SelectMany(x => x.GetTypes())
				.Where(x => type.IsAssignableFrom(x) 
					&& x.IsClass
					&& (x != type))
				.ToList();
		}

		/// <summary>
		/// Searches local assemblies for all types that implement the given interface
		/// <see cref="Type" />.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		/// <seealso cref="GetImplementingTypes(Type)" />
		public static IEnumerable<Type> GetImplementingTypes<T>()
		{
			return GetImplementingTypes(typeof(T));
		}

		/// <summary>
		/// Searches local assemblies for all types that implement the given interface
		/// <see cref="Type" />.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns></returns>
		/// <seealso cref="GetImplementingTypes{T}()" />
		public static IEnumerable<Type> GetImplementingTypes(Type type)
		{
			return GetImplementingTypes(type, AssemblyScanner.GetLocalAssemblies());
		}

		/// <summary>
		/// Searches the given <see cref="Assembly" /> for types that implement the given interface
		/// <see cref="Type" />.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="assembly">The assembly.</param>
		/// <returns></returns>
		/// <seealso cref="GetImplementingTypes{T}(IEnumerable{Assembly})" />
		public static IEnumerable<Type> GetImplementingTypes<T>(Assembly assembly)
		{
			return GetImplementingTypes<T>(assembly.ToArray());
		}

		/// <summary>
		/// Searches the given assemblies for types that implement the given interface
		/// <see cref="Type" />.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="assemblies">The assemblies.</param>
		/// <returns></returns>
		/// <seealso cref="GetImplementingTypes(Type, IEnumerable{Assembly})" />
		public static IEnumerable<Type> GetImplementingTypes<T>(IEnumerable<Assembly> assemblies)
		{
			return GetImplementingTypes(typeof(T), assemblies);
		}

		/// <summary>
		/// Searches the given assemblies for types that implement the given interface
		/// <see cref="Type" />.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="assemblies">The assemblies.</param>
		/// <returns></returns>
		/// <seealso cref="GetImplementingTypes{T}(IEnumerable{Assembly})" />
		public static IEnumerable<Type> GetImplementingTypes(Type type, IEnumerable<Assembly> assemblies)
		{
			return assemblies
				.SelectMany(x => x.GetTypes())
				.ToList()
				.Where(t => t.GetInterfaces().Contains(type))
				.ToList();
		}

		/// <summary>
		/// Searches local assemblies for all types that implement the given interface
		/// <see cref="Type" /> and creates an instance of that <see cref="Type" />.
		/// </summary>
		/// <typeparam name="TInterface"></typeparam>
		/// <returns></returns>
		/// <seealso cref="GetInstancesOf{TInterface}(IEnumerable{Assembly})" />
		public static IEnumerable<TInterface> GetInstancesOf<TInterface>()
		{
			return GetInstancesOf<TInterface>(AssemblyScanner.GetLocalAssemblies());
		}

		/// <summary>
		/// Searches the given <see cref="Assembly" /> for all types that implement the given
		/// interface <see cref="Type" /> and creates an instance of that <see cref="Type" />.
		/// </summary>
		/// <typeparam name="TInterface"></typeparam>
		/// <param name="assembly"></param>
		/// <returns></returns>
		/// <seealso cref="GetInstancesOf{TInterface}(IEnumerable{Assembly})" />
		public static IEnumerable<TInterface> GetInstancesOf<TInterface>(Assembly assembly)
		{
			return GetInstancesOf<TInterface>(assembly.ToArray());
		}

		/// <summary>
		/// Searches the given assemblies for all types that implement the given interface
		/// <see cref="Type" /> and creates an instance of that <see cref="Type" />.
		/// </summary>
		/// <typeparam name="TInterface"></typeparam>
		/// <param name="assembly"></param>
		/// <returns></returns>
		public static IEnumerable<TInterface> GetInstancesOf<TInterface>(IEnumerable<Assembly> assembly)
		{
			var instanceList = new List<TInterface>();
			var assemblyTypes = GetImplementingTypes<TInterface>(assembly).ToList();
			assemblyTypes.ForEach(type =>
			{
				instanceList.Add((TInterface)Activator.CreateInstance(type));
			});

			return instanceList;
		}

		#endregion Methods
	}
}
