using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFramework.Entity.ShipperManagement.VehicleManagement
{
    public class CRMDriverName
    {
        public long ID { get; set; }

        public long VID { get; set; }

        public long DID { get; set; }

        public DateTime? CreateTime { get; set; }

        public string CreateUser { get; set; }

        public string VehicleNo { get; set; }

        public string DriverName { get; set; }

        public string DriverPhone { get; set; }
    }
}
