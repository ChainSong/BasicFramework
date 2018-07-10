using System.Configuration;

namespace BasicFramework.Common
{
    public class ConfigHelper
    {
        public static string GetConfigValue(string key)
        {
            return string.IsNullOrEmpty(key) ? string.Empty : ConfigurationManager.AppSettings[key];
        }

        public static int? GetConfigValueToInt(string key, int? defaultValue = null)
        {
            var value = GetConfigValue(key);

            if (!string.IsNullOrEmpty(value))
            {
                int x;
                if (int.TryParse(value, out x))
                {
                    return x;
                }
            }

            return defaultValue.HasValue ? defaultValue : null;
        }

        public static string GetConnectionString(string key)
        {
            return string.IsNullOrEmpty(key) ? string.Empty : ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }
    }
}