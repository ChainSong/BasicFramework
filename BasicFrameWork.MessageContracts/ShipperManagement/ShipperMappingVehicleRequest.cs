using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicFramework.Entity.ShipperManagement;

namespace BasicFramework.MessageContracts.ShipperManagement
{
    public class ShipperMappingVehicleRequest
    {
        public IEnumerable<CRMCar> car { get; set; }

        public long SID { get; set; }

        public string ShipperName { get; set; }

        public string UserName { get; set; }

        public string Remark { get; set; }

        public string VehicleNo { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public string ID { get; set; }
    }
}
