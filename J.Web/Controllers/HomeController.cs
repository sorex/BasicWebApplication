using J.DB;
using J.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace J.Web.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			return View();
		}

		[HttpPost]
		public ActionResult LoginCheck(string LoginName, string LoginPassword)
		{
			return View();
		}

	}
}
