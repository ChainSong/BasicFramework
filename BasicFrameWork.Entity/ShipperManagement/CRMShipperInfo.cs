using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFramework.Entity
{
    public  class CRMShipperInfo
    {
        public Shipper Shipper { get; set; }

        public IEnumerable<ShipperTransportationLine> ShipperTransportationLineCollection { get; set; }

        public IEnumerable<ShipperCooperation> ShipperCooperationCollection { get; set; }

        public IEnumerable<ShipperTerminalInfo> ShipperTerminalInfoCollection { get; set; }
    }
}
