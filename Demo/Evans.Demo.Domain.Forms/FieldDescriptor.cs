using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Evans.Demo.Core.Domain;

namespace Evans.Demo.Domain.Forms
{
	public class FieldDescriptor : DomainEntity
	{
		public FieldType FieldType { get; set; } = FieldType.Text;

		public string Name { get; set; }
	}
}
