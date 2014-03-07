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
    using J.Web.App_Code;
    using J.Util;

    public class HomeController : BaseController
    {
        #region Static Fields

        private static Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        //[OutputCache(Duration = 3600)]
        #region Public Methods and Operators

        public ActionResult About()
        {
            return this.View();
        }

        public ActionResult Index()
        {
            //using (var db = new DBEntities())
            //{
            //	var user = new user()
            //	{
            //		CreateDateTime = DateTime.Now,
            //		Email = "sorex@163.com",
            //		GUID = BasicTools.NewGuid(),
            //		LoginName = "sorex",
            //		LoginPassword = "123456",
            //		ShowName = "徐磊"
            //	};
            //
            //	var user_loginlog = new user_loginlog()
            //	{
            //		userID = user.GUID,
            //		LoginDateTime = DateTime.Now
            //	};
            //
            //	db.users.Add(user);
            //	db.user_loginlog.Add(user_loginlog);
            //	db.SaveChanges();
            //}

            if (System.Configuration.ConfigurationManager.AppSettings["MustLogin"] == "true")
                return RedirectToAction("Login");

            return this.View();
        }

        #endregion
    }
}