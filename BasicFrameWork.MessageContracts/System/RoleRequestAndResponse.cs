using BasicFramework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFramework.MessageContracts
{
   public class RoleRequestAndResponse
    {
        public IEnumerable<Role> RoleCollection{ get; set; }

        public Role Role { get; set; }
       
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int PageCount { get; set; }

        public int TotalCount { get; set; }
    }
}
