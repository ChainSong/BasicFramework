using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicFramework.Common;

namespace BasicFramework.Entity.ShipperManagement.VehicleManagement
{
    public class VehicleDriverMapping
    {
        [EntityPropertyExtension("ID", "ID")]
        public long ID { get; set; }

        [EntityPropertyExtension("VID", "VID")]
        public long VID { get; set; }

        [EntityPropertyExtension("DID", "DID")]
        public long DID { get; set; }

        [EntityPropertyExtension("CreateTime", "CreateTime")]
        public DateTime? CreateTime { get; set; }

        [EntityPropertyExtension("CreateUser", "CreateUser")]
        public string CreateUser { get; set; }

        [EntityPropertyExtension("VehicleNo", "VehicleNo")]
        public string VehicleNo { get; set; }

        [EntityPropertyExtension("DriverName", "DriverName")]
        public string DriverName { get; set; }

        [EntityPropertyExtension("DriverPhone", "DriverPhone")]
        public string DriverPhone { get; set; }

        [EntityPropertyExtension("str1", "str1")]
        public string str1 { get; set; }

        [EntityPropertyExtension("str2", "str2")]
        public string str2 { get; set; }

        [EntityPropertyExtension("datetime1", "datetime1")]
        public DateTime? datetime1 { get; set; }

        [EntityPropertyExtension("datetime2", "datetime2")]
        public DateTime? datetime2 { get; set; }

        [EntityPropertyExtension("int1", "int1")]
        public int int1 { get; set; }

        [EntityPropertyExtension("int2", "int2")]
        public int int2 { get; set; }

    }
}
