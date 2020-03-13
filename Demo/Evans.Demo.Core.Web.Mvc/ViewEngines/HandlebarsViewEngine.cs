using HandlebarsDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Evans.Demo.Core.Web.Mvc.ViewEngines
{
	public class HandlebarsViewEngine : VirtualPathProviderViewEngine
	{

		public HandlebarsViewEngine()
		{
			// Define the location of the View file
			// TODO Read from config model
			this.ViewLocationFormats = new string[] { "~/Views/{1}/{0}.hbs", "~/Views/Shared/{0}.hbs" };
			this.PartialViewLocationFormats = new string[] { "~/Views/{1}/{0}.hbs", "~/Views/Shared/{0}.hbs" };
			//RegisterTemplates();
			Handlebars.Create(new HandlebarsConfiguration() { FileSystem = new MvcViewEngineFileSystem() });
		}
		protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
		{
			return new HandlebarsView(partialPath);
		}

		protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
		{
			return new HandlebarsView(viewPath);
		}

		//public static void RegisterTemplates()
		//{
		//	var directory = $"{AppContext.BaseDirectory}Views";
		//	// TODO Create extension method to get all files with extension in directory
		//	var directoryInfo = new DirectoryInfo(directory);
		//	var templates = directoryInfo.EnumerateFiles("*.hbs", SearchOption.AllDirectories);

		//	templates.ForEach(template =>
		//	{
		//		var templateName = template.Name.Replace(".hbs", "").ToLower();

		//		using (var reader = new StringReader(File.ReadAllText(template.FullName)))
		//		{
		//			//var compiledTemplate = HandlebarsView.GetOrCompileTemplate(template.FullName);
		//			var compiledTemplate = Handlebars.Compile(reader);
		//			Handlebars.RegisterTemplate(templateName, compiledTemplate);
		//		}
		//	});
		//}
	}
}
