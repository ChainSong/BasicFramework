using System;
using BasicFramework.Common;

namespace BasicFramework.Entity
{
    public class ShipperTerminalInfo
    {
        [EntityPropertyExtension("ID", "ID")]
        public long ID { get; set; }

        [EntityPropertyExtension("CRMShipperID", "CRMShipperID")]
        public long CRMShipperID { get; set; }

        [EntityPropertyExtension("TerminalAddress", "TerminalAddress")]
        public string TerminalAddress { get; set; }

        [EntityPropertyExtension("IsOwn", "IsOwn")]
        public string IsOwn { get; set; }

        [EntityPropertyExtension("TerminalOfficeArea", "TerminalOfficeArea")]
        public string TerminalOfficeArea { get; set; }

        [EntityPropertyExtension("TerminalWareHouseArea", "TerminalWareHouseArea")]
        public string TerminalWareHouseArea { get; set; }

        [EntityPropertyExtension("TerminalWareHouseAreaRange", "TerminalWareHouseAreaRange")]
        public string TerminalWareHouseAreaRange { get; set; }

        [EntityPropertyExtension("TerminalNumberOfEmployees", "TerminalNumberOfEmployees")]
        public string TerminalNumberOfEmployees { get; set; }

        [EntityPropertyExtension("TerminalNumberOfCustomerService", "TerminalNumberOfCustomerService")]
        public string TerminalNumberOfCustomerService { get; set; }

        [EntityPropertyExtension("TerminalNumberOfStevedores", "TerminalNumberOfStevedores")]
        public string TerminalNumberOfStevedores { get; set; }

        [EntityPropertyExtension("TerminalForkliftsUsage", "TerminalForkliftsUsage")]
        public string TerminalForkliftsUsage { get; set; }

        [EntityPropertyExtension("TerminalLoadingPlatform", "TerminalLoadingPlatform")]
        public string TerminalLoadingPlatform { get; set; }

        [EntityPropertyExtension("TerminalDeliveryVehicles", "TerminalDeliveryVehicles")]
        public string TerminalDeliveryVehicles { get; set; }

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
