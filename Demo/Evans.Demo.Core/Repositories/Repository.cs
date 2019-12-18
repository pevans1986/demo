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
		protected List<IChangeSubscriber> Subscribers { get; set; } = new List<IChangeSubscriber>();

		#region Public Methods

		public abstract void Add(TEntity entity);

		public abstract bool Contains(TEntity entity);

		public abstract void Delete(TEntity entity);

		public abstract void Dispose();

		public virtual List<TEntity> GetAll() => Query().ToList();

		public abstract IQueryable<TEntity> Query();

		public abstract void Save(TEntity model);

		public abstract int SaveChanges();

		public void Subscribe(IChangeSubscriber subscriber)
		{
			// TODO Confirm item is not already in list
			Subscribers.Add(subscriber);
		}

		#endregion Public Methods

		protected void NotifyCreated<T>(IEnumerable<T> entities) where T : IDomainEntity
		{
			Subscribers.ForEach(s => s.OnCreated(entities));
		}

		protected void NotifyDeleted<T>(IEnumerable<T> entities) where T : IDomainEntity
		{
			Subscribers.ForEach(s => s.OnDeleted(entities));
		}

		protected void NotifyUpdated<T>(IEnumerable<T> entities) where T : IDomainEntity
		{
			Subscribers.ForEach(s => s.OnUpdated(entities));
		}
	}
}