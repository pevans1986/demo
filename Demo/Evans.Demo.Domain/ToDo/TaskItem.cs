using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Evans.Demo.Core.Domain;

namespace Evans.Demo.Domain.ToDo
{
	public class TaskItem : IDomainEntity
	{
		#region Public Properties

		public string Description { get; set; }

		public DateTime? DueDate { get; set; }

		public Guid Id { get; set; }

		public virtual TaskList List { get; set; }

		public virtual ItemStatus Status { get; set; }

		#endregion Public Properties
	}
}
