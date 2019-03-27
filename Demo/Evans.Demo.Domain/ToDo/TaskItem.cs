using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Evans.Demo.Core.Domain;

namespace Evans.Demo.Domain.ToDo
{
	public class TaskItem : DomainEntity
	{
		#region Public Properties

		public string Description { get; set; }

		public DateTime? DueDate { get; set; }

		[Required]
		public virtual TaskList List { get; set; }

		public int SortOrder { get; set; }

		public virtual ItemStatus Status { get; set; }

		#endregion Public Properties
	}
}