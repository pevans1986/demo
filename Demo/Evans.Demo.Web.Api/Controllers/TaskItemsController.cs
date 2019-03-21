using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

using Evans.Demo.Core.Services;
using Evans.Demo.Core.Web.Api.Controllers;
using Evans.Demo.Domain.ToDo;

namespace Evans.Demo.Web.Api.Controllers
{
	[RoutePrefix("api/TaskItem")]
	public class TaskItemsController : CrudController<TaskItem>
	{
		public TaskItemsController(IService<TaskItem> service) : base(service)
		{
		}
	}
}