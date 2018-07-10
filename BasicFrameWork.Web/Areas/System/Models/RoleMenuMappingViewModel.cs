using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BasicFramework.Entity;

namespace BasicFramework.Web.Areas.System.Models
{
    public class RoleMenuMappingViewModel
    {
        public long RoleID { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }

        public string MenusForJsonString { get; set; }
    }
}