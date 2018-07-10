using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Runbow.TWS.Common;

namespace Runbow.TWS.Entity.Phone
{
    public class WeiQueryPodCondition
    {
        //货主
        public long? CustomerId { get; set; }
        //品名
        public string Type { get; set; }

    }
}
