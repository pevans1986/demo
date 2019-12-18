using Evans.Demo.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evans.Demo.Core.Domain
{
	public interface IChangeSubscriber
	{
		void OnCreated<T>(IEnumerable<T> entities) where T : IDomainEntity;

		void OnDeleted<T>(IEnumerable<T> entities) where T : IDomainEntity;

		void OnUpdated<T>(IEnumerable<T> entities) where T : IDomainEntity;
	}
}
