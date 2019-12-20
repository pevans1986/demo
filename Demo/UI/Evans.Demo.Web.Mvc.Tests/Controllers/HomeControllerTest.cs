using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Evans.Demo.Web.Mvc.Controllers;

namespace Evans.Demo.Web.Mvc.Tests.Controllers
{
	[TestClass]
	public class HomeControllerTest
	{
		#region Public Methods

		[TestMethod]
		public void About()
		{
			using (HomeController controller = new HomeController())
			{
				// Act
				ViewResult result = controller.About() as ViewResult;

				// Assert
				Assert.AreEqual("Your application description page.", result.ViewBag.Message);
			}
		}

		[TestMethod]
		public void Contact()
		{
			using (HomeController controller = new HomeController())
			{
				// Act
				ViewResult result = controller.Contact() as ViewResult;

				// Assert
				Assert.IsNotNull(result);
			}
		}

		[TestMethod]
		public void Index()
		{
			using (HomeController controller = new HomeController())
			{
				// Act
				ViewResult result = controller.Index() as ViewResult;

				// Assert
				Assert.IsNotNull(result);
			}
		}

		#endregion Public Methods
	}
}