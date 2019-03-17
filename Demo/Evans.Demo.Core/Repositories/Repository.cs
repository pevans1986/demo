using System;
using System.Collections.Generic;
using System.Linq;

using Evans.Demo.Core.Domain;

namespace Evans.Demo.Core.Repositories
{
	/// <summary>
	/// Base implementation of repository that performs CRUD functions on a data store.
	/// </summary>
	public abstract class Repository<TEntity>
		where TEntity : IDomainEntity
	{
		#region Public Methods

		public abstract IRepository<TEntity> Add(TEntity entity);

		public abstract IRepository<TEntity> Delete(TEntity entity);

		public abstract void Dispose();

		public virtual List<TEntity> GetAll() => Query().ToList();

		public abstract IQueryable<TEntity> Query();

		public abstract IRepository<TEntity> Save(TEntity model);

		public abstract IRepository<TEntity> SaveChanges();

		#endregion Public Methods
	}
}