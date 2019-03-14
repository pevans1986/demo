using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evans.Demo.Core.Domain
{
	public interface IDomainEntity : IModel<Guid>
	{
		#region Public Properties

		Guid Id { get; set; }

		#endregion Public Properties
	}
}
