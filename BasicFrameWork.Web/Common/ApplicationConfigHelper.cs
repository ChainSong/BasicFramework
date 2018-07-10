using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BasicFramework.Biz;
using BasicFramework.Biz.ShipperManagement;
using BasicFramework.Common;
using BasicFramework.Dao;
using BasicFramework.Entity;
using BasicFramework.Entity.ShipperManagement.DriverManagement;
using BasicFramework.Entity.ShipperManagement.VehicleManagement;
using BasicFramework.MessageContracts;
using BasicFramework.MessageContracts.ShipperManagement.VehicleManagement;

namespace BasicFramework.Web.Common
{
    public class ApplicationConfigHelper
    {
        private static object lockobject = new object();

        public static IEnumerable<ApplicationConfig> GetApplicationConfig()
        {
            var result =  (IEnumerable<ApplicationConfig>)CacheHelper.Get("ApplicationConfig", () =>
            {
                ConfigService service = new ConfigService();
                var applicationConfigs = service.GetApplicationConfigs().Result;

                if (applicationConfigs == null || !applicationConfigs.Any())
                {
                    throw new Exception("请联系IT配置系统");
                }

                lock (lockobject)
                {
                    CacheHelper.Insert("ApplicationConfig", applicationConfigs);
                }
            });

            return result;
        }

        public static string GetTargetApplicationConfigName(string identifityType, string code)
        {
            var items = GetApplicationConfig().Where(t => string.Equals(t.IdentifyType, identifityType, StringComparison.OrdinalIgnoreCase));

            if (items == null || !items.Any())
            {
                return string.Empty;
            }

            var item = items.FirstOrDefault(t => string.Equals(t.Code, code, StringComparison.OrdinalIgnoreCase));

            if (item == null)
            {
                return string.Empty;
            }

            return item.Name;

        }

        public static IEnumerable<SelectListItem> GetTargetApplicationConfig(string IdentifyType)
        {
            var items = GetApplicationConfig().Where(t => string.Equals(t.IdentifyType, IdentifyType, StringComparison.OrdinalIgnoreCase));

            if (items != null && items.Any())
            {
                return items.Select(t => new SelectListItem(){
                    Value = t.Code,
                    Text = t.Name
                });
            }

            return Enumerable.Empty<SelectListItem>();
        }

        public static IEnumerable<Config> GetApplicationConfigs(string identifyType)
        {
            var ApplicationConfigs = (IEnumerable<Config>)CacheHelper.Get("ApplicationConfigs", () =>
            {
                ConfigService service = new ConfigService();
                var configs = service.GetApplicationConfigs().Result;

                if (configs == null || !configs.Any())
                {
                    throw new Exception("请联系IT配置系统");
                }

                lock (lockobject)
                {
                    CacheHelper.Insert("ApplicationConfigs", configs);
                }
            });

            return ApplicationConfigs.Where(c => string.Equals(c.IdentifyType, identifyType, StringComparison.OrdinalIgnoreCase));
        }

        public static IEnumerable<Config> GetSystemConfigs(long projectID, string identifyType)
        {
            var SystemConfigs = (IEnumerable<Config>)CacheHelper.Get("Configs", () =>
            {
                ConfigService service = new ConfigService();
                var configs = service.GetConfigs().Result;

                if (configs == null || !configs.Any())
                {
                    throw new Exception("请联系IT配置系统");
                }

                lock (lockobject)
                {
                    CacheHelper.Insert("Configs", configs);
                }
            });

            var returnConfig = SystemConfigs.Where(c => c.ProjectID == projectID && string.Equals(c.IdentifyType, identifyType, StringComparison.OrdinalIgnoreCase));

            if (returnConfig == null || !returnConfig.Any())
            {
                returnConfig = SystemConfigs.Where(c => string.Equals(c.IdentifyType, identifyType, StringComparison.OrdinalIgnoreCase) && c.AsDefault);
            }

            return returnConfig;
        }

        public static IEnumerable<Region> GetChildRegion(long supperID)
        {
            var regions = (IEnumerable<Region>)CacheHelper.Get("Regions", () =>
            {
                ConfigService service = new ConfigService();
                var rg = service.GetRegions().Result;

                if (rg == null || !rg.Any())
                {
                    throw new Exception("请联系IT配置系统");
                }

                lock (lockobject)
                {
                    CacheHelper.Insert("Regions", rg);
                }
            });

            return regions.Where(r => r.SupperID == supperID);
        }

        public static IEnumerable<Region> GetRegions()
        {
            var regions = (IEnumerable<Region>)CacheHelper.Get("Regions", () =>
            {
                ConfigService service = new ConfigService();
                var rg = service.GetRegions().Result;

                if (rg == null || !rg.Any())
                {
                    throw new Exception("请联系IT配置系统");
                }

                lock (lockobject)
                {
                    CacheHelper.Insert("Regions", rg);
                }
            });

            return regions;
        }

        public static void RefreshRegions()
        {
            ConfigService service = new ConfigService();
            var rg = service.GetRegions().Result;
            lock (lockobject)
            {
                CacheHelper.Remove("Regions");
                CacheHelper.Insert("Regions", rg);
            }
        }

