﻿using System.Web;

namespace BasicFramework.Web.Common
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

        public static readonly string APPLICATIONCONFIGPATH = HttpContext.Current.Server.MapPath("~/App_Data/ApplicationConfig.xml");

    }
}