using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using Evans.Demo.Core.Domain;

namespace Evans.Demo.Core.Repositories
{
	public abstract class Repository<TEntity> where TEntity : IDomainEntity
	{
		#region Public Methods

		public abstract IRepository<TEntity> Add(TEntity entity);

		public abstract IRepository<TEntity> Delete(TEntity entity);

		public abstract IRepository<TEntity> DeleteById(object id);

		public abstract void Dispose();

		public abstract TEntity Find(params object[] keys);

		public virtual TEntity FindById(object id)
		{
			// TODO Test using Equals vs ==
			return Query().FirstOrDefault(e => e.Id.Equals(id));
		}

		public virtual List<TEntity> FindWhere(Expression<Func<TEntity, bool>> predicate)
		{
			return Query().Where(predicate).ToList();
		}

		public virtual List<TEntity> GetAll() => Query().ToList();

		public abstract IQueryable<TEntity> Query();

		public abstract IRepository<TEntity> Save(TEntity model);

		public abstract IRepository<TEntity> SaveChanges();

		public virtual IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
		{
			return Query().Where(predicate);
		}

		#endregion Public Methods
	}
}