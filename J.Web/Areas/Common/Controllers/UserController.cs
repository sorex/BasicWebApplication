using J.DB;
using J.Logic.Basic;
using J.Util;
using J.Util.Cryptography;
using J.Web.App_Code;
using NLog;
using System;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace J.Web.Areas.Common.Controllers
{
    public class UserController : Controller
    {
        #region Static Fields

        private static Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Public Methods and Operators

        [HttpPost]
        [ActionName("Login")]
        public ActionResult LoginPost(string LoginName, string LoginPassword)
        {
            LoginName = Encoding.UTF8.GetString(Convert.FromBase64String(LoginName));
            LoginPassword = new DESEncrypt().EncryptString(Encoding.UTF8.GetString(Convert.FromBase64String(LoginPassword)));

            using (DBEntities db = new DBEntities())
            {
                user User = (from u in db.users where u.LoginName == LoginName && u.LoginPassword == LoginPassword select u).FirstOrDefault();

                if (User == null && this.Request.IsAjaxRequest())
                {
                    return this.Content(new ReturnObject()
                    {
                        status = ReturnObject.EReturnStatus.error,
                        message = "<strong>登录名</strong> 或 <strong>登录密码</strong> 错误！"
                    }.ToString());
                }
                this.Session[SessionConfig.CurrentUser] = User;
                return this.Content(new ReturnObject()
                {
                    status = ReturnObject.EReturnStatus.success,
                    message = "登录成功。"
                }.ToString());
            }
        }

        [HttpPost]
        [ActionName("Register")]
        public ActionResult RegisterPost(string LoginName, string ShowName, string Email, string LoginPassword)
        {
            LoginName = Encoding.UTF8.GetString(Convert.FromBase64String(LoginName));
            ShowName = Encoding.UTF8.GetString(Convert.FromBase64String(ShowName));
            Email = Encoding.UTF8.GetString(Convert.FromBase64String(Email));
            LoginPassword = new DESEncrypt().EncryptString(Encoding.UTF8.GetString(Convert.FromBase64String(LoginPassword)));

            using (DBEntities db = new DBEntities())
            {
                if (db.users.Count(p => p.LoginName == LoginName) > 0)
                    return this.Content(new ReturnObject()
                    {
                        status = ReturnObject.EReturnStatus.error,
                        message = "<strong>登录名</strong> 已被注册，请换个 <strong>登录名</strong> ！"
                    }.ToString());

                if (db.users.Count(p => p.Email == Email) > 0)
                    return this.Content(new ReturnObject()
                    {
                        status = ReturnObject.EReturnStatus.error,
                        message = "<strong>电子邮箱</strong> 已被注册，请换个 <strong>电子邮箱</strong> ！"
                    }.ToString());


                var User = new user
                {
                    GUID = BasicTools.NewGuid(),
                    LoginName = LoginName,
                    Email = Email,
                    ShowName = ShowName,
                    LoginPassword = LoginPassword,
                    CreateDateTime = DateTime.Now
                };
                var User_Loginlog = new user_loginlog
                {
                    userID = User.GUID,
                    LoginDateTime = DateTime.Now
                };

                db.users.Add(User);
                db.user_loginlog.Add(User_Loginlog);
                db.SaveChanges();

                this.Session[SessionConfig.CurrentUser] = User;
                return this.Content(new ReturnObject()
                {
                    status = ReturnObject.EReturnStatus.success,
                    message = "注册成功！"
                }.ToString());
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        #endregion
    }
}