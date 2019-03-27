using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Evans.Demo.Domain.ToDo;

namespace Evans.Demo.Repositories.EntityFramework.Tests
{
	public class TestContext : DbContext
	{
		public virtual DbSet<TaskItem> TaskItems { get; set; }

		public virtual DbSet<TaskList> TaskLists { get; set; }
	}
}
