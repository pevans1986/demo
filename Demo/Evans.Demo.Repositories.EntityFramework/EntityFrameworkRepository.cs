using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Evans.Demo.Core.Domain;
using Evans.Demo.Core.Repositories;

namespace Evans.Demo.Repositories.EntityFramework
{
	public class EntityFrameworkRepository<TContext, TEntity> : Repository<TEntity>, IRepository<TEntity>
		where TContext : DbContext
		where TEntity : class, IDomainEntity
	{
		#region Public Constructors

		public EntityFrameworkRepository(TContext context)
		{
			Context = context;
		}

		#endregion Public Constructors

		#region Protected Properties

		protected virtual TContext Context { get; }

		#endregion Protected Properties

		#region Public Methods

		public override IRepository<TEntity> Add(TEntity entity)
		{
			Context.Entry(entity).State = EntityState.Added;
			return this;
		}

		public override IRepository<TEntity> Delete(TEntity entity)
		{
			Context.Entry(entity).State = EntityState.Deleted;
			return this;
		}

		public override void Dispose()
		{
			Context?.Dispose();
		}

		public override List<TEntity> GetAll()
		{
			return Context
				.Set<TEntity>()
				.ToList();
		}

		public override IQueryable<TEntity> Query()
		{
			return Context
				.Set<TEntity>()
				.AsQueryable();
		}

		public override IRepository<TEntity> Save(TEntity model)
		{
			Context.Entry(model).State = EntityState.Modified;
			return this;
		}

		public override IRepository<TEntity> SaveChanges()
		{
			Context.SaveChanges();
			return this;
		}

		#endregion Public Methods

		#region Protected Methods

		protected virtual DbContext GetDbContext()
		{
			return Context;
		}

		#endregion Protected Methods
	}
}