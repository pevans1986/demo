using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Evans.Demo.Core.IoC;

namespace Evans.Demo.Core.Config
{
	/// <summary>
	/// Provides logic that needs to be executed when the application is being started.
	/// During startup, the application will create an instance of each implementing
	/// <see cref="Type" /> and invoke the <see cref="Bootstrap(IContainer)" /> method.
	/// </summary>
	public interface IBootstrap
	{
		#region Methods

		/// <summary>
		/// Perform any logic that should be handled during application startup.
		/// </summary>
		/// <param name="container"></param>
		void Bootstrap(IContainer container);

		#endregion Methods
	}
}
