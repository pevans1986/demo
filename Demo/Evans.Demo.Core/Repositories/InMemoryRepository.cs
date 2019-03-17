using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Evans.Demo.Core.Domain;

namespace Evans.Demo.Core.Repositories
{
	public class InMemoryRepository<TEntity> : Repository<TEntity>, IRepository<TEntity> where TEntity : IDomainEntity
	{
		#region Private Fields

		private readonly List<TEntity> _data = new List<TEntity>();

		#endregion Private Fields

		#region Public Methods

		public override IRepository<TEntity> Add(TEntity entity)
		{
			if (!_data.Contains(entity))
			{
				_data.Add(entity);
			}

			return this;
		}

		public override IRepository<TEntity> Delete(TEntity entity)
		{
			_data.Remove(entity);

			return this;
		}

		public override IRepository<TEntity> DeleteById(object id)
		{
			throw new NotImplementedException();
		}

		public override void Dispose() { }

		public override TEntity Find(params object[] keys)
		{
			// TODO Look for properties with Key attribute; check EF implementation
			throw new NotImplementedException();
		}

		public override List<TEntity> GetAll() => _data;

		public override IQueryable<TEntity> Query() => _data.AsQueryable();

		public override IRepository<TEntity> Save(TEntity model)
		{
			throw new NotImplementedException();
		}

		public override IRepository<TEntity> SaveChanges() => this;

		#endregion Public Methods
	}
}