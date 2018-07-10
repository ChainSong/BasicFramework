using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicFramework.Entity.ShipperManagement.DriverManagement;

namespace BasicFramework.MessageContracts.ShipperManagement.DriverManagement
{
    public class GetDriverByConditionRequest
    {
        public DriverSearchCondition SearchCondition { get; set; }

        public Driver AddDriver { get; set; }

        public Driver Driver { get; set; }

        public string driverName { get; set; }

        public string driverphone { get; set; }

        public string keyword { get; set; }
        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}
