using J.DB;
using J.Util;
using J.Web.App_Code;
using Newtonsoft.Json;
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

		public ActionResult Detail(string guid)
		{
			using (DBEntities db = new DBEntities())
			{
                var item = db.singles.FirstOrDefault(p => p.GUID == guid.ToLower());

				return this.Content(new ReturnObject()
				{
					status = item == null ? ReturnObject.EReturnStatus.error : ReturnObject.EReturnStatus.success,
					message = item == null ? "您要获取的数据不存在！" : "获取数据成功",
					data = item
				}.ToString());
			}
		}

		[HttpPost]
		public ActionResult Add(string jsonobj)
		{
            using (DBEntities db = new DBEntities())
            {
                var item = JsonConvert.DeserializeObject<single>(jsonobj);

                item.GUID = BasicTools.NewGuid();

                db.singles.Add(item);
                db.SaveChanges();

                return this.Content(new ReturnObject()
                {
                    status = ReturnObject.EReturnStatus.success,
                    message = "添加数据成功！",
                    data = item
                }.ToString());
            }
		}

		[HttpPost]
        public ActionResult Edit(string jsonobj)
		{
            using (DBEntities db = new DBEntities())
            {
                var item = JsonConvert.DeserializeObject<single>(jsonobj);

                db.singles.Attach(item);
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                
                db.SaveChanges();

                return this.Content(new ReturnObject()
                {
                    status = ReturnObject.EReturnStatus.success,
                    message = "添加数据成功！",
                    data = item
                }.ToString());
            }
		}

		[HttpPost]
		public ActionResult Delete(string guid)
		{
            using (DBEntities db = new DBEntities())
            {
                var item = db.singles.FirstOrDefault(p => p.GUID == guid.ToLower());

                db.singles.Remove(item);
                db.SaveChanges();

                return this.Content(new ReturnObject()
                {
                    status = ReturnObject.EReturnStatus.success,
                    message = "删除数据成功！"
                }.ToString());
            }
        }
	}
}