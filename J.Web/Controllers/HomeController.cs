namespace J.Web.Controllers
{
	using System;
	using System.Linq;
	using System.Text;
	using System.Web.Mvc;

	using J.DB;
	using J.Logic.Basic;
	using J.Util.Cryptography;

	using Newtonsoft.Json;

	using NLog;

	public class HomeController : Controller
	{
		#region Static Fields

		private static Logger logger = LogManager.GetCurrentClassLogger();

		#endregion

		#region Public Methods and Operators

		//[OutputCache(Duration = 3600)]
		public ActionResult About()
		{
			return this.View();
		}

		public ActionResult Index()
		{
			return this.View();
		}

		public ActionResult Login()
		{
			return this.View();
		}

		[HttpPost]
		[ActionName("Login")]
		public ActionResult LoginPost(string LoginName, string LoginPassword)
		{
			LoginName = Encoding.UTF8.GetString(Convert.FromBase64String(LoginName));
			LoginPassword = new DESEncrypt().EncryptString(Encoding.UTF8.GetString(Convert.FromBase64String(LoginPassword)));

			using (var db = new DBEntities())
			{
				user User =
					(from u in db.users where u.LoginName == LoginName && u.LoginPassword == LoginPassword select u).FirstOrDefault();

				if (User == null && this.Request.IsAjaxRequest())
				{
					return
						this.Content(
							JsonConvert.SerializeObject(new { code = -1, msg = "<strong>登录名</strong> 或 <strong>登录密码</strong> 错误！" }));
				}
				this.Session[SessionConfig.CurrentUser] = User;
				return this.Content(JsonConvert.SerializeObject(new { code = 1, msg = "登录成功。" }));
			}
		}

		public ActionResult Register()
		{
			return this.View();
		}

		[HttpPost]
		[ActionName("Register")]
		public ActionResult RegisterPost()
		{
			return this.View();
		}

		#endregion
	}
}