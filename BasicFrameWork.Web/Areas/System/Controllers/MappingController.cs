using System;
using System.Linq;
using System.Web.Mvc;
using BasicFramework.Biz;
using BasicFramework.Entity;
using BasicFramework.Common;
using BasicFramework.MessageContracts;
using BasicFramework.Web.Areas.System.Models;
using BasicFramework.Web.Common;
using UtilConstants = BasicFramework.Common.Constants;
using System.Collections.Generic;

namespace BasicFramework.Web.Areas.System.Controllers
{
    public class MappingController : BaseController
    {
        public ActionResult UserRoleMapping(long? id)
        {
            UserRoleMappingViewModel vm = new UserRoleMappingViewModel();

            if (id.HasValue)
            {
                var user = ApplicationConfigHelper.GetApplicationUsers().FirstOrDefault(u => u.ID == id.Value);

                if (user == null)
                {
                    return Error("传入用户不合法");
                }

                vm.UserID = user.ID;
                vm.UserName = user.Name;
            }

            vm.RoleCollection = ApplicationConfigHelper.GetApplicationRoles().Where(r => r.State.Value);

            return View(vm);
        }

        [HttpPost]
        public JsonResult GetRoleIDByUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return Json("");
            }

            var user = ApplicationConfigHelper.GetApplicationUsers().FirstOrDefault(t => string.Equals(t.Name,userName,StringComparison.OrdinalIgnoreCase));

            if (user == null)
            {
                return Json("");
            }

            var userRole = ApplicationConfigHelper.GetUserRoleMappings().FirstOrDefault(ur => ur.UserID == user.ID);

            if (userRole == null)
            {
                return Json("");
            }

            return Json(userRole.RoleID.ToString(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SetUserRole(string userName, long roleID)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return Json("请输入用户名", JsonRequestBehavior.AllowGet);
            }

            var user = ApplicationConfigHelper.GetApplicationUsers().FirstOrDefault(t => string.Equals(t.Name, userName, StringComparison.OrdinalIgnoreCase));

            if (user == null)
            {
                return Json("系统无此用户", JsonRequestBehavior.AllowGet);
            }

            MappingService service = new MappingService();

            var response = service.AddOrUpdateUserRoleMapping(new AddOrUpdateMappingRequest()
            {
                MapingCollection = new Mapping[] { new Mapping() { SourceID = user.ID, DestID = roleID } }
            });

            if (response.IsSuccess && response.Result == 1)
            {
                ApplicationConfigHelper.RefreshUserRoleMappings();
                return Json("用户角色设置成功", JsonRequestBehavior.AllowGet);
            }
            
            return Json("用户角色设置失败,请联系IT", JsonRequestBehavior.AllowGet); 
        }

        [HttpGet]
        public ActionResult RoleMenuMapping(long? id)
        {
            RoleMenuMappingViewModel vm = new RoleMenuMappingViewModel();

            vm.RoleID = id.GetValueOrDefault(0);

            vm.Roles = ApplicationConfigHelper.GetApplicationRoles().Where(r => r.State.Value).Select(r => new SelectListItem() { Text = r.Name, Value = r.ID.ToString(), Selected = r.ID == vm.RoleID });

            var allMenus = (IEnumerable<CheckedMenu>)ApplicationConfigHelper.GetRoleMenus(0);

            IList<CheckedMenu> returnMenus = new List<CheckedMenu>();

            allMenus.Each((i, menu) => {
                var innerMenu = new CheckedMenu(menu);
                returnMenus.Add(innerMenu);
            });

            if(vm.RoleID != 0)
            {
                var roleMens = ApplicationConfigHelper.GetRoleMenus(vm.RoleID);
                if(roleMens != null && roleMens.Any())
                {
                    returnMenus.Each((i, menu) =>
                    {
                        if(roleMens.Any(m => m.ID == menu.ID))
                        {
                            menu.IsChecked = true;
                        }
                    });
                    
                }
            }

            vm.MenusForJsonString = returnMenus.Select(cm => { var treeItem = new TreeItem(cm); treeItem.open = true; return treeItem; }).ToJsonString();
          
            return View(vm);
        }

        [HttpPost]
        public string GetRoleMenuJsonString(long id)
        {
            var allMenus = (IEnumerable<CheckedMenu>)ApplicationConfigHelper.GetRoleMenus(0);

            IList<CheckedMenu> returnMenus = new List<CheckedMenu>();

            allMenus.Each((i, menu) =>
            {
                var innerMenu = new CheckedMenu(menu);
                returnMenus.Add(innerMenu);
            });

            if (id != 0)
            {
                var roleMens = ApplicationConfigHelper.GetRoleMenus(id);
                if (roleMens != null && roleMens.Any())
                {
                    returnMenus.Each((i, menu) =>
                    {
                        if (roleMens.Any(m => m.ID == menu.ID))
                        {
                            menu.IsChecked = true;
                        }
                    });

                }
            }

            return returnMenus.Select(cm => { var treeItem = new TreeItem(cm); treeItem.open = true; return treeItem; }).ToJsonString();
        }

        [HttpPost]
        public ActionResult SetRoleMenu(long roleID, IEnumerable<int> MenuItems)
        {
            if (roleID == 0)
            {
                return Error("角色不能为空");
            }

            IList<Mapping> mappingCollection = new List<Mapping>();

            if (MenuItems == null || !MenuItems.Any())
            {
                mappingCollection.Add(new Mapping() { SourceID = roleID, DestID = 0 });
            }
            else
            {
                MenuItems.Each((i, m) => mappingCollection.Add(new Mapping() { SourceID = roleID, DestID = m }));
            }

            MappingService service = new MappingService();
            var response = service.AddRoleMenuMapping(new AddOrUpdateMappingRequest()
            {
                
                MapingCollection = mappingCollection
            });

            if (response.IsSuccess && response.Result == 1)
            {
                ApplicationConfigHelper.RefreshRoleMenuMappings();
                return Json("角色菜单设置成功", JsonRequestBehavior.AllowGet);
            }

            return Json("角色菜单设置失败,请联系IT", JsonRequestBehavior.AllowGet); 
        }
    }
}
