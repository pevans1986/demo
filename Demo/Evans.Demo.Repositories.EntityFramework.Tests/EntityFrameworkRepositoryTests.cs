using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Evans.Demo.Domain.ToDo;
using Evans.Demo.Repositories.EntityFramework.ToDo;

using Moq;
using Moq.EntityFramework.Helpers;

using NUnit.Framework;

namespace Evans.Demo.Repositories.EntityFramework.Tests
{
	[TestFixture]
	public class EntityFrameworkRepositoryTests
	{
		#region Public Methods

		[Test]
		public void Add_ShouldSetEntityState()
		{
			var contextMock = new Mock<ToDoContext>();
			IList<TaskItem> values = new List<TaskItem>();
			contextMock.Setup(mock => mock.TaskItems).Returns(values);

			var repo = new EntityFrameworkRepository<ToDoContext, TaskItem>(contextMock.Object);
			var item = new TaskItem();
			repo.Add(item);

			var state = contextMock.Object.Entry(item).State;
			Assert.AreEqual(state, EntityState.Added);
		}

		#endregion Public Methods
	}
}