using System.Collections.Generic;
using BasicFramework.Entity;

namespace BasicFramework.MessageContracts
{
    public class AddOrUpdateCRMShipperTerminalInfoRequest
    {
        public IEnumerable<ShipperTerminalInfo> ShipperTerminalInfoCollection { get; set; }
    }
}
