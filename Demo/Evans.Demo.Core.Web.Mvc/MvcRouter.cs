using Evans.Demo.Core.Domain;
using Evans.Demo.Core.Web.Mvc.Controllers;
using Evans.Demo.Core.Web.Mvc.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Evans.Demo.Core.Web.Mvc
{
	public class MvcRouter : IMvcRouter
	{
		#region Public Fields

		public const string RouteDataAreaName = "area";
		public const string ViewNotFound = "NotFound";

		#endregion Public Fields

		#region Private Fields

		private IMvcContainer _container;
		private IDictionary<string, Type> _modelTypes;

		#endregion Private Fields

		#region Public Constructors

		public MvcRouter(IMvcContainer container)
		{
			_container = container;
		}

		#endregion Public Constructors

		#region Public Properties

		/// <summary>
		/// Caches domain objects to include when searching for a <see cref="Type" /> from a
		/// requested path.
		/// </summary>
		public IDictionary<string, Type> DataModelCache
		{
			get { return GetDataModelCache(); }
		}

		#endregion Public Properties

		#region Public Methods

		public ActionResult RouteDynamicRequest(RouteInfo routeInfo)
		{
			// TODO Include namespace to prevent issues with duplicate model names
			var modelType = GetModelType(routeInfo.ModelTypeName);
			if (modelType == null)
			{
				// TODO Attempt changing model type name to plural / singular form

				// TODO Create exception class to throw
				//return NotFound();
				return null;
			}

			var controller = GetControllerInstance(modelType);

			// FIXME Doesn't handle cases where multiple methods of same name
			//var method = controller?.GetType()?.GetMethod(routeInfo.ActionName);
			var method = GetMethod(controller.GetType(), routeInfo);
			var parameters = GetActionMethodParameters(routeInfo, method);
			var isActionResult = (typeof(ActionResult).IsAssignableFrom(method.ReturnType));

			if (isActionResult)
			{
				return method.Invoke(controller, parameters) as ActionResult;
			}
			else
			{
				method.Invoke(controller, parameters);
			}

			// TODO Create exception class to throw
			//return NotFound();
			return null;
		}

		#endregion Public Methods

		#region Protected Methods

		protected MethodInfo GetMethod(Type controllerType, RouteInfo routeInfo)
		{
			try
			{
				return controllerType.GetMethod(routeInfo.ActionName, routeInfo.ParameterTypes);
			}
			catch (Exception e)
			{
				// TODO Log (debug) exception 
				return null;
			}
		}

		// TODO Review which methods can be changed to protected
		/// <summary>
		/// Determines the correct number of method parameters based on the given
		/// <see cref="MethodInfo" /> and returns an array filled with values from the given
		/// <see cref="RouteInfo" />.
		/// </summary>
		/// <param name="routeInfo"></param>
		/// <param name="method"></param>
		/// <returns></returns>
		protected object[] GetActionMethodParameters(RouteInfo routeInfo, MethodInfo method)
		{
			var parameters = new List<object>();
			var methodParameters = method.GetParameters();
			var parameterCount = methodParameters.Length;
			var argCount = routeInfo.ParameterValues.Count;

			if (methodParameters.Length > 0)
			{
				for (int i = 0; (i < argCount) && (i < parameterCount); i++)
				{
					parameters.Add(routeInfo.ParameterValues[i]);
				}
			}

			return parameters.ToArray();
		}

		protected object GetControllerInstance(Type modelType)
		{
			// TODO Remove hard-coding of MvcControllerBase<> and get from the container
			var controllerType = typeof(MvcController<>).MakeGenericType(modelType);
			return _container.Resolve(controllerType);
		}

		/// <summary>
		/// Checks for a Type that implements <see cref="IModel" /> and matches the given model type
		/// name.
		/// </summary>
		/// <param name="modelName"></param>
		/// <returns></returns>
		protected Type GetModelType(string modelName)
		{
			Type modelType;
			DataModelCache.TryGetValue(modelName, out modelType);

			return modelType;
		}

		#endregion Protected Methods

		#region Private Methods

		private IDictionary<string, Type> GetDataModelCache()
		{
			if (_modelTypes == null)
			{
				// TODO Include namespace to prevent issues with duplicate model names
				var assemblies = AssemblyScanner
					.FindAssemblies(assembly => assembly.FullName.StartsWith("Evans"));

				// TODO Retrieve types using [DataModel] attribute instead of IModel
				_modelTypes = TypeScanner
					.GetImplementingTypes(typeof(IDomainEntity), assemblies)
					.ToDictionary(model => model.Name, model => model);
			}

			return _modelTypes;
		}

		#endregion Private Methods
	}
}
