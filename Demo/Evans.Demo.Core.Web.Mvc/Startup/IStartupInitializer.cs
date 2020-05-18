using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evans.Demo.Core.Web.Mvc.Startup
{
	public interface IStartupInitializer
	{
		#region Public Methods

		void Initialize();

		#endregion Public Methods
	}
}