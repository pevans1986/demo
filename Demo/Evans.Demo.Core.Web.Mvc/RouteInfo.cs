using Evans.Demo.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evans.Demo.Core.Web.Mvc
{
	public class RouteInfo : PropertyChangeHandler
	{
		private const string DEFAULT_ACTION = "Index";

		#region Fields

		private string _actionName = string.Empty;
		private string _areaName;
		private string _modelTypeName = string.Empty;
		private List<object> _parameterValues;
		private string _requestPath;

		#endregion Fields

		#region Constructors

		private RouteInfo(string areaName, string requestPath)
		{
			_areaName = areaName;
			_requestPath = requestPath;
		}

		#endregion Constructors

		#region Properties

		public string ActionName
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_actionName))
				{
					_actionName = DEFAULT_ACTION;
				}

				return _actionName;
			}
			set
			{
				_actionName = value;
				OnPropertyChanged();
			}
		}

		public string AreaName
		{
			get
			{
				return _areaName;
			}
			set
			{
				_areaName = value;
				OnPropertyChanged();
			}
		}

		public string ModelTypeName
		{
			get
			{
				return _modelTypeName;
			}
			set
			{
				_modelTypeName = value;
				OnPropertyChanged();
			}
		}

		public Type[] ParameterTypes
		{
			get
			{
				return ParameterValues
					.Select(v => v.GetType())
					.ToArray();
			}
		}

		public List<object> ParameterValues
		{
			get
			{
				if (_parameterValues == null)
				{
					_parameterValues = new List<object>();
					OnPropertyChanged();
				}

				return _parameterValues;
			}
			set
			{
				_parameterValues = value;
				OnPropertyChanged();
			}
		}

		public string RequestPath
		{
			get { return _requestPath; }
		}

		#endregion Properties

		#region Methods

		public static RouteInfo From(string areaName, string requestPath)
		{
			var routeInfo = new RouteInfo(areaName, requestPath);
			return routeInfo.ParseRequestPath();
		}

		protected RouteInfo ParseRequestPath()
		{
			var areaNameCheck = $"{AreaName}/";
			var startIndex = RequestPath.LastIndexOf(areaNameCheck);

			if (startIndex >= 0)
			{
				startIndex += areaNameCheck.Length;
			}
			else
			{
				startIndex = 0;
			}

			// TODO Create a constant for path separator character
			var args = RequestPath.Substring(startIndex).Split('/').ToArray();

			// TODO Create method
			var parameters = new List<object>();

			int i = 0;
			foreach (string arg in args)
			{
				switch (i)
				{
					case 0:
						ModelTypeName = arg;
						break;

					case 1:
						ActionName = arg;
						break;

					default:
						parameters.Add(arg);
						break;
				}

				i++;
			}

			return this;
		}

		#endregion Methods
	}
}
