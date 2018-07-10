using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicFramework.Common;

namespace BasicFramework.Entity
{
    public class ShipperCooperation
    {
        [EntityPropertyExtension("ID", "ID")]
        public long ID { get; set; }

        [EntityPropertyExtension("CRMShipperID", "CRMShipperID")]
        public long CRMShipperID { get; set; }

        [EntityPropertyExtension("Name", "Name")]
        public string Name { get; set; }

        [EntityPropertyExtension("Remark", "Remark")]
        public string Remark { get; set; }

        [EntityPropertyExtension("AttachmentGroupID", "AttachmentGroupID")]
        public string AttachmentGroupID { get; set; }

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

        [EntityPropertyExtension("Str6", "Str6")]
        public string Str6 { get; set; }

        [EntityPropertyExtension("Str7", "Str7")]
        public string Str7 { get; set; }

        [EntityPropertyExtension("Str8", "Str8")]
        public string Str8 { get; set; }

        [EntityPropertyExtension("Str9", "Str9")]
        public string Str9 { get; set; }

        [EntityPropertyExtension("Str10", "Str10")]
        public string Str10 { get; set; }

        [EntityPropertyExtension("DateTime1", "DateTime1")]
        public DateTime? DateTime1 { get; set; }

        [EntityPropertyExtension("DateTime2", "DateTime2")]
        public DateTime? DateTime2 { get; set; }

        [EntityPropertyExtension("Bigint1", "Bigint1")]
        public long? Bigint1 { get; set; }

        [EntityPropertyExtension("Int1", "Int1")]
        public int? Int1 { get; set; }

        [EntityPropertyExtension("Bit1", "Bit1")]
        public bool? Bit1 { get; set; }
    }
}
