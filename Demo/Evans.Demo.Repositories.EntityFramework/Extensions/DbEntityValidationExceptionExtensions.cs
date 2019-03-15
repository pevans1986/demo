using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Data.Entity.Validation
{
	public static class DbEntityValidationExceptionExtensions
	{
		#region Public Methods

		/// <summary>
		/// Provides a formatted message of error information for each property that failed validation.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static string GetFriendlyMessage(this DbEntityValidationException self)
		{
			var errorMessage = new StringBuilder();
			foreach (DbEntityValidationResult validationErrors in self.EntityValidationErrors)
			{
				foreach (DbValidationError validationError in validationErrors.ValidationErrors)
				{
					errorMessage
						.Append("Property: ")
						.Append(validationError.PropertyName)
						.Append(" Error: ")
						.Append(validationError.ErrorMessage)
						.Append(Environment.NewLine);
				}
			}

			return errorMessage.ToString();
		}

		#endregion Public Methods
	}
}