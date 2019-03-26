using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
		// DELETE api/<controller>/<guid>
		public virtual IHttpActionResult Delete(Guid id)
		{
			try
			{
				Service.Delete(id);
				return Ok();
			}
			catch (Exception exception)
			{
				// TODO Log exception
				return BadRequest(exception.Message);
			}
		}

		[HttpGet]
		// GET api/<controller>
		public virtual async Task<IHttpActionResult> GetAsync()
		{
			try
			{
				var results = await Service.GetAllAsync().ConfigureAwait(false);
				//return Ok(Service.GetAll());
				return Ok(results);
			}
			catch (Exception exception)
			{
				// TODO Log exception
				return BadRequest(exception.Message);
			}
		}

		[HttpGet]
		// GET api/<controller>/<guid>
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
		// POST api/<controller>
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
		// PUT api/<controller>/<guid>
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