using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evans.Demo.Core.Domain
{
	public class DomainEntity : IDomainEntity
	{
		#region Public Properties

		public DateTime CreatedDate { get; set; } = DateTime.Now;

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }

		public DateTime ModifiedDate { get; set; } = DateTime.Now;

		#endregion Public Properties
	}
}