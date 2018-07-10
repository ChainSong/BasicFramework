using System.Collections.Generic;
using BasicFramework.Common;
using BasicFramework.Entity;


namespace BasicFramework.Dao
{
    public class ConfigAccessor : BaseAccessor
    {
        public IEnumerable<ApplicationConfig> GetApplicationConfigs()
        {
            return this.ExecuteDataTable("Proc_GetApplicationConfig").ConvertToEntityCollection<ApplicationConfig>();
        }

        public IEnumerable<Config> GetConfigs()
        {
            return this.ExecuteDataTable("Proc_GetConfig").ConvertToEntityCollection<Config>();
        }

        public IEnumerable<Region> GetRegions()
        {
            return this.ExecuteDataTable("Proc_GetRegions").ConvertToEntityCollection<Region>();
        }

      
    }
}