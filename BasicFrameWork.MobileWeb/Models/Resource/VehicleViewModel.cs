using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BasicFramework.Entity.ShipperManagement.VehicleManagement;

namespace BasicFramework.MobileWeb.Models.Resource
{
    public class VehicleViewModel
    {
        public IEnumerable<Vehicle> CRMVehicleCollection { get; set; }

        public int PageIndex { get; set; }

        public int PageCount { get; set; }

    }
}