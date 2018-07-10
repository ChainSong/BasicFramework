using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicFramework.Entity.ShipperManagement.DriverManagement;

namespace BasicFramework.MessageContracts.ShipperManagement.DriverManagement
{
    public class AddOrUpdateDriverRequest
    {
        public IEnumerable<Driver> DriverCollection { get; set; }
    }
}
