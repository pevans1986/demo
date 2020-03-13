using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Evans.Demo.Core.Repositories;
using Evans.Demo.Core.Services;
using Evans.Demo.Domain.ToDo;

namespace Evans.Demo.Services.ToDo
{
	public class TaskListService : Service<TaskList>
	{
		#region Constructors

		protected TaskListService(IRepository<TaskList> repository)
			: base(repository)
		{
		}

		#endregion Constructors

		#region Methods

		public void Complete(TaskList taskList)
		{
			CompleteAllTasks(taskList);
			taskList.Status = ItemStatus.Complete;
		}

		public void CompleteAllTasks(TaskList taskList)
		{
			taskList.Items.ForEach(CompleteTask);
		}

		public void CompleteTask(TaskListItem item)
		{
			item.Status = ItemStatus.Complete;
		}

		#endregion Methods
	}
}