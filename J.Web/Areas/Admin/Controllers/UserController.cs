﻿using System.Linq;
using System.Web.Mvc;
using J.DB;
using Newtonsoft.Json;

namespace J.Web.Areas.Admin.Controllers
{
	public class UserController : Controller
	{
		/// <summary>
		///     User List
		/// </summary>
		/// <returns></returns>
		public ActionResult Index()
		{
			using (var db = new DBEntities())
			{
				var list = from u in db.users
					select
						new
						{
							u.GUID,
							u.ShowName,
							u.LoginName,
							u.Email,
							u.CreateDateTime,
							LastLogin = u.user_loginlogs.Max(p => p.LoginDateTime) ?? u.CreateDateTime,
							LoginCount = u.user_loginlogs.Count
						};

				ViewBag.listJson = JsonConvert.SerializeObject(new {items = list});
			}
			return View();
		}
	}
}