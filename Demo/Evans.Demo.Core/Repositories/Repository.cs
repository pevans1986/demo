using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Evans.Demo.Core.Repositories
{
	public abstract class Repository<TEntity>
	{
		#region Public Methods

		public abstract IRepository<TEntity> Add(TEntity entity);

		public abstract IQueryable<TEntity> All();

		public abstract IRepository<TEntity> Delete(TEntity entity);

		public abstract IRepository<TEntity> DeleteById(object id);

		public abstract void Dispose();

		public abstract TEntity Find(params object[] keys);

		public abstract TEntity FindById(object id);

		public abstract List<TEntity> FindWhere(Expression<Func<TEntity, bool>> predicate);

		public abstract List<TEntity> GetAll();

		public abstract IRepository<TEntity> Save(TEntity model);

		public abstract IRepository<TEntity> SaveChanges();

		public abstract IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);

		#endregion Public Methods
	}
}