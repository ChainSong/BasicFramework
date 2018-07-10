using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicFramework.Entity.ShipperManagement.DriverManagement;
using BasicFramework.Entity.ShipperManagement.VehicleManagement;

namespace BasicFramework.MessageContracts.ShipperManagement.VehicleManagement
{
    public class VehicleMappingDriverResponse
    {
        public IEnumerable<VehicleDriverMapping> VehicleMappingDriverCollection { get; set; }

        public IEnumerable<Vehicle> VehicleCollection { get; set; }

        public Vehicle Vehicle { get; set; }

        public IEnumerable<Driver> DriverCollection { get; set; }

        public int PageCount { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}
