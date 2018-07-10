using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BasicFramework.Entity;

namespace BasicFramework.Web.Areas.System.Models
{
    public class UserRoleMappingViewModel
    {
        public long UserID { get; set; }

        public string UserName { get; set; }

        public IEnumerable<Role> RoleCollection { get; set; }
    }
}