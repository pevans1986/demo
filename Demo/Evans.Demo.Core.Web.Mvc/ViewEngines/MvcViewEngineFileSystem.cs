using HandlebarsDotNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evans.Demo.Core.Web.Mvc.ViewEngines
{
	public class MvcViewEngineFileSystem : ViewEngineFileSystem
	{
		public override bool FileExists(string filePath)
		{
			return File.Exists(filePath);
		}

		public override string GetFileContent(string filename)
		{
			return File.ReadAllText(filename);
		}

		protected override string CombinePath(string dir, string otherFileName)
		{
			return $"{dir}\\{otherFileName}";
		}
	}
}
