using J.Web.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace J.Web.Controllers
{
	public class SingleController : BaseController
	{
		//
		// GET: /Single/
		public ActionResult Index()
		{
			return View();
		}

        public ActionResult Detail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete()
        {
            return View();
        }
	}
}