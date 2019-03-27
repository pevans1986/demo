using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Evans.Demo.Domain.ToDo;
using Evans.Demo.Repositories.EntityFramework.ToDo;

using Moq;
using Moq.EntityFramework;
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
			var contextMock = DbContextMockFactory.Create<TestContext>();
			contextMock.MockSetFor<TaskItem>(new List<TaskItem>());

			var repo = new EntityFrameworkRepository<TaskItem>(contextMock.Object);
			var item = new TaskItem();
			repo.Add(item);

			var state = contextMock.Object.Entry(item).State;
			Assert.AreEqual(state, EntityState.Added);
		}

		#endregion Public Methods
	}
}