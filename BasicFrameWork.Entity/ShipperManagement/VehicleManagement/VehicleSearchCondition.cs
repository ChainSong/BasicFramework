using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFramework.Entity.ShipperManagement.VehicleManagement
{
    [Serializable]
    public class VehicleSearchCondition
    {
        public string ShipperID { get; set; }

        public string CarNo { get; set; }

        public string CarTypeNo { get; set; }

        public string LogisticCompany { get; set; }

        public string DrivedJourney { get; set; }

        public string BoardlotDate { get; set; }

        public string CarAge { get; set; }

        public string CarNumType { get; set; }

        public string FuelType { get; set; }

        public string CarBodyColor { get; set; }

        public string Manufacturer { get; set; }

        public string StartServiceDate { get; set; }

        public string EntireCarWeight { get; set; }

        public string StartBoardlotTime { get; set; }

        public string EndBoardlotTime { get; set; }

        public string StartServiceTime { get; set; }

        public string EndServiceTime { get; set; }


        public int PageIndex { get; set; }

        public int PageCount { get; set; }
    }
}
