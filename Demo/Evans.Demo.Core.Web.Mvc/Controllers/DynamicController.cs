using Evans.Demo.Core.Web.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Evans.Demo.Core.Web.Mvc.Controllers
{
    /// <summary>
    /// Base controller class that enables MVC routing for entities that for which a specific
    /// controller has not been created. This controller allows access to standard CRUD actions.
    /// </summary>
    /// <remarks>
    /// For route requests that are not matched, this controller will attempt to dynamically create
    /// and invoke the appropriate controller and action method based on the request path.
    /// </remarks>
    [Authorize]
    public class DynamicController : Controller
    {
        #region Public Fields

        public const string DefaultActionName = nameof(Index);

        #endregion Public Fields

        #region Private Fields

        private string _areaName = string.Empty;
        private IMvcRouter _router;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Base controller class for handling routes that target entities for which no controller
        /// has been created.
        /// <para>
        /// Uses the given <see cref="IMvcRouter" /> for resolving the appropriate controllers and
        /// action methods based on the route data provided by this controller.
        /// </para>
        /// </summary>
        /// <param name="router"></param>
        /// <returns></returns>
        public DynamicController(IMvcRouter router)
            : base()
        {
            _router = router;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Provides an MVC application area context for the requested path.
        /// </summary>
        public string AreaName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_areaName))
                {
                    _areaName = RouteData.GetAreaName();
                }

                return _areaName;
            }
            set
            {
                _areaName = value;
            }
        }

        #endregion Public Properties

        #region Protected Properties

        /// <summary>
        /// The object that is responsible for using the route data provided by this controller to
        /// resolve the appropriate controller / model types for the requested path, creating
        /// instances of those types, and routing the request to the appropriate action method.
        /// </summary>
        protected IMvcRouter Router
        {
            get { return _router; }
        }

        #endregion Protected Properties

        #region Public Methods

        [HttpGet]
        public ActionResult Create()
        {
            return RouteDynamic();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return RouteDynamic();
        }

        /// <summary>
        /// A controller / action could not be located for the requested path. Alert the user by
        /// forwarding to the default "not found" page.
        /// </summary>
        /// <returns></returns>
        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult RouteDynamic()
        {
            var requestedPath = Request.AppRelativeCurrentExecutionFilePath;
            // TODO Should this cache request paths to prevent lookups?
            var routeInfo = RouteInfo.From(AreaName, requestedPath);

            return Router.RouteDynamicRequest(routeInfo) ?? NotFound();
        }

        #endregion Public Methods
    }
}
