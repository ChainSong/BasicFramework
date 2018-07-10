using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicFramework.Entity;

namespace BasicFramework.MessageContracts
{
    public class GetShippersByConditionResponse
    {
        public IEnumerable<Shipper> ShipperCollection { get; set; }

        public ShipperSearchCondition ShipperSearchCondition { get; set; }

        public int PageCount { get; set; }

        public int PageIndex { get; set; }
    }
}
