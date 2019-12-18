using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Evans.Demo.Core.Domain;
using Evans.Demo.Core.Repositories;

namespace Evans.Demo.Repositories.EntityFramework
{
	public class EntityFrameworkRepository<TEntity> : Repository<TEntity>, IRepository<TEntity>
		where TEntity : class, IDomainEntity
	{
		#region Public Constructors

		public EntityFrameworkRepository(DbContext context)
		{
			Context = context;
		}

		#endregion Public Constructors

		#region Protected Properties

		protected virtual DbContext Context { get; }

		#endregion Protected Properties

		#region Public Methods

		public override void Add(TEntity entity)
		{
			Context.Set<TEntity>().Add(entity);
		}

		public override bool Contains(TEntity entity)
		{
			return Context.Entry(entity) != null;
		}

		public override void Delete(TEntity entity)
		{
			Context.Entry(entity).State = EntityState.Deleted;
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

		public override void Save(TEntity model)
		{
			Context.Entry(model).State = EntityState.Modified;
		}

		public override int SaveChanges()
		{
			return Context.SaveChanges();
		}

		public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			int result = await Context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
			return result;
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