using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFramework.MessageContracts
{
    public class CRMShipperOperationRequest
    {
        public long? CRMShipperID { get; set; }

        public long? CRMShipperCooperationID { get; set; }

        public long? CRMShipperTransportationLineID { get; set; }

        public long? CRMShipperTerminalInfoID { get; set; }
    }
}
