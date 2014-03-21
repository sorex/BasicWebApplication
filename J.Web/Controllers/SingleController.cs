using J.DB;
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

		public ActionResult Detail(string GUID)
		{
			using (DBEntities db = new DBEntities())
			{
				var item = db.singles.FirstOrDefault(p => p.GUID == GUID.ToLower());

				return this.Content(new ReturnObject()
				{
					status = item == null ? ReturnObject.EReturnStatus.error : ReturnObject.EReturnStatus.success,
					message = item == null ? "您要获取的数据不存在！" : "获取数据成功",
					data = item
				}.ToString());
			}
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