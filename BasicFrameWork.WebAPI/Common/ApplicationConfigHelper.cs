using System;
using System.Collections.Generic;
using System.Linq;
using BasicFramework.Biz;
using BasicFramework.Common;
using BasicFramework.Entity;
using BasicFramework.MessageContracts;

namespace BasicFramework.WebAPI.Common
{
    public class ApplicationConfigHelper
    {
        private static object lockobject = new object();

        public static Projects GetApplicationConfig()
        {
            return (Projects)CacheHelper.Get("WebAPIProjects", () =>
            {
                XmlSerializerHelper<Projects> helper = new XmlSerializerHelper<Projects>();
                helper.Load(Constants.APPLICATIONCONFIGPATH);
                Projects projects = helper.Value;

                if (projects == null)
                {
                    throw new Exception("不能加载系统配置文件,请联系IT");
                }
                lock (lockobject)
                {
                    CacheHelper.Insert("WebAPIProjects", projects, new System.Web.Caching.CacheDependency(Constants.APPLICATIONCONFIGPATH));
                }
            });
        }

        public static IEnumerable<Config> GetSystemConfigs(long projectID, string identifyType)
        {
            var SystemConfigs = (IEnumerable<Config>)CacheHelper.Get("WebAPIConfigs", () =>
            {
                ConfigService service = new ConfigService();
                var configs = service.GetConfigs().Result;

                if (configs == null || !configs.Any())
                {
                    throw new Exception("请联系IT配置系统");
                }

                lock (lockobject)
                {
                    CacheHelper.Insert("WebAPIConfigs", configs);
                }
            });

            var returnConfig = SystemConfigs.Where(c => c.ProjectID == projectID && string.Equals(c.IdentifyType, identifyType, StringComparison.OrdinalIgnoreCase));

            if (returnConfig == null || !returnConfig.Any())
            {
                returnConfig = SystemConfigs.Where(c => string.Equals(c.IdentifyType, identifyType, StringComparison.OrdinalIgnoreCase) && c.AsDefault);
            }

            return returnConfig;
        }

        public static IEnumerable<Config> GetApplicationConfigs(string identifyType)
        {
            var ApplicationConfigs = (IEnumerable<Config>)CacheHelper.Get("WebAPIApplicationConfigs", () =>
            {
                ConfigService service = new ConfigService();
                var configs = service.GetApplicationConfigs().Result;

                if (configs == null || !configs.Any())
                {
                    throw new Exception("请联系IT配置系统");
                }

                lock (lockobject)
                {
                    CacheHelper.Insert("WebAPIApplicationConfigs", configs);
                }
            });

            return ApplicationConfigs.Where(c => string.Equals(c.IdentifyType, identifyType, StringComparison.OrdinalIgnoreCase));
        }

        public static IEnumerable<Region> GetRegions()
        {
            var regions = (IEnumerable<Region>)CacheHelper.Get("WebAPIRegions", () =>
            {
                ConfigService service = new ConfigService();
                var rg = service.GetRegions().Result;

                if (rg == null || !rg.Any())
                {
                    throw new Exception("请联系IT配置系统");
                }

                lock (lockobject)
                {
                    CacheHelper.Insert("WebAPIRegions", rg);
                }
            });

            return regions;
        }

    }
}