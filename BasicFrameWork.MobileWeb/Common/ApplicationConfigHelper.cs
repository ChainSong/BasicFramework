using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BasicFramework.Biz;
using BasicFramework.Common;
using BasicFramework.Entity;

namespace BasicFramework.MobileWeb.Common
{
    public class ApplicationConfigHelper
    {
        private static object lockobject = new object();

        public static IEnumerable<RoleMenu> GetApplicationRoleMenus()
        {
            var roleMenuMappings = (IEnumerable<RoleMenu>)CacheHelper.Get("ApplicationRoleMenus", () =>
            {
                var checkedMenus = new MappingService().GetAllRoleMenus().Result;

                if (checkedMenus == null)
                {
                    checkedMenus = Enumerable.Empty<RoleMenu>();
                }

                lock (lockobject)
                {
                    CacheHelper.Insert("ApplicationRoleMenus", checkedMenus);
                }
            });

            return roleMenuMappings;
        }

        public static IEnumerable<CheckedMenu> GetRoleMenus(long RoleID)
        {
            return GetApplicationRoleMenus().Where(m => m.RoleID == RoleID).Select(m => (CheckedMenu)m);
        }

        public static void RefreshRoleMenuMappings()
        {
            var checkedMenus = new MappingService().GetAllRoleMenus().Result;

            if (checkedMenus == null)
            {
                checkedMenus = Enumerable.Empty<RoleMenu>();
            }

            lock (lockobject)
            {
                CacheHelper.Remove("ApplicationRoleMenus");
                CacheHelper.Insert("ApplicationRoleMenus", checkedMenus);
            }
        }
    }
}