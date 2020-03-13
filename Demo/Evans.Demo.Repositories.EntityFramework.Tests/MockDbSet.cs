using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Moq;

namespace Evans.Demo.Repositories.EntityFramework.Tests
{
	public class MockDbSet<TEntity> : Mock<DbSet<TEntity>> where TEntity : class
	{
		#region Public Constructors

		public MockDbSet(List<TEntity> dataSource = null)
		{
			Init(dataSource);
		}

		#endregion Public Constructors

		#region Public Methods

		public void Init(IList<TEntity> dataSource)
		{
			var data = (dataSource ?? new List<TEntity>());
			var queryable = data.AsQueryable();

			As<IQueryable<TEntity>>().Setup(s => s.Provider).Returns(queryable.Provider);
			As<IQueryable<TEntity>>().Setup(s => s.Expression).Returns(queryable.Expression);
			As<IQueryable<TEntity>>().Setup(s => s.ElementType).Returns(queryable.ElementType);
			As<IQueryable<TEntity>>().Setup(s => s.GetEnumerator()).Returns(() => queryable.GetEnumerator());

			Setup(_ => _.Add(It.IsAny<TEntity>())).Returns((TEntity arg) =>
			{
				data.Add(arg);
				return arg;
			});
		}

		#endregion Public Methods
	}
}