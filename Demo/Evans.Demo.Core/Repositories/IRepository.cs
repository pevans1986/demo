using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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

		List<TModel> FindAll();

		TModel FindById(object id);

		List<TModel> FindWhere(Expression<Func<TModel, bool>> predicate);

		IRepository<TModel> Save(TModel model);

		IRepository<TModel> SaveChanges();

		IQueryable<TModel> Where(Expression<Func<TModel, bool>> predicate);

		#endregion Public Methods
	}
}
