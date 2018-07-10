using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFramework.Entity.ShipperManagement.DriverManagement
{  
    [Serializable]
    public class DriverSearchCondition
    {
        public string VehicleID { get; set; }
       
        public string DriverName { get; set; }

        public string DriverLogisticsCompany { get; set; }

        public string DriverPhone { get; set; }

        public string DriverStartServeForRunbowDate { get; set; }

        public string DriverIDCard { get; set; }

        public string DriverCardNo { get; set; }

        public string DriverIsServing { get; set; }

        public string DriverCardType { get; set; }

        public string DriverRegistrationCardSignedAddress { get; set; }

        public string DriverServiceArea { get; set; }

        public string DriverCarNo { get; set; }

        public string DriverMainRoute { get; set; }

        public string StartServeForRunbowTime { get; set; }

        public string EndServeForRunbowTime { get; set; }
   
    }
}
