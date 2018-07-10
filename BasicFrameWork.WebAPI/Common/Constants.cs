using System;
using System.Web;

namespace BasicFramework.WebAPI.Common
{
    public class Constants
    {
        public const string PASSWORD = "123456";
        public const string PODSTATE = "PodState";
        public const string PODTYPE = "PODType";
        public const string SHIPPERTYPE = "ShipperType";
        public const string SHIPPERIDENTIFY = "ShipperIdentify";
        public const string TTLORTPL = "TtlOrTpl";
        public const string USER_INFO_KEY = "UserInfo";
        public const string INVOICETYPE = "InvoiceType";

        public static string MapPath(string strPath)
        {
           
                strPath = strPath.Replace("/", "\\");
                if (strPath.StartsWith("\\"))
                {
                    strPath = strPath.TrimStart('\\');
                }
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            
        }

        public static readonly string APPLICATIONCONFIGPATH = MapPath("App_Data/ApplicationConfig.xml");
            //@"E:\pear项目\TWS\Runbow.TWS\BasicFramework.WebAPI\App_Data\ApplicationConfig.xml";

    }
}