using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Evans.Demo.Core.Domain;

namespace Evans.Demo.Core.Tests.TestObjects
{
	[MemberDescription(ClassDescriptionValue)]
	public class Foo : IDomainEntity
	{
		#region Public Fields

		public const string ClassDescriptionValue = "A test class";

		public const string NameDescriptionValue = "The name";

		#endregion Public Fields

		#region Public Properties

		[Key]
		[Unique]
		[MemberDescription("The Guid identifier")]
		public Guid Id { get; set; } = Guid.NewGuid();

		[MemberDescription(NameDescriptionValue)]
		public string Name { get; set; }

		#endregion Public Properties
	}
}