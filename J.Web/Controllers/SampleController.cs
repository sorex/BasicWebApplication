using J.Web.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace J.Web.Controllers
{
    public class SampleController : BaseController
    {
        //
        // GET: /Sample/
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult datetimepicker()
		{
			return View();
		}
	}
}