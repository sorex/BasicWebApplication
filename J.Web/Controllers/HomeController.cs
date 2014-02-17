using J.DB;
using J.Logic.Basic;
using J.Util;
using J.Util.Cryptography;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace J.Web.Controllers
{
	public class HomeController : Controller
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();

		//[OutputCache(Duration = 3600)]
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			return View();
		}

		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[ActionName("Login")]
		public ActionResult LoginPost(string LoginName, string LoginPassword)
		{
			LoginName = Encoding.UTF8.GetString(Convert.FromBase64String(LoginName));
			LoginPassword = new DESEncrypt().EncryptString(Encoding.UTF8.GetString(Convert.FromBase64String(LoginPassword)));

			using (DBEntities db = new DBEntities())
			{
				var User = (from u in db.users
							where u.LoginName == LoginName && u.LoginPassword == LoginPassword
							select u).FirstOrDefault();

				if (User == null && Request.IsAjaxRequest())
					return Content(JsonConvert.SerializeObject(new { code = -1, msg = "<strong>登录名</strong> 或 <strong>登录密码</strong> 错误！" }));
				else
				{
					Session[SessionConfig.CurrentUser] = User;
					return Content(JsonConvert.SerializeObject(new { code = 1, msg = "登录成功。" }));
				}
			}
		}

		public ActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[ActionName("Register")]
		public ActionResult RegisterPost()
		{
			return View();
		}

	}
}
