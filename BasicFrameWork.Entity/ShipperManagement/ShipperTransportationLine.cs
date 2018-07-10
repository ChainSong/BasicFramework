using System;
using BasicFramework.Common;

namespace BasicFramework.Entity
{
    public class ShipperTransportationLine
    {
        [EntityPropertyExtension("ID", "ID")]
        public long ID { get; set; }

        [EntityPropertyExtension("CRMShipperID", "CRMShipperID")]
        public long CRMShipperID { get; set; }

        [EntityPropertyExtension("StartCityID", "StartCityID")]
        public long StartCityID { get; set; }

        [EntityPropertyExtension("StartCityName", "StartCityName")]
        public string StartCityName { get; set; }

        [EntityPropertyExtension("EndCityID", "EndCityID")]
        public long EndCityID { get; set; }

        [EntityPropertyExtension("EndCityName", "EndCityName")]
        public string EndCityName { get; set; }

        [EntityPropertyExtension("CoverRegionID", "CoverRegionID")]
        public long CoverRegionID { get; set; }

        [EntityPropertyExtension("CoverRegionName", "CoverRegionName")]
        public string CoverRegionName { get; set; }

        [EntityPropertyExtension("Period", "Period")]
        public int? Period { get; set; }

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

        [EntityPropertyExtension("Bigint1", "Bigint1")]
        public long? Bigint1 { get; set; }

        [EntityPropertyExtension("Int1", "Int1")]
        public int? Int1 { get; set; }

        [EntityPropertyExtension("Bit1", "Bit1")]
        public bool? Bit1 { get; set; }
    }
}