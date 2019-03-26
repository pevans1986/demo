using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Evans.Demo.Core.Repositories
{
	public interface IRepository<TModel> : IDisposable
	{
		#region Public Methods

		IRepository<TModel> Add(TModel entity);

		bool Contains(TModel entity);

		IRepository<TModel> Delete(TModel entity);

		List<TModel> GetAll();

		IQueryable<TModel> Query();

		IRepository<TModel> Save(TModel model);

		IRepository<TModel> SaveChanges();

		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

		#endregion Public Methods
	}
}