using System;
using System.Web.Mvc;

using BasicFramework.Biz;
using BasicFramework.MessageContracts;
using BasicFramework.Web.Common;
using BasicFramework.Web.Areas.System.Models;
using UtilConstants = BasicFramework.Common.Constants;
using BasicFramework.Entity;
namespace BasicFramework.Web.Areas.System.Controllers
{
    public class RoleController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            RoleIndexViewModel vm = new RoleIndexViewModel();
            vm.Role = new Role() { Name = string.Empty, Description = string.Empty, State = true };
            var Result = new BasicFramework.Biz.RoleService().GetRolesByCondition(new RoleRequestAndResponse() { Role = vm.Role, PageSize = UtilConstants.PAGESIZE, PageIndex = 0 }).Result;
            vm.RoleCollection = Result.RoleCollection;
            vm.PageIndex = Result.PageIndex;
            vm.PageSize = Result.PageSize;
            vm.TotalCount = Result.TotalCount;
            vm.PageCount = Result.PageCount;
            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(RoleIndexViewModel vm, int? PageIndex)
        {
            var Result = new BasicFramework.Biz.RoleService().GetRolesByCondition(new RoleRequestAndResponse() { Role = vm.Role, PageSize = UtilConstants.PAGESIZE, PageIndex = PageIndex ?? 0 }).Result;
            vm.RoleCollection = Result.RoleCollection;
            vm.PageIndex = Result.PageIndex;
            vm.PageSize = Result.PageSize;
            vm.TotalCount = Result.TotalCount;
            vm.PageCount = Result.PageCount;
            return View(vm);
        }

        [HttpGet]
        public ActionResult CreateOrUpdate(long? id)
        {
            Role role;
            if (id.HasValue)
            {
                var response = new RoleService().GetRoleInfo(new GetObjectByIDRequest() { ID = id.Value });
                if (!response.IsSuccess)
                {
                    throw new Exception("获取角色出错");
                }

                role = response.Result;
                ViewBag.Message = "编辑角色";
            }
            else
            {
                role = new Role() { State = true };
                ViewBag.Message = "新增角色";

            }

            RoleIndexViewModel vm = new RoleIndexViewModel() { Role = role };
            return View(vm);
        }


        [HttpPost]
        public ActionResult CreateOrUpdate(Role role)
        {
            if (role.ID == 0)
            {
                role.CreateDate = DateTime.Now;
            }

            var response = new RoleService().AddOrUpdateRoles(new AddOrUpdateRoleRequest()
            {
                RoleCollection = new Role[] { role }
            });

            if (!response.IsSuccess)
            {
                return Json(new { Error = response.Exception.Message });
            }

            if (response.Result == -1)
            {
                return Json(new { Error = "此角色已存在,角色名称不能重复" });
            }
            else if (response.Result == 1)
            {
                ApplicationConfigHelper.RefreshApplicationRoles();
                return Json(new { Message = "成功" });
            }
            else
            {
                return Json(new { Error = "提交失败,请联系IT" });
            }

        }


    }
}