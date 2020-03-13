using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Evans.Demo.Core.Domain;

namespace Evans.Demo.Domain.Forms
{
	public class FormField : DomainEntity
	{
		public virtual Form Form { get;set; }

		public virtual FieldDescriptor Field { get; set; }

		public int DisplayOrder { get; set; }
	}
}
