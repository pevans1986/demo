using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Evans.Demo.Core.Repositories
{
	public interface IRepository<TModel> : IDisposable
	{
		#region Public Methods

		IRepository<TModel> Add(TModel entity);

		IQueryable<TModel> All();

		IRepository<TModel> Delete(TModel entity);

		IRepository<TModel> DeleteById(object id);

		TModel Find(params object[] keys);

		TModel FindById(object id);

		List<TModel> FindWhere(Expression<Func<TModel, bool>> predicate);

		List<TModel> GetAll();

		IRepository<TModel> Save(TModel model);

		IRepository<TModel> SaveChanges();

		IQueryable<TModel> Where(Expression<Func<TModel, bool>> predicate);

		#endregion Public Methods
	}
}