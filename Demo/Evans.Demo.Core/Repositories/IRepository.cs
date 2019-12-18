using Evans.Demo.Core.Domain;
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

		void Add(TModel entity);

		bool Contains(TModel entity);

		void Delete(TModel entity);

		List<TModel> GetAll();

		IQueryable<TModel> Query();

		void Save(TModel model);

		int SaveChanges();

		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

		void Subscribe(IChangeSubscriber subscriber);

		#endregion Public Methods
	}
}