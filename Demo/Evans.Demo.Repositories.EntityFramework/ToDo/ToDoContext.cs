using Evans.Demo.Domain.ToDo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evans.Demo.Repositories.EntityFramework.ToDo
{
	public class ToDoContext : DbContext //, IToDoContext
	{
		#region Public Properties
		
		public virtual DbSet<TaskListItem> TaskItems { get; set; }

		public virtual DbSet<TaskList> TaskLists { get; set; }

		#endregion Public Properties

		#region Public Constructors

		public ToDoContext() : base(nameof(ToDoContext)) { }

		#endregion Public Constructors
	}
}

