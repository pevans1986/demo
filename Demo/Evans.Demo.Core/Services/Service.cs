using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Evans.Demo.Core.Domain;
using Evans.Demo.Core.Repositories;

namespace Evans.Demo.Core.Services
{
	public class Service<T> : IService<T>
		where T : IDomainEntity
	{
		#region Private Fields

		private bool _isDisposed;

		#endregion Private Fields

		#region Public Constructors

		public Service(IRepository<T> repository)
		{
			Repository = repository;
		}

		#endregion Public Constructors

		#region Protected Properties

		protected virtual IRepository<T> Repository { get; }

		#endregion Protected Properties

		#region Public Methods

		public virtual void Add(T value)
		{
			Repository.Add(value);
			Repository.SaveChanges();
		}

		public void AddOrUpdate(T value)
		{
			if (Repository.Contains(value))
			{
				Repository.Save(value);
			}
			else
			{
				Repository.Add(value);
			}

			Repository.SaveChanges();
		}

		public void Delete(Guid id)
		{
			var entity = GetById(id);
			if (entity != null)
			{
				Repository.Delete(entity);
				Repository.SaveChanges();
			}
		}

		public void Delete(T value)
		{
			Repository.Delete(value);
			Repository.SaveChanges();
		}

		public void Dispose()
		{
			Dispose(true);
		}

		public virtual IQueryable<T> FindWhere(Expression<Func<T, bool>> predicate)
		{
			return Repository.Query().Where(predicate);
		}

		public virtual IEnumerable<T> GetAll()
		{
			return Repository.GetAll();
		}

		public virtual async Task<IEnumerable<T>> GetAllAsync()
		{
			return await Task.Factory
				.StartNew<IEnumerable<T>>(() => Repository.GetAll())
				.ConfigureAwait(false);
		}

		public virtual T GetById(Guid id)
		{
			return Repository.Query().FirstOrDefault(entity => entity.Id == id);
		}

		public virtual async Task<T> GetByIdAsync(Guid? id)
		{
			if (id == null)
			{
				throw new ArgumentNullException(nameof(id));
			}

			return await Task.Factory
				.StartNew<T>(() => GetById((Guid)id))
				.ConfigureAwait(false);
		}

		public virtual T GetFirst(Expression<Func<T, bool>> predicate)
		{
			return Repository.Query().First(predicate);
		}

		public virtual void Update(T value)
		{
			Repository.Save(value);
			Repository.SaveChanges();
		}

		#endregion Public Methods

		#region Protected Methods

		protected virtual void Dispose(bool disposing)
		{
			if (!_isDisposed && disposing)
			{
				Repository?.Dispose();
				_isDisposed = true;
			}
		}

		#endregion Protected Methods
	}
}