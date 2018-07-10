using System.Collections.Generic;
using BasicFramework.Entity;

namespace BasicFramework.MessageContracts
{
    public class AddOrUpdateCRMShippersRequest
    {
        public IEnumerable<Shipper> ShipperCollection { get; set; }
    }
}