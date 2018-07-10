using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BasicFramework.Entity;

namespace BasicFramework.MobileWeb.Models.Resource
{
    public class ShipperInfosModel
    {
        public Shipper Shipper { get; set; }

        public IEnumerable<ShipperTransportationLine> CRMShipperTransportationLineCollection { get; set; }

        public IEnumerable<ShipperCooperation> CRMShipperCooperationCollection { get; set; }

        public IEnumerable<ShipperTerminalInfo> CRMShipperTerminalInfoCollection { get; set; }

        //0 View 1 Create 2 Edit
        public int ViewType { get; set; }

        public string[] PostedTransportModes { get; set; }

        public string[] PostedSixCards { get; set; }


        public string[] PostedTrunkOfVehicleTypes { get; set; }


        public string[] PostedDeliveryOfVehicleTypes { get; set; }


        public string[] PostedTermialOfVehicleTypes { get; set; }

    }
}