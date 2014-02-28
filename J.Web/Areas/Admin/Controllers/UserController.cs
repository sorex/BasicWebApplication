using System.Linq;
using System.Web.Mvc;
using J.DB;
using Newtonsoft.Json;
using J.Web.App_Code;
using J.Util;

namespace J.Web.Areas.Admin.Controllers
{
    public class UserController : BaseController
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

                //ViewBag.listJson = JsonConvert.SerializeObject(new { items = list }, new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter());
                ViewBag.listJson = BasicTools.Object2JavaScriptJsonString("listJson", new { items = list });
			}
			return View();
		}

		public ActionResult LoginLogs(string userID)
		{
			using (var db = new DBEntities())
			{
				var user = (from u in db.users
						   where u.GUID == userID.ToLower()
						   select
							   new
							   {
								   u.GUID,
								   u.ShowName,
								   u.LoginName,
								   u.Email,
								   u.CreateDateTime,
								   LoginCount = u.user_loginlogs.Count
							   }).FirstOrDefault();

				var list = from l in db.user_loginlog
						   where l.userID == userID.ToLower()
						   orderby l.LoginDateTime descending 
						   select
							   new
							   {
								   l.LoginDateTime
							   };

                ViewBag.userJson = JsonConvert.SerializeObject(user).Replace("'", "\\'").Replace("\\\"", "\\\\\"");
                ViewBag.listJson = JsonConvert.SerializeObject(new { items = list }).Replace("'", "\\'").Replace("\\\"", "\\\\\"");
			}

			return View();
		}
	}
}