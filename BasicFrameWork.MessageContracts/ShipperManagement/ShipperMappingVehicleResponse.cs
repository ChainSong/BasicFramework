using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicFramework.Entity.ShipperManagement;
using BasicFramework.Entity.ShipperManagement.VehicleManagement;

namespace BasicFramework.MessageContracts.ShipperManagement
{
    public class ShipperMappingVehicleResponse
    {
        public IEnumerable<ShipperVehicleMapping> ShipperMappingVehicleCollection { get; set; }

        public IEnumerable<Vehicle> VehicleCollection { get; set; }

        public int PageCount { get; set; }

        public int PageIndex { get; set; }
    }
}
