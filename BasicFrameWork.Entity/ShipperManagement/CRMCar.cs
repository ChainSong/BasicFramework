using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFramework.Entity.ShipperManagement
{
    public class CRMCar
    {
        public long ID { get; set; }

        public long SID { get; set; }

        public long VID { get; set; }

        public DateTime? CreateTime { get; set; }

        public string CreateUser { get; set; }

        public string ShipperName { get; set; }

        public string VehicleNo { get; set; }

        public string Remark { get; set; }


    }
}
