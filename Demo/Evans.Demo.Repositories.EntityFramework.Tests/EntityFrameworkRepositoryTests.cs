using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Evans.Demo.Domain.ToDo;

using Moq;

using NUnit.Framework;

namespace Evans.Demo.Repositories.EntityFramework.Tests
{
	[TestFixture]
	public class EntityFrameworkRepositoryTests
	{
		#region Private Fields

		private Mock<DbContext> _contextMock;
		private Mock<EntityFrameworkRepository<TaskListItem>> _repoTaskListItemsMock;
		private MockDbSet<TaskListItem> _taskListItemMockSet;
		private List<TaskListItem> _taskListItems;

		#endregion Private Fields

		#region Public Methods

		[Test]
		public void Add_ShouldSetEntityState()
		{
			var newItem = new TaskListItem()
			{
				CreatedDate = DateTime.Now,
				Description = "Test"
			};

			_repoTaskListItemsMock.Object.Add(newItem);

			_taskListItemMockSet.Verify(s => s.Add(It.IsAny<TaskListItem>()), Times.Once());
			Assert.IsTrue(_taskListItems.Contains(newItem));
		}

		[OneTimeSetUp]
		public void SetUp()
		{
			_taskListItems = new List<TaskListItem>();
			_taskListItemMockSet = new MockDbSet<TaskListItem>(_taskListItems);

			_contextMock = new Mock<DbContext>();
			_contextMock.Setup(c => c.Set<TaskListItem>()).Returns(_taskListItemMockSet.Object);

			_repoTaskListItemsMock = new Mock<EntityFrameworkRepository<TaskListItem>>(_contextMock.Object)
			{
				CallBase = true
			};
		}

		#endregion Public Methods
	}
}