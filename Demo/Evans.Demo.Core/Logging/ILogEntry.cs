using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evans.Demo.Core.Logging
{
	public interface ILogEntry
	{
		#region Public Properties

		string ActivityId { get; set; }

		string AppDomainFriendlyName { get; set; }

		string Data { get; set; }

		DateTime Date { get; set; }

		string Exception { get; set; }

		string LogicalOperationStack { get; set; }

		string MachineName { get; set; }

		string Message { get; set; }

		int ProcessId { get; set; }

		string RelatedActivityId { get; set; }

		string Severity { get; set; }

		string Source { get; set; }

		string ThreadId { get; set; }

		string ThreadName { get; set; }

		int TraceId { get; set; }

		#endregion Public Properties
	}
}
