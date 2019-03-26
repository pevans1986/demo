[assembly: WebActivator.PostApplicationStartMethod(typeof(Evans.Demo.Web.Api.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace Evans.Demo.Web.Api.App_Start
{
	using System.Data.Entity;
	using System.Web.Http;

	using Evans.Demo.Core.Repositories;
	using Evans.Demo.Core.Services;
	using Evans.Demo.Repositories.EntityFramework;
	using Evans.Demo.Repositories.EntityFramework.ToDo;

	using SimpleInjector;
	using SimpleInjector.Integration.WebApi;
	using SimpleInjector.Lifestyles;

	public static class SimpleInjectorWebApiInitializer
	{
		#region Public Methods

		/// <summary>
		/// Initialize the container and register it as Web API Dependency Resolver.
		/// </summary>
		public static void Initialize()
		{
			var container = new Container();
			container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

			InitializeContainer(container);

			container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

			container.Verify();

			GlobalConfiguration.Configuration.DependencyResolver =
				new SimpleInjectorWebApiDependencyResolver(container);
		}

		#endregion Public Methods

		#region Private Methods

		private static void InitializeContainer(Container container)
		{
			container.Register<DbContext, ToDoContext>(Lifestyle.Scoped);
			container.Register(typeof(IRepository<>), typeof(EntityFrameworkRepository<>), Lifestyle.Scoped);
			container.Register(typeof(IService<>), typeof(Service<>), Lifestyle.Scoped);
			container.Options.SuppressLifestyleMismatchVerification = true;
		}

		#endregion Private Methods
	}
}