using BasicFramework.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BasicFramework.Web.Common;

namespace BasicFramework.Web.Areas.System.Models
{
    public class RoleIndexViewModel : BaseViewModel
    {
        public Role Role { get; set; }

        public IEnumerable<Role> RoleCollection { get; set; }

        public IEnumerable<SelectListItem> States
        {
            get
            {
                return new List<SelectListItem>() 
                { 
                    new SelectListItem() { Value = "true", Text = "正常" }, 
                    new SelectListItem() { Value = "false", Text = "停用" }  
                };

            }
        }
    }
}   