using System;

namespace BasicFramework.Common
{
    public class Constants
    {
        public static readonly string Excel03ConString = ConfigHelper.GetConnectionString("Excel03ConString");
        public static readonly string Excel07ConString = ConfigHelper.GetConnectionString("Excel07ConString");
        public static readonly Lazy<int> PageSize = new Lazy<int>(() => ConfigHelper.GetConfigValueToInt("PageSize", 20).Value);

        public static readonly int PAGESIZE = ConfigHelper.GetConfigValue("PageSize").ObjectToInt32();
        public static readonly string TEMPFOLDER = "TEMP";
        public static readonly string UPLOAD_FOLDER_PATH = ConfigHelper.GetConfigValue("UploadFolderPath");
        public static readonly string DownLoadFiles = ConfigHelper.GetConfigValue("DownLoadFiles");
        public static readonly string DownLoadFilesTEMP = ConfigHelper.GetConfigValue("DownLoadFilesTEMP");
        public static readonly string UPLOAD_AMS_PATH = ConfigHelper.GetConfigValue("UploadAMSPath");
        public static readonly string Audit_ReplyDocument_FOLDER_PATH = ConfigHelper.GetConfigValue("AuditReplyDocumentFolderPath");
        public static readonly string Audit_ReplyDocument_Picture_Url_Pre = ConfigHelper.GetConfigValue("AuditReplyDocumentPictureUrlPre");
    }
}