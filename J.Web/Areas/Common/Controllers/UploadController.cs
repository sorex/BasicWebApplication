using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using J.Web.App_Code;
using J.DB;
using System.IO;
using Newtonsoft.Json;
using J.Util;

namespace J.Web.Areas.Common.Controllers
{
    /// <summary>
    /// 通用上传模块
    /// </summary>
    public class UploadController : BaseController
    {
        //
        // GET: /Common/Upload/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile()
        {
            if (base.CurrentUser == null)
                return Redirect("Home/Login");
            HttpPostedFileBase file = Request.Files["Filedata"]; //获取单独文件的访问
            var fileGuid = Guid.NewGuid().ToString();//生成随机的GUID
            try
            {
                if (file != null)
                {
                    var fileGUID = BasicTools.NewGuid();

                    var uploadPath = Server.MapPath("~/Files/UserFiles") + "\\" + base.CurrentUser.GUID + "\\" + fileGUID;

                    //上传路径不存在则创建路径
                    if (!Directory.Exists(uploadPath))
                        Directory.CreateDirectory(uploadPath);

                    //已存在文件则删除
                    if (System.IO.File.Exists(uploadPath + "\\" + file.FileName))
                        System.IO.File.Delete(uploadPath + "\\" + file.FileName);

                    file.SaveAs(uploadPath + "\\" + file.FileName);

                    using (DBEntities db = new DBEntities())
                    {
                        System.IO.FileInfo fileInfo = new FileInfo(uploadPath + "\\" + file.FileName);

                        uploadfile uploadfile = new uploadfile()
                        {
                            GUID = fileGUID,
                            userID = base.CurrentUser.GUID,
                            Name = file.FileName,
                            Extension = fileInfo.Extension,
                            Length = fileInfo.Length,
                            CreateDateTime = DateTime.Now
                        };

                        db.uploadfiles.Add(uploadfile);
                        db.SaveChanges();
                    }

                    return Content(new ReturnObject()
                    {
                        status = ReturnObject.EReturnStatus.success,
                        message = "<strong>登录名</strong> 或 <strong>登录密码</strong> 错误！",
                        data = new { userid = base.CurrentUser.GUID, guid = fileGUID, name = file.FileName }
                    }.ToString());

                }
                return Content(new ReturnObject()
                {
                    status = ReturnObject.EReturnStatus.error,
                    message = "文件不存在，请重新上传！"
                }.ToString());
            }
            catch (Exception e)
            {
                return Content(new ReturnObject()
                {
                    status = ReturnObject.EReturnStatus.error,
                    message = e.Message
                }.ToString());
            }
        }
    }
}