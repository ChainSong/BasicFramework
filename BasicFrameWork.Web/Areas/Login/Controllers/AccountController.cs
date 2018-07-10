using System.Linq;
using System.Web.Mvc;
using BasicFramework.Biz;
using BasicFramework.Entity;
using BasicFramework.MessageContracts;
using BasicFramework.Web.Areas.Login.Models;
using BasicFramework.Web.Common;

namespace BasicFramework.Web.Areas.Login.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                LoginService us = new LoginService();
                //BasicFramework.Common.AES.Encrypt(model.Password)
                User user = us.CheckLogin(new GetUserByCheckLoginRequest() { Name = model.UserName, Password = model.Password }).Result;
                if (user != null)
                {
                    Session[Constants.USER_INFO_KEY] = user;
                    Session["Name"] = user.Name;
                    Session["ID"] = user.ID;
                    Session["DisplayName"] = user.DisplayName;
                    Session["RoleID"] = user.RoleID;
                    Session["UserType"] = user.UserType;
                    if (string.IsNullOrEmpty(returnUrl))
                    {
                        return RedirectToAction("", "../");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "登录信息有误，请重试.");
                }
            }

            return View(model);
        }
    }
}