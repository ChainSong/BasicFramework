using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BasicFramework.Entity.ShipperManagement.DriverManagement;
using BasicFramework.Entity.ShipperManagement.VehicleManagement;
using BasicFramework.Web.Common;

namespace BasicFramework.Web.Areas.ShipperManagement.Models
{
    public class VehicleDriverMappingViewModel
    {
        public IEnumerable<VehicleDriverMapping> VehicleDriverMappingCollection { get; set; }

        public IEnumerable<Vehicle> Vehicle { get; set; }

        public IEnumerable<Driver> Driver { get; set; }



        public int PageIndex { get; set; }

        public int PageCount { get; set; }


        public long VID { get; set; }

        public long DID { get; set; }

        public string VehicleNo { get; set; }

        public string DriverName { get; set; }

        public string DriverPhone { get; set; }

        public string str1 { get; set; }

        public string str2 { get; set; }
    }
}