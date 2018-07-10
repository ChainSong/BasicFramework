using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicFramework.Entity;

namespace BasicFramework.MessageContracts
{
    public class GetShippersByConditionRequest
    {
        public ShipperSearchCondition SearchCondition { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}
