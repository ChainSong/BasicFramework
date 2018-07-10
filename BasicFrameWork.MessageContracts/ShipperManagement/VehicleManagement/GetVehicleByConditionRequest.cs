using BasicFramework.Entity.ShipperManagement.VehicleManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFramework.MessageContracts.ShipperManagement.VehicleManagement
{
    public class GetVehicleByConditionRequest
    {
        public VehicleSearchCondition SearchCondition { get; set; }

      

        public string keyword { get; set; }

        public string vehicleNo { get; set; }

        public string StatUpLoadTime { get; set; }

        public string EndUpLoadTime { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}
