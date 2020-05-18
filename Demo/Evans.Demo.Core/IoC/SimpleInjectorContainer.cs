using Evans.Demo.Core.Logging;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evans.Demo.Core.IoC
{
	// TODO Move to separate class library (Evans.Demo.Core.IoC.SimpleInjector
	public class SimpleInjectorContainer : Container, IContainer
	{
		#region Public Constructors

		public SimpleInjectorContainer()
			: base()
		{
			//Options.DefaultScopedLifestyle = Lifestyle.Scoped;
		}

		public virtual IContainer AutoRegisterServices()
		{
			// TODO Implement auto-registration
			return this;
		}

		public IContainer RegisterConcreteType<TService>() where TService : class
		{
			throw new NotImplementedException();
		}

		#endregion Public Constructors

		#region Public Methods

		public IContainer RegisterDomainContext<TContext>()
			where TContext : class
		{
			Register<TContext>(Lifestyle.Scoped);
			return this;
		}

		public IContainer RegisterLogger(ILogger logger)
		{
			RegisterSingleton(logger);
			return this;
		}

		public IContainer RegisterRepositories(Type baseService, Type baseImplementation)
		{
			RegisterConditional(
				baseService,
				baseImplementation,
				Lifestyle.Scoped,
				context => !context.Handled);

			return this;
		}


		public IContainer RegisterServices(Type baseService, Type baseImplementation)
		{
			RegisterConditional(
				baseService,
				baseImplementation,
				Lifestyle.Scoped,
				context => !context.Handled);

			return this;
		}

		public IContainer RegisterServiceType(Type serviceType, Type implementationType)
		{
			throw new NotImplementedException();
		}

		public IContainer RegisterServiceType<TService, TImplementation>()
			where TService : class
			where TImplementation : class
		{
			throw new NotImplementedException();
		}

		public IContainer RegisterSingleton<TSingleton>(TSingleton instance)
			where TSingleton : class
		{
			base.RegisterSingleton(instance);
			return this;
		}

		public object Resolve(Type serviceType)
		{
			return GetInstance(serviceType);
		}

		public TService Resolve<TService>()
			where TService : class
		{
			return GetInstance<TService>();
		}


		public virtual bool Validate()
		{
			Verify();

			// Successful if this is reached - Verify() throws exceptions
			return true;
		}

		//IContainer IContainer.RegisterSingleton<TSingleton>(TSingleton instance)
		//{
		//	throw new NotImplementedException();
		//}

		#endregion Public Methods
	}
}
