using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evans.Demo.Core.IoC
{
	public interface IContainer
	{
		#region Public Methods

		IContainer AutoRegisterServices();

		IContainer RegisterConcreteType<TService>() where TService : class;

		//IContainer RegisterLogger(ILogger logger);

		// TODO RegisterMapper(IMapper mapper)

		IContainer RegisterServiceType<TService, TImplementation>()
			where TService : class
			where TImplementation : class;

		IContainer RegisterServiceType(Type serviceType, Type implementationType);

		IContainer RegisterSingleton<TSingleton>(TSingleton instance)
							where TSingleton : class;

		TService Resolve<TService>()
			where TService : class;

		object Resolve(Type serviceType);

		bool Validate();

		#endregion Public Methods
	}
}