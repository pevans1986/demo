using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Evans.Demo.Core.Domain;

namespace Evans.Demo.Core.Services
{
	public interface IService<T> : IDisposable
		where T : IDomainEntity
	{
		#region Public Methods

		void Add(T value);

		void AddOrUpdate(T value);

		void Delete(Guid id);

		void Delete(T value);

		IQueryable<T> FindWhere(Expression<Func<T, bool>> predicate);

		IEnumerable<T> GetAll();

		Task<IEnumerable<T>> GetAllAsync();

		T GetById(Guid id);

		Task<T> GetByIdAsync(Guid? id);

		T GetFirst(Expression<Func<T, bool>> predicate);

		void Update(T value);

		#endregion Public Methods
	}
}