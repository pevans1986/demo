using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Evans.Demo.Core.Services;
using Evans.Demo.Core.Web.Api.Controllers;
using Evans.Demo.Domain.ToDo;
using Swashbuckle.Swagger.Annotations;

namespace Evans.Demo.Web.Api.Controllers.ToDo
{
	/// <summary>
	/// REST API data access for task items.
	/// </summary>
	[RoutePrefix("api/TaskItem")]
	public class TaskItemsController : CrudController<TaskListItem>
	{
		public TaskItemsController(IService<TaskListItem> service) : base(service)
		{
			
		}


		/// <summary>
		/// Returns all task items.
		/// </summary>
		/// <returns></returns>
		[ResponseType(typeof(IEnumerable<TaskListItem>))]
		// TODO Add view model that returns object with only list id, not entire object
		public override Task<IHttpActionResult> GetAsync() => base.GetAsync();
	}
}