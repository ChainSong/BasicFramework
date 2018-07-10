using System.Collections.Generic;
using BasicFramework.Entity;

namespace BasicFramework.MessageContracts
{
    public class AddOrUpdateCRMShipperTransportationLineRequest
    {
        public IEnumerable<ShipperTransportationLine> ShipperTransportationLineCollection { get; set; }
    }
}
