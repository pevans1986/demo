using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Evans.Demo.Core.Domain;

namespace Evans.Demo.Domain.Forms
{
	public class Form : DomainEntity
	{
		public string Name { get; set; }

		public virtual ICollection<FormField> Fields { get; set; }

	}
}
