using Evans.Demo.Domain.ToDo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evans.Demo.Repositories.EntityFramework.ToDo
{
	public class ToDoContext : DbContext
	{
		#region Public Properties
		
		public virtual IDbSet<TaskItem> TaskListItems { get; set; }

		public virtual IDbSet<TaskList> TaskLists { get; set; }

		#endregion Public Properties

		#region Public Constructors

		public ToDoContext() : base(nameof(ToDoContext)) { }

		#endregion Public Constructors
	}
}
