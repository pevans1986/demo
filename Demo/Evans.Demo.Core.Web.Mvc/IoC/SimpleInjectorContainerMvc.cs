using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Web.Mvc;

using Evans.Demo.Core.IoC;

using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace Evans.Demo.Core.Web.Mvc.IoC
{
	public class SimpleInjectorContainerMvc : SimpleInjectorContainer, IMvcContainer
	{
		#region Constructors

		public SimpleInjectorContainerMvc()
			: base()
		{
			Options.DefaultScopedLifestyle = new WebRequestLifestyle();
		}

		#endregion Constructors

		#region Methods

		public IMvcContainer RegisterControllers(Assembly assembly)
		{
			return RegisterControllers(new Assembly[] { assembly });
		}

		public IMvcContainer RegisterControllers(Assembly[] assemblies)
		{
			(this as Container).RegisterMvcControllers(assemblies);
			(this as Container).RegisterMvcIntegratedFilterProvider();

			return this;
		}

		public IMvcContainer RegisterRouter<TRouter>(TRouter router)
			where TRouter : IMvcRouter
		{
			RegisterSingleton<IMvcRouter>(router);
			return this;
		}

		public IMvcContainer RegisterSelf()
		{
			RegisterSingleton<IMvcContainer>(this);
			return this;
		}

		public IMvcContainer UseAsMvcDependencyResolver()
		{
			DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(this));
			return this;
		}

		public override bool Validate()
		{
			RegisterSelf();
			UseAsMvcDependencyResolver();

			return base.Validate();
		}

		#endregion Methods
	}
}