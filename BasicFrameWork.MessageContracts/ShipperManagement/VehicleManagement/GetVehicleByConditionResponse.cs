using BasicFramework.Entity.ShipperManagement.VehicleManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFramework.MessageContracts.ShipperManagement.VehicleManagement
{
    public class GetVehicleByConditionResponse
    {
        public IEnumerable<Vehicle> VehicleCollection { get; set; }

        public int PageCount { get; set; }

        public int PageIndex { get; set; }
    }
}
