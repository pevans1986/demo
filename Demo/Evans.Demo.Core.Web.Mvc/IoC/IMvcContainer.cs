using Evans.Demo.Core.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Evans.Demo.Core.Web.Mvc.IoC
{
	public interface IMvcContainer : IContainer
	{
		#region Public Methods

		IMvcContainer RegisterControllers(Assembly[] assemblies);

		IMvcContainer RegisterDomainContext<TContext>()
			where TContext : class;

		/// <summary>
		/// Register the given implementation <see cref="Type" /> as the default concrete
		/// type to use for resolving an instance of the given repository
		/// <see cref="Type" />.
		/// </summary>
		/// <param name="repository"></param>
		/// <param name="implementation"></param>
		/// <returns></returns>
		//IMvcContainer RegisterRepositories(Type repository, Type implementation);

		IMvcContainer RegisterRouter<TRouter>(TRouter router)
			where TRouter : IMvcRouter;

		//IMvcContainer RegisterSelf();

		/// <summary>
		/// Register the given implementation <see cref="Type" /> as the default concrete
		/// type to use for resolving an instance of the given service <see cref="Type" />.
		/// </summary>
		/// <param name="service"></param>
		/// <param name="implementation"></param>
		/// <returns></returns>
		//IMvcContainer RegisterServices(Type service, Type implementation);

		//IMvcContainer RegisterSingleton<TSingleton>(TSingleton instance)
		//	where TSingleton : class;

		IMvcContainer UseAsMvcDependencyResolver();

		#endregion Public Methods
	}
}
