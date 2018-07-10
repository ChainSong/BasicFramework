using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BasicFramework.Entity;

namespace BasicFramework.Web.Areas.ShipperManagement.Models
{
    public class ShipperTransportationLineViewModel
    {
        public string StartPlaceID { get; set; }

        public string StartPlaceName { get; set; }

        public string EndPlaceID { get; set; }

        public string EndPlaceName { get; set; }

        public long CRMShipperID { get; set; }

        public string CoverRegionID { get; set; }

        public string CoverRegionName { get; set; }

        public int Period { get; set; }

        public int ViewType { get; set; }

        public IEnumerable<ShipperTransportationLine> ShipperTransportationLineCollection { get; set; }
    }
}