using System;
using System.Linq;
using System.Web.Mvc;
using BasicFramework.Biz.System;
using BasicFramework.Entity;
using BasicFramework.MessageContracts;

namespace BasicFramework.Web.Common
{
    public class BaseController : Controller
    {
        public ActionResult Error(string msg)
        {
            return View("Error", (object)msg);
        }

        protected virtual bool AutoLoadPageStyleAndScriptFiles
        {
            get { return true; }
        }

        protected void SetReadonlyFlag(bool isReadonly = true)
        {
            ViewBag.___IsReadonly___ = isReadonly;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (UserInfo == null)
            {
                filterContext.Result = new RedirectResult("/Login");
            }
            else
            {
                base.OnActionExecuting(filterContext);
            }

            if (!AutoLoadPageStyleAndScriptFiles)
            {
                ViewBag.PageCssFile = false;
                ViewBag.PageJsFile = false;
            }

            if (UserInfo != null && filterContext.RequestContext.HttpContext.Request.HttpMethod.Equals("GET", StringComparison.OrdinalIgnoreCase))
            {
                string controllerName = filterContext.RequestContext.RouteData.Values["controller"].ToString();

                if (controllerName.Equals("Home", StringComparison.OrdinalIgnoreCase))
                {
                    ViewBag.CanAdd = "true";
                    ViewBag.CanEdit = "true";
                    ViewBag.CanDelete = "true";
                    ViewBag.CanExport = "true";
                }
                else
                {
                    var menuID = filterContext.RequestContext.HttpContext.Request["MenuID"];

                    if (string.IsNullOrEmpty(menuID))
                    {
                        ViewBag.CanAdd = "false";
                        ViewBag.CanEdit = "false";
                        ViewBag.CanDelete = "false";
                        ViewBag.CanExport = "false";
                    }
                    else
                    {

                        RoleMenu roleMenu = null;

                        roleMenu = ApplicationConfigHelper.GetRoleMenus(this.UserInfo.RoleID).FirstOrDefault(rm => rm.ID.ToString() == menuID);

                        if (roleMenu == null)
                        {
                            ViewBag.CanAdd = "false";
                            ViewBag.CanEdit = "false";
                            ViewBag.CanDelete = "false";
                            ViewBag.CanExport = "false";
                        }
                        else
                        {
                            //权限控制
                            ViewBag.CanAdd = roleMenu.CanAdd.ToString().ToLower();
                            ViewBag.CanEdit = roleMenu.CanEdit.ToString().ToLower();
                            ViewBag.CanDelete = roleMenu.CanDelete.ToString().ToLower();
                            ViewBag.CanExport = roleMenu.CanExport.ToString().ToLower();
                        }
                    }
                }
            }

        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            if (string.Equals("POST", filterContext.HttpContext.Request.RequestType, StringComparison.OrdinalIgnoreCase))
            {
                new LogService().Log(new LogRequest() { LogHistory = new LogHistory() { Name = UserInfo.Name, Time = DateTime.Now, Action = filterContext.RouteData.Values["action"].ToString() } });
            }
        }

        public User UserInfo
        {
            get
            {
                return Session[Constants.USER_INFO_KEY] as User;
            }
        }
    }
}