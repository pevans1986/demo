using Evans.Demo.Core.Domain;
using Evans.Demo.Core.Extensions.System;
using Evans.Demo.Core.Logging;
using Evans.Demo.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Evans.Demo.Core.Web.Mvc.Controllers
{
	/// <summary>
	/// Base class for ASP.Net MVC controllers.
	/// </summary>
	/// <remarks>
	/// This class extends <see cref="Controller" /> and provides basic CRUD operations.
	/// </remarks>
	public class MvcController<TModel> : Controller
		where TModel : IDomainEntity
	{
		#region Private Fields

		private ILogger _logger;
		private IService<TModel> _service;

		#endregion Private Fields

		#region Public Constructors

		/// <summary>
		/// Uses the given <see cref="IService{TModel}" /> to perform operations on the
		/// model.
		/// </summary>
		/// <param name="service"></param>
		/// <param name="logger"></param>
		/// <returns></returns>
		public MvcController(IService<TModel> service, ILogger logger)
		{
			_service = service;
			_logger = logger;
		}

		#endregion Public Constructors

		#region Protected Properties

		/// <summary>
		/// The business logic class for performing actions on the model.
		/// </summary>
		protected IService<TModel> Service
		{
			get { return _service; }
		}

		#endregion Protected Properties

		#region Public Methods

		/// <summary>
		/// Returns the default view for creating a new record.
		/// </summary>
		/// <remarks>Serves HTTP GET requests to [Area]/[Controller]/Create</remarks>
		/// <returns></returns>
		[HttpGet]
		//[ValidateAntiForgeryToken]
		public virtual ActionResult Create()
		{
			// TODO Use a constant
			return View("Create", typeof(TModel).New());
		}

		/// <summary>
		/// Handles POST requests to create a new record using the given model created from
		/// form data.
		/// </summary>
		/// <remarks>Serves HTTP POST requests to [Area]/[Controller]/Create</remarks>
		/// <param name="entity"></param>
		/// <returns></returns>
		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult Create(TModel entity)
		{
			try
			{
				Service.Add(entity);
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: [Area]/[Controller]/Delete/{id}
		[HttpGet]
		//[ValidateAntiForgeryToken]
		public virtual ActionResult Delete(object id)
		{
			return View();
		}

		// POST: [Area]/[Controller]/Delete/{id}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult Delete(object id, FormCollection collection)
		{
			try
			{
				var guidId = Guid.Parse(id.ToString());
				Service.Delete(guidId);

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: [Area]/[Controller]/Details/{id}
		[HttpGet]
		//[ValidateAntiForgeryToken]
		public virtual ActionResult Details(object id)
		{
			Guid.TryParse(id.ToString(), out Guid guidId);
			var model = Service.GetById(guidId);

			return View(model);
		}

		// GET: [Area]/[Controller]/Edit/{id}
		[HttpGet]
		//[ValidateAntiForgeryToken]
		public virtual ActionResult Edit(object id)
		{
			Guid.TryParse(id.ToString(), out Guid guidId);
			var model = Service.GetById(guidId);

			return View(model);
		}

		// POST: [Area]/[Controller]/Edit/
		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult Edit(TModel entity)
		{
			try
			{
				Service.Update(entity);
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: [Area]/[Controller]
		[HttpGet]
		//[ValidateAntiForgeryToken]
		public virtual ActionResult Index()
		{
			var models = Service.GetAll();
			return View(models);
		}

		#endregion Public Methods
	}
}
