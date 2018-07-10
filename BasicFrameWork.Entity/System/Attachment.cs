using System;
using BasicFramework.Common;

namespace BasicFramework.Entity
{
    public class Attachment
    {
        [EntityPropertyExtension("ID", "ID")]
        public long ID { get; set; }

        [EntityPropertyExtension("GroupID", "GroupID")]
        public string GroupID { get; set; }

        [EntityPropertyExtension("Url", "Url")]
        public string Url { get; set; }

        [EntityPropertyExtension("ActualNameInServer", "ActualNameInServer")]
        public string ActualNameInServer { get; set; }

        [EntityPropertyExtension("DisplayName", "DisplayName")]
        public string DisplayName { get; set; }

        [EntityPropertyExtension("Extension", "Extension")]
        public string Extension { get; set; }

        [EntityPropertyExtension("CreateDate", "CreateDate")]
        public DateTime CreateDate { get; set; }

        [EntityPropertyExtension("CreateUserID", "CreateUserID")]
        public long CreateUserID { get; set; }

        [EntityPropertyExtension("Creator", "Creator")]
        public string Creator { get; set; }

        [EntityPropertyExtension("IsAudit", "IsAudit")]
        public bool? IsAudit { get; set; }

        [EntityPropertyExtension("IsAudit", "IsAudit")]
        public string Remark { get; set; }

        [EntityPropertyExtension("Str1", "Str1")]
        public string Str1 { get; set; }

        [EntityPropertyExtension("Str2", "Str2")]
        public string Str2 { get; set; }

        [EntityPropertyExtension("Str3", "Str3")]
        public string Str3 { get; set; }

        [EntityPropertyExtension("Str4", "Str4")]
        public string Str4 { get; set; }

        [EntityPropertyExtension("Str5", "Str5")]
        public string Str5 { get; set; }

        [EntityPropertyExtension("DateTime1", "DateTime1")]
        public DateTime? DateTime1 { get; set; }

        [EntityPropertyExtension("DateTime2", "DateTime2")]
        public DateTime? DateTime2 { get; set; }

        [EntityPropertyExtension("Bit1", "Bit1")]
        public bool? Bit1 { get; set; }

        [EntityPropertyExtension("Bigint1", "Bigint1")]
        public long? Bigint1 { get; set; }

        [EntityPropertyExtension("Int1", "Int1")]
        public int? Int1 { get; set; }
    }
}