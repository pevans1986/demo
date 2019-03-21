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
		#region Protected Constructors

		protected TaskListService(IRepository<TaskList> repository)
			: base(repository)
		{
		}

		#endregion Protected Constructors

		#region Public Methods

		public void CompleteAllTasks(TaskList taskList)
		{
			taskList.Items.ForEach(item =>
			{
				item.Status = ItemStatus.Complete;
			});

			Repository.SaveChanges();
		}

		#endregion Public Methods
	}
}