using System;
using System.Linq;
using System.Web.Mvc;
using BasicFramework.Biz;
using BasicFramework.Entity;
using BasicFramework.MessageContracts;
using BasicFramework.Web.Areas.System.Models;
using BasicFramework.Web.Common;
using UtilConstants = BasicFramework.Common.Constants;

namespace BasicFramework.Web.Areas.System.Controllers
{
    public class UserController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            UserIndexViewModel vm = new UserIndexViewModel();
            vm.User = new User() { State = true };
            var result = new UserService().GetUsersByCondition(new UserRequestAndResponse() { User = vm.User, PageSize = UtilConstants.PAGESIZE, PageIndex = 0 }).Result;
            vm.UserCollection = result.UserCollection;
            vm.PageIndex = result.PageIndex;
            vm.PageSize = result.PageSize;
            vm.TotalCount = result.TotalCount;
            vm.PageCount = result.PageCount;
            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(UserIndexViewModel vm, int? PageIndex)
        {
            var result = new UserService().GetUsersByCondition(new UserRequestAndResponse() { User = vm.User, PageSize = UtilConstants.PAGESIZE, PageIndex = PageIndex ?? 0 }).Result;
            vm.UserCollection = result.UserCollection;
            vm.PageIndex = result.PageIndex;
            vm.PageSize = result.PageSize;
            vm.TotalCount = result.TotalCount;
            vm.PageCount = result.PageCount;
            return View(vm);
        }

        [HttpGet]
        public ActionResult CreateOrUpdate(long? id)
        {
            User user;
            if (id.HasValue)
            {
                var response = new UserService().GetUserInfo(new GetObjectByIDRequest() { ID = id.Value });
                if (!response.IsSuccess)
                {
                    throw new Exception("获取用户出错");
                }

                user = response.Result;
                ViewBag.Message = "编辑用户";
            }
            else
            {
                user = new User() { State = true, Sex = '男' };
                ViewBag.Message = "新增用户";
            }

            UserIndexViewModel vm = new UserIndexViewModel() { User = user, OriginalPassword = user.Password };

            return View(vm);
        }


        [HttpPost]
        public ActionResult CreateOrUpdate(User user, string OriginalPassword)
        {
            if (user.ID == 0)
            {
                user.CreateDate = DateTime.Now;
            }
            else
            {
                if (string.IsNullOrEmpty(user.Password))
                {
                    user.Password = OriginalPassword;
                }
            }
            
            var response = new UserService().AddOrUpdateUsers(new AddOrUpdateUserRequest()
            {
                UserCollection = new User[] { user }
            });

            if (!response.IsSuccess)
            {
                return Json(new { Error = response.Exception.Message });
            }

            if (response.Result == -1)
            {
                return Json(new { Error = "此用户已存在,登陆名称不能重复" });
            }
            else if (response.Result == 1)
            {
                ApplicationConfigHelper.RefreshApplicationUsers();
                return Json(new { Message = "成功" });
            }
            else
            {
                return Json(new { Error = "提交失败,请联系IT" });
            }

        }

        [HttpGet]
        public ActionResult GetApplicationUsersByUserName(string userName)
        {
            return Json(ApplicationConfigHelper.GetApplicationUsers().Where(u => u.State.Value && u.Name.IndexOf(userName, StringComparison.OrdinalIgnoreCase) >= 0).Select(t => new { Value = t.ID.ToString(), Text = t.Name }), JsonRequestBehavior.AllowGet);
        }
    }
}