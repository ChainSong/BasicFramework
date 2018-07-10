using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicFramework.Entity;

namespace BasicFramework.MessageContracts
{
    public class AddOrUpdateRoleRequest
    {
        public IEnumerable<Role> RoleCollection { get; set; }
    }
}
