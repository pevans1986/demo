using System;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Web.Http;

using Evans.Demo.Core.Domain;
using Evans.Demo.Core.Services;

namespace Evans.Demo.Core.Web.Api.Controllers
{
	public class CrudController<TEntity> : ApiController where TEntity : IDomainEntity
	{
		#region Public Constructors

		public CrudController(IService<TEntity> service)
		{
			Service = service;
		}

		#endregion Public Constructors

		#region Protected Properties

		protected IService<TEntity> Service { get; }

		#endregion Protected Properties

		#region Public Methods

		[HttpDelete]
		/// <summary>
		/// Deletes the object identified by the given <paramref name="id"/> value.
		/// </summary>
		/// <param name="id">Entity key value</param>
		/// <returns></returns>
		public virtual async Task<IHttpActionResult> DeleteAsync(Guid id)
		{
			try
			{
				var entity = await Service.GetByIdAsync(id).ConfigureAwait(false);
				if (entity == null)
				{
					return NotFound();
				}

				Service.Delete(entity);
				return Ok();
			}
			catch (Exception exception)
			{
				// TODO Log exception
				return BadRequest(exception.Message);
			}
		}

		[HttpGet]
		public virtual async Task<IHttpActionResult> GetAsync()
		{
			try
			{
				var results = await Service.GetAllAsync().ConfigureAwait(false);
				return Ok(results);
			}
			catch (Exception exception)
			{
				// TODO Log exception
				return BadRequest(exception.Message);
			}
		}

		[HttpGet]
		public virtual async Task<IHttpActionResult> GetAsync(Guid id)
		{
			var result = await Service.GetByIdAsync(id).ConfigureAwait(false);

			if (result == null)
			{
				return NotFound();
			}

			return Ok(result);
		}

		[HttpPost]
		public IHttpActionResult Post(TEntity value)
		{
			try
			{
				Service.Add(value);
				// TODO Return CreatedAtRoute(...)
				return Ok();
			}
			catch (Exception exception)
			{
				// TODO Log exception
				return BadRequest(exception.Message);
			}
		}

		[HttpPut]
		public IHttpActionResult Put(Guid id, TEntity value)
		{
			try
			{
				value.Id = id;
				Service.AddOrUpdate(value);

				return Ok();
			}
			catch (Exception exception)
			{
				// TODO Log exception
				return BadRequest(exception.Message);
			}
		}

		#endregion Public Methods

		#region Protected Methods

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				Service?.Dispose();
				base.Dispose(disposing);
			}
		}

		#endregion Protected Methods
	}
}