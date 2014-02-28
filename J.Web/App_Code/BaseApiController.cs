using J.DB;
using J.Logic.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace J.Web.App_Code
{
    public class BaseApiController : ApiController
    {
        public user CurrentUser
        {
            get
            {
                if (HttpContext.Current.Session[SessionConfig.CurrentUser] != null)
                    return (user)HttpContext.Current.Session[SessionConfig.CurrentUser];
                else
                    return null;
            }
        }
    }
}