﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace J.Web.Controllers
{
    public class SampleController : Controller
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

		public ActionResult Chat()
		{
			return View();
		}
	}
}