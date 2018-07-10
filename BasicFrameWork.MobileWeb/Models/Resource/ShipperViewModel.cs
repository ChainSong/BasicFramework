using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BasicFramework.Entity;

namespace BasicFramework.MobileWeb.Models.Resource
{
    public class ShipperViewModel
    {
        public IEnumerable<Shipper> CRMShipperCollection { get; set; }

        public ShipperSearchCondition SearchCondition { get; set; }

        public int PageIndex { get; set; }

        public int PageCount { get; set; }

        public string[] PostedTransportModes { get; set; }

        public string[] PostedProductTypes { get; set; }

    }
}