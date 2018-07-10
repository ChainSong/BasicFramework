using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BasicFramework.Entity.ShipperManagement.DriverManagement;

namespace BasicFramework.MobileWeb.Models.Resource
{
    public class DriverViewModel
    {
        public IEnumerable<Driver> DriverCollection { get; set; }

       

        public int PageIndex { get; set; }

        public int PageCount { get; set; }
      
    }
}