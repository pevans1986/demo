using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evans.Demo.Domain.ToDo
{
	public interface IToDoContext
	{
		IQueryable<TaskListItem> TaskItems { get; set; }

		IQueryable<TaskList> TaskLists { get; set; }
	}
}
