using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evans.Demo.Core.Logging
{
	public interface ILogger
	{
		#region Public Methods

		ILogger Debug(string message, Exception e = null);

		ILogger Debug(Exception e);

		ILogger Error(string message, Exception e = null);

		ILogger Error(Exception e);

		ILogger Fatal(string message, Exception e = null);

		ILogger Fatal(Exception e);

		ILogger Log(ILogEntry log);

		ILogger Warn(string message, Exception e = null);

		ILogger Warn(Exception e);

		#endregion Public Methods
	}
}
