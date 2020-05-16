using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

using HandlebarsDotNet;

namespace Evans.Demo.Core.Web.Mvc.ViewEngines
{
	public class HandlebarsView : IView
	{
		#region Private Fields

		private readonly string _viewPath;

		#endregion Private Fields

		#region Protected Properties

		protected static ConcurrentDictionary<string, Func<object, string>> CompiledViews { get; } = new ConcurrentDictionary<string, Func<object, string>>(StringComparer.OrdinalIgnoreCase);

		// TODO Externalize (HandlebarsViewEngine?)
		protected static IHandlebars HandlebarsRenderer { get; } = Handlebars.Create(new HandlebarsConfiguration() { FileSystem = new MvcViewEngineFileSystem() });

		#endregion Protected Properties

		#region Public Constructors

		/// <summary>
		/// </summary>
		/// <param name="viewPath">
		/// URL path to view in the format: "~/Views/(Controller)/(Action).hbs"
		/// </param>
		/// <returns></returns>
		public HandlebarsView(string viewPath)
		{
			_viewPath = viewPath;
		}

		#endregion Public Constructors

		#region Public Methods

		public static Func<object, string> CompileView(string viewPath)
		{
			// Get the absolute file path for the view template
			var file = GetFilePathFull(viewPath);

			// Compile the template
			return HandlebarsRenderer.CompileView(file);
		}

		public static string GetFilePathFull(string viewPath)
		{
			return $"{AppContext.BaseDirectory}{viewPath.Replace("~", "")}";
		}

		public static Func<object, string> GetOrCompileTemplate(string viewPath)
		{
			var template = CompiledViews.GetOrAdd(viewPath, view =>
			{
				var compiledView = CompileView(viewPath);
				CompiledViews.TryAdd(viewPath, compiledView);

				return compiledView;
			});

			//if (template == null)
			//{
			//	template = CompileView(viewPath);
			//	CompiledViews.AddOrUpdate(viewPath, template);
			//}

			return template;
		}

		public void Render(ViewContext viewContext, TextWriter writer)
		{
			// Get the compiled view from the cache
			var compiledView = GetOrCompileTemplate(_viewPath);

			// Render view using view model and write out result
			var model = viewContext.ViewData?.Model;
			var output = compiledView(model);
			writer.Write(output);
		}

		#endregion Public Methods
	}
}
