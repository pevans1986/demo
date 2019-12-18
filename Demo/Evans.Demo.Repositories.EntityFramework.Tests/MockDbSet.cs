using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evans.Demo.Repositories.EntityFramework.Tests
{
	public class MockDbSet<TEntity> : Mock<DbSet<TEntity>> where TEntity : class
	{
		public MockDbSet(List<TEntity> dataSource = null)
		{
			var data = (dataSource ?? new List<TEntity>());
			var queryable = data.AsQueryable();
			
			this.As<IQueryable<TEntity>>().Setup(s => s.Provider).Returns(queryable.Provider);
			this.As<IQueryable<TEntity>>().Setup(s => s.Expression).Returns(queryable.Expression);
			this.As<IQueryable<TEntity>>().Setup(s => s.ElementType).Returns(queryable.ElementType);
			this.As<IQueryable<TEntity>>().Setup(s => s.GetEnumerator()).Returns(() => queryable.GetEnumerator());

			this.Setup(_ => _.Add(It.IsAny<TEntity>())).Returns((TEntity arg) =>
			{
				data.Add(arg);
				return arg;
			});
		}
	}
}
