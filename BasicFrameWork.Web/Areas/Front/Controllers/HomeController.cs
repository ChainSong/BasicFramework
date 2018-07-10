using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BasicFramework.Biz;
using BasicFramework.Common;
using BasicFramework.Entity;
using BasicFramework.MessageContracts;
using BasicFramework.Web.Common;
using MyFile = System.IO.File;
using UtilConstants = BasicFramework.Common.Constants;
using System.Net;

namespace BasicFramework.Web.Areas.Front.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View(GetMenu());
        }

        public ActionResult LogOff()
        {
            Session.Abandon();

            return RedirectToAction("", "../Login");
        }
        public ActionResult WelcomePage()
        {
           
            return View();
        }
       

        public ActionResult Content(int? firstMenuID, int? secondMenuID)
        {
            ViewData["menu"] = GetAll3RdMenu(secondMenuID);

            return View();
        }

        [HttpPost]
        public string AjaxUpload(string gid, bool isMultiple, bool isCoverOld)
        {
            string uploadFolderPath = BasicFramework.Common.Constants.UPLOAD_FOLDER_PATH;
            string targetPath = Path.Combine(uploadFolderPath, "1", DateTime.Now.DateTimeToString());
            DateTime createDate;
            string attachmentGroupID = gid, url = string.Empty, actualNameInServer = string.Empty, displayName = string.Empty, ext = string.Empty;
            IList<Attachment> attachments = new List<Attachment>();

            if (string.IsNullOrEmpty(targetPath) || !Path.IsPathRooted(targetPath))
            {
                return new { msg = "程序出错，请联系IT" }.ToJsonString();
            }

            try
            {
                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase hpf = Request.Files[0] as HttpPostedFileBase;
                    if (hpf.ContentLength > 0)
                    {
                        if (!Directory.Exists(targetPath))
                        {
                            Directory.CreateDirectory(targetPath);
                        }

                        displayName = Path.GetFileName(hpf.FileName);
                        ext = Path.GetExtension(hpf.FileName);

                        if (isMultiple && !ext.ToLower().Equals(".zip"))
                        {
                            return new { msg = "批量上传，请用zip格式压缩" }.ToJsonString();
                        }

                        actualNameInServer = displayName.Substring(0, displayName.Length - ext.Length + 1) + DateTime.Now.ToString("yyyyMMddHHmmss") + ext;
                        url = Path.Combine(targetPath, actualNameInServer);
                        hpf.SaveAs(url);
                        hpf.InputStream.Close();
                        if (ext.ToLower().Equals(".zip") && isMultiple)
                        {
                            IList<string> unZipedFileName = new List<string>();
                            ZipHelper.UnZip(url, targetPath, unZipedFileName);
                            MyFile.Delete(url);
                            unZipedFileName.Each((k, fileName) =>
                            {
                                actualNameInServer = Path.GetFileName(fileName);
                                ext = Path.GetExtension(fileName);
                                string groupID = Path.GetFileNameWithoutExtension(Path.GetFileNameWithoutExtension(actualNameInServer));
                                displayName = groupID + ext;
                                createDate = DateTime.Now;
                                attachments.Add(new Attachment() { ActualNameInServer = actualNameInServer, DisplayName = displayName, Extension = ext, Url = fileName, GroupID = groupID, CreateDate = createDate, CreateUserID = base.UserInfo.ID, Creator = base.UserInfo.Name });
                            });
                        }
                        else
                        {
                            attachments.Add(new Attachment() { ActualNameInServer = actualNameInServer, DisplayName = displayName, Extension = ext, Url = url, GroupID = string.IsNullOrEmpty(attachmentGroupID) ? Guid.NewGuid().ToString() : attachmentGroupID, CreateDate = DateTime.Now, CreateUserID = base.UserInfo.ID, Creator = base.UserInfo.Name });
                        }

                        AttachmentService service = new AttachmentService();
                        Response<IEnumerable<Attachment>> response = service.AddAttachment(new AddAttachmentRequest() { attachments = attachments, IsCoverOld = isCoverOld });

                        if (response.IsSuccess)
                        {
                            if (isMultiple)
                            {
                                return new
                                {
                                    msg = "批量上传文件成功",
                                    aids = response.Result.Select(a => a.ID),
                                    anms = response.Result.Select(a => a.DisplayName),
                                    times = response.Result.Select(a => a.CreateDate),
                                    creators = response.Result.Select(a => a.Creator)
                                }.ToJsonString();
                            }
                            else
                            {
                                return new
                                {
                                    msg = "上传文件成功",
                                    gid = response.Result.First().GroupID,
                                    aid = response.Result.First().ID,
                                    anm = response.Result.First().DisplayName,
                                    time = response.Result.First().CreateDate,
                                    creator = response.Result.First().Creator
                                }.ToJsonString();
                            }
                        }
                        else
                        {
                            return new { msg = "上传文件失败，请联系IT" }.ToJsonString();
                        }
                    }
                }

                return new { msg = "文件无内容" }.ToJsonString();
            }
            catch (Exception ex)
            {
                return new { msg = ex.Message }.ToJsonString();
            }
        }



        public ActionResult GetAttachment(long? id)
        {
            if (id.HasValue)
            {
                AttachmentService service = new AttachmentService();
                Response<Attachment> resp = service.GetAttachmentByID(new GetAttachmentByIDRequest() { ID = id.Value });

                if (resp.IsSuccess)
                {
                    string encode = string.Empty;
                    if (resp.Result.DisplayName.EndsWith("xlsx", StringComparison.OrdinalIgnoreCase) || resp.Result.DisplayName.EndsWith("xls", StringComparison.OrdinalIgnoreCase))
                    {
                        encode = "application/vnd.ms-excel";
                    }
                    else if (resp.Result.DisplayName.EndsWith("bmp", StringComparison.OrdinalIgnoreCase))
                    {
                        encode = "image/x-ms-bmp";
                    }
                    else if (resp.Result.DisplayName.EndsWith("jpeg", StringComparison.OrdinalIgnoreCase) || resp.Result.DisplayName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) || resp.Result.DisplayName.EndsWith("jpe", StringComparison.OrdinalIgnoreCase))
                    {
                        encode = "image/jpeg";
                    }
                    else
                    {
                        encode = "application";
                    }
                    return File(resp.Result.Url, encode, resp.Result.DisplayName.ToUtf8String());
                }
            }

            return new EmptyResult();
        }

        [HttpPost]
        public JsonResult GetAttachments(string gid)
        {
            AttachmentService service = new AttachmentService();
            Response<IEnumerable<Attachment>> resp = service.GetAttachmentsByGroupID(new GetAttachmentsByGroupIDRequest() { GroupID = gid });
            if (resp.IsSuccess)
            {
                return Json(resp.Result);
            }
            else
            {
                return Json(new { msg = "没有对应附件" });
            }
        }

        [HttpPost]
        public JsonResult AjaxDeleteAttachment(long aid)
        {
            AttachmentService service = new AttachmentService();
            Response<Attachment> resp = service.DeleteAttachment(new DeleteAttachmentRequest() { ID = aid });
            if (resp.IsSuccess)
            {
                try
                {
                    MyFile.Delete(resp.Result.Url);
                }
                catch (Exception ex)
                {
                    return Json(new { success = true, msg = "删除文件成功,但没有删除服务器垃圾文件." + ex.Message });
                }

                return Json(new { success = true, msg = "删除文件成功" });
            }
            else
            {
                return Json(new { msg = resp.Exception.Message });
            }
        }

        private IEnumerable<Menu> GetMenu()
        {
            IEnumerable<Menu> menus = ApplicationConfigHelper.GetRoleMenus(base.UserInfo.RoleID).Where(m => m.Scenarios == 1 && m.IsChecked).Select(m => (Menu)m);
            ViewData["Menu"] = menus;
            return menus;
        }

        private IEnumerable<Menu> GetMenus(int superID, Dictionary<int, IGrouping<int, Menu>> menus)
        {
            if (menus.ContainsKey(superID))
            {
                var list = new List<Menu>();
                foreach (var m in menus[superID])
                {
                    var chi = GetMenus((int)m.ID, menus);
                    list.Add(new Menu() { ID = m.ID, SuperID = m.SuperID, Link = m.Link, Name = m.Name, DisplayOrder = m.DisplayOrder, Glyphicon = m.Glyphicon, Children = GetMenus((int)m.ID, menus) });
                }

                return list.OrderBy(m => m.DisplayOrder);
            }

            return null;
        }

        private IEnumerable<Menu> GetAll3RdMenu(int? secondMenuID)
        {
            if (secondMenuID.HasValue)
            {
                return ApplicationConfigHelper.GetRoleMenus(base.UserInfo.RoleID).Where(pm => (pm.SuperID == secondMenuID) && pm.Scenarios == 1 && pm.IsChecked).OrderBy(m => m.DisplayOrder);
            }

            return null;
        }
    }
}