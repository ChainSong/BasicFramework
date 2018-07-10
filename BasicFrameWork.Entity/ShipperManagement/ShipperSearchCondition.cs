using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFramework.Entity
{
    [Serializable]
    public class ShipperSearchCondition
    {
        public string Name { get; set; }

        public string Attribution { get; set; }

        public string RegisteredCapitalRange { get; set; }

        public string AnnualTurnoverRange { get; set; }

        public string StartPlaceIDs { get; set; }

        public string StartPlaceNames { get; set; }

        public string EndPlaceIDs { get; set; }

        public string EndPlaceNames { get; set; }

        public string CoverRegionIDs { get; set; }

        public string CoverRegionNames { get; set; }

        public string TransportMode { get; set; }

        public string TrunkOfVehicleType { get; set; }

        public string ProductType { get; set; }

        public string FrequencyOfDeparture { get; set; }

        public string TrunkOfVehicleRange { get; set; }

        public string DeliveryOfVehicleRange { get; set; }

        public string WarehouseAreaRange { get; set; }

        public string Recommended { get; set; }

        public string KeyWord { get; set; }

        public string PartnerShipType { get; set; }
    }
}
