using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Reflection;
using System.Web.Mvc;

using Evans.Demo.Core.Repositories;
using Evans.Demo.Core.Services;
using Evans.Demo.Core.Web.Mvc.IoC;
using Evans.Demo.Core.Web.Mvc.Startup;
using Evans.Demo.Repositories.EntityFramework;
using Evans.Demo.Repositories.EntityFramework.ToDo;

using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;

namespace Evans.Demo.Web.Mvc
{
	public class ContainerConfig : IStartupInitializer, IDisposable
	{
		#region Methods

		public void Initialize()
		{
			_container = new SimpleInjectorContainerMvc();
			_container.RegisterControllers(Assembly.GetExecutingAssembly());

			//var container = new Container();
			//container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
			//container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
			_container.Register(typeof(IService<>), typeof(Service<>), Lifestyle.Scoped);
			_container.Register(typeof(IRepository<>), typeof(EntityFrameworkRepository<>), Lifestyle.Scoped);
			_container.Register<DbContext, ToDoContext>(Lifestyle.Scoped);
			_container.Verify();
			DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(_container));
		}

		private SimpleInjectorContainerMvc _container;

		public void Dispose()
		{
			_container?.Dispose();
		}

		#endregion Methods
	}
}