        public static IEnumerable<User> GetApplicationUsers()
        {
            var appUsers = (IEnumerable<User>)CacheHelper.Get("ApplicationUsers", () =>
            {
                UserService service = new UserService();
                
                var users = service.GetUsersByCondition(new UserRequestAndResponse() { User = new User(), PageIndex = 0, PageSize = 10000 }).Result.UserCollection;

                if (users == null || !users.Any())
                {
                    throw new Exception("请联系IT配置系统用户");
                }
                lock (lockobject)
                {
                    CacheHelper.Insert("ApplicationUsers", users);
                }
            });

            return appUsers;
        }

        public static void RefreshApplicationUsers()
        {
            UserService service = new UserService();
            var users = service.GetUsersByCondition(new UserRequestAndResponse() { User = new User(), PageIndex = 0, PageSize = 10000 }).Result.UserCollection;
            
            lock (lockobject)
            {
                CacheHelper.Remove("ApplicationUsers");
                CacheHelper.Insert("ApplicationUsers", users);
            }
        }

        public static IEnumerable<Menu> GetApplicationMenus()
        {
            var appMenus = (IEnumerable<Menu>)CacheHelper.Get("ApplicationMenus", () =>
            {
                MenuService service = new MenuService();

                var menus = service.GetApplicationMenus().Result;

                if (menus == null || !menus.Any())
                {
                    throw new Exception("请联系IT配置系统菜单");
                }
                lock (lockobject)
                {
                    CacheHelper.Insert("ApplicationMenus", menus);
                }
            });

            return appMenus;
        }

        public static IEnumerable<Role> GetApplicationRoles()
        {
            var appRoles = (IEnumerable<Role>)CacheHelper.Get("ApplicationRoles", () =>
            {
                RoleService service = new RoleService();

                var roles = service.GetRolesByCondition(new RoleRequestAndResponse() { Role = new Role(), PageIndex = 0, PageSize = 10000 }).Result.RoleCollection;

                if (roles == null || !roles.Any())
                {
                    throw new Exception("请联系IT配置系统角色");
                }
                lock (lockobject)
                {
                    CacheHelper.Insert("ApplicationRoles", roles);
                }
            });

            return appRoles;
        }

        public static void RefreshApplicationRoles()
        {
            RoleService service = new RoleService();
            var roles = service.GetRolesByCondition(new RoleRequestAndResponse() { Role = new Role(), PageIndex = 0, PageSize = 10000 }).Result.RoleCollection;

            lock (lockobject)
            {
                CacheHelper.Remove("ApplicationRoles");
                CacheHelper.Insert("ApplicationRoles", roles);
            }
        }

        public static IEnumerable<UserRoleMapping> GetUserRoleMappings()
        {
            var userRoleMappings = (IEnumerable<UserRoleMapping>)CacheHelper.Get("UserRoleMapping", () =>
            {
                MappingService service = new MappingService();

                var mappings = service.GetUserRoleMapping().Result;

                if (mappings == null)
                {
                    mappings =  Enumerable.Empty<UserRoleMapping>();
                }

                lock (lockobject)
                {
                    CacheHelper.Insert("UserRoleMapping", mappings);
                }
            });

            return userRoleMappings;
        }

        public static void RefreshUserRoleMappings()
        {
            MappingService service = new MappingService();
            var mappings = service.GetUserRoleMapping().Result;

            if (mappings == null)
            {
                mappings = Enumerable.Empty<UserRoleMapping>();
            }

            lock (lockobject)
            {
                CacheHelper.Remove("UserRoleMapping");
                CacheHelper.Insert("UserRoleMapping", mappings);
            }
        }

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

        public static IEnumerable<RoleMenu> GetRoleMenus(long RoleID)
        {
            return GetApplicationRoleMenus().Where(m => m.RoleID == RoleID);
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

        /// <summary>
        /// 通过ID查询到承运商
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Shipper> GetShipperList()
        {

            var list = (IEnumerable<Shipper>)CacheHelper.Get("ShipperList", () =>
            {
                ShipperManagementService service = new ShipperManagementService();
                var ShipperList = service.GetShipperList().Result;

                if (ShipperList == null || !ShipperList.Any())
                {
                    new List<Shipper>();  //为空
                }
                lock (lockobject)
                {
                    CacheHelper.Insert("ShipperList", ShipperList);
                }
            });

            return list;
        }

        /// <summary>
        /// 查询已选择车辆下拉列表数据
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Vehicle> GetVehicleList()
        {
            var list = (IEnumerable<Vehicle>)CacheHelper.Get("VehicleList", () =>
            {
                VehicleService service = new VehicleService();
                var vehicles = service.GetVehicleList().Result;

                if (vehicles == null || !vehicles.Any())
                {
                    new List<Vehicle>();  //为空
                }
                lock (lockobject)
                {
                    CacheHelper.Insert("VehicleList", vehicles);
                }
            });

            return list;
        }

        /// <summary>
        /// 所有的司机
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Driver> GetDriverList()
        {

            var list = (IEnumerable<Driver>)CacheHelper.Get("DriverList", () =>
            {
                DriverService service = new DriverService();
                var DriverList = service.GetDriverList().Result;

                if (DriverList == null || !DriverList.Any())
                {
                    new List<Driver>();  //为空
                }
                lock (lockobject)
                {
                    CacheHelper.Insert("DriverList", DriverList);
                }
            });

            return list;
        }
    }
}