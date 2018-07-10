using System.Collections.Generic;
using BasicFramework.Entity;

namespace BasicFramework.MessageContracts
{
    public class AddOrUpdateCRMShipperCooperationsRequest
    {
        public IEnumerable<ShipperCooperation> ShipperCooperationCollection { get; set; }
    }
}
