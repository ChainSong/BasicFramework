using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BasicFramework.Entity;
using BasicFramework.Entity.ShipperManagement;
using BasicFramework.Entity.ShipperManagement.VehicleManagement;

namespace BasicFramework.Web.Areas.ShipperManagement.Models
{
    public class ShipperVehicleMappingViewModel
    {
        public ShipperVehicleMapping ShipperToVehicle { get; set; }

        public VehicleSearchCondition SearchCondition { get; set; }

        //public IEnumerable<ShipperToVehicle> ShipperToVehicleCollection { get; set; }

        public IEnumerable<Shipper> Shipper { get; set; }

        public IEnumerable<Vehicle> Vehicle { get; set; }

        public Vehicle CRMVehicle { get; set; }

        public string ids { get; set; }

        public int PageIndex { get; set; }

        public int PageCount { get; set; }

        //0 add 1 view
        public int ViewType { get; set; }


        public long SID { get; set; }

        public long VID { get; set; }


        public string ShipperName { get; set; }

        public string VehicleNo { get; set; }

        public string Remark { get; set; }

        public string str1 { get; set; }

        public string str2 { get; set; }
    }
}