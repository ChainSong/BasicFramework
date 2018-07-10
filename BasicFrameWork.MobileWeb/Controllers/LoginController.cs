using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using BasicFramework.Biz;
using BasicFramework.MobileWeb.Common;
using BasicFramework.Common;
using BasicFramework.Entity;
using BasicFramework.MessageContracts;

namespace BasicFramework.MobileWeb.Controllers
{
    public class LoginController :AsyncController
    {
        //
        // GET: /Login/

        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult CheckLogin(string name, string pwd, int pid)
        {
            var temp = new { flag = -1, pid = "", msg = "账号或密码错误！" };
            if (string.IsNullOrEmpty(name))
            {
                temp = new { flag = 0, pid = "", msg = "请输入账户！" };
            }
            else if (string.IsNullOrEmpty(pwd))
            {
                temp = new { flag = 0, pid = "", msg = "请输入密码！" };
            }
            else if (string.IsNullOrEmpty(pid.ToString()))
            {
                temp = new { flag = 0, pid = "", msg = "该账户没有分配项目！" };
            }
            else
            {
                LoginService us = new LoginService();
                var user = us.CheckLogin(new GetUserByCheckLoginRequest() { Name = name, Password = pwd }).Result;
                if (user != null)
                {
                    if (user != null)
                    {
                        Session[BasicFramework.MobileWeb.Common.Constants.USER_INFO_KEY] = user;
                        Session["Name"] = user.Name;
                        Session["ID"] = user.ID;
                        Session["DisplayName"] = user.DisplayName;
                        Session["RoleID"] = user.RoleID;
                        Session["UserType"] = user.UserType;
                    }
                    else
                    {
                        ModelState.AddModelError("", "登录信息有误，请重试.");
                    }
                    Session["UserInfo"] = user;
                    temp = new { flag = 1, pid = "", msg = "" };
                }
            }
            return Json(temp);
        }
    }
}
