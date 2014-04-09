using J.DB;
using J.Util;
using J.Web.App_Code;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace J.Web.Controllers
{
    public class SingleController : BaseController
    {
        //
        // GET: /Single/
        public ActionResult Index(int PageSize = 25, int PageIndex = 1, int? SingleIntNumber_min = null, int? SingleIntNumber_max = null, int? SingleIntEnum = null,
            decimal? SingleMoney_min = null, decimal? SingleMoney_max = null, DateTime? SingleDatetime_min = null, DateTime? SingleDatetime_max = null,
            string SingleVarchar = null, bool? SingleBit = null)
        {
            using (DBEntities db = new DBEntities())
            {
                var query = from s in db.singles
                            where (SingleIntNumber_min == null || SingleIntNumber_min.Value <= s.SingleIntNumber) &&
                            (SingleIntNumber_max == null || SingleIntNumber_max.Value >= s.SingleIntNumber) &&
                            (SingleIntEnum == null || (J.DB.Enum.single.SingleIntEnum)SingleIntEnum.Value == s.SingleIntEnum) &&
                            (SingleMoney_min == null || SingleMoney_min.Value <= s.SingleMoney) &&
                            (SingleMoney_max == null || SingleMoney_max.Value >= s.SingleMoney) &&
                            (SingleDatetime_min == null || SingleDatetime_min.Value <= s.SingleDatetime) &&
                            (SingleDatetime_max == null || SingleDatetime_max.Value >= s.SingleDatetime) &&
                            (SingleVarchar == null || s.SingleVarchar.Contains(SingleVarchar)) &&
                            (SingleBit == null || SingleBit.Value == s.SingleBit)
                            orderby s.SingleDatetime descending
                            select s;

                int RecordCount = query.Count();
               
                if (RecordCount <= (PageIndex - 1) * PageSize)
                    PageIndex = 1;

                var data = query.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();

                if (Request.IsAjaxRequest())
                {
                    return this.Content(new ReturnObject()
                    {
                        status = data == null ? ReturnObject.EReturnStatus.error : ReturnObject.EReturnStatus.success,
                        message = data == null ? "您要获取的数据不存在！" : "获取数据成功",
                        data = new { items = data, RecordCount = RecordCount, PageSize = PageSize, PageIndex = PageIndex }
                    }.ToString());
                }
                else
                {
                    ViewBag.dataJson = BasicTools.Object2JavaScriptJsonString("dataJson", new { items = data, RecordCount = RecordCount, PageSize = PageSize, PageIndex = PageIndex });
                    return View();
                }
            }
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
            jsonobj = Encoding.UTF8.GetString(Convert.FromBase64String(jsonobj));
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