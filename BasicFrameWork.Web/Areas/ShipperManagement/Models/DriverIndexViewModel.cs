using BasicFramework.Entity.ShipperManagement.DriverManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasicFramework.Web.Areas.ShipperManagement.Models
{
    public class DriverIndexViewModel
    {
        public IEnumerable<Driver> CRMDriverCollection { get; set; }

        public DriverSearchCondition SearchCondition { get; set; }

        public Driver Driver { get; set; }

        public int PageIndex { get; set; }

        public int PageCount { get; set; }

        public bool ShowEditButton { get; set; }

        public int ViewType { get; set; }

        public string UserID { get; set; }


       // A1、A2、A3、B1、B2、C1、C2、C3、C4、D、E、F、M、N、P，


        public IEnumerable<SelectListItem> DriverIsServing
        {
            get
            {
                return new List<SelectListItem>() 
                {
                    new SelectListItem() { Value = "0", Text = "否" }, 
                    new SelectListItem() { Value = "1", Text = "是" }  
                };
            }
        }

        public IEnumerable<SelectListItem> DriverCardType
        {
            get
            {
                return new List<SelectListItem>() 
                {
                    new SelectListItem() { Value = "A1", Text = "A1" }, 
                    new SelectListItem() { Value = "A2", Text = "A2" },
                    new SelectListItem() { Value = "A3", Text = "A3" },
                    new SelectListItem() { Value = "B1", Text = "B1" },
                    new SelectListItem() { Value = "B2", Text = "B2" },
                    new SelectListItem() { Value = "C1", Text = "C1" },
                    new SelectListItem() { Value = "C2", Text = "C2" },
                    new SelectListItem() { Value = "C3", Text = "C3" },
                    new SelectListItem() { Value = "C4", Text = "C4" },
                    new SelectListItem() { Value = "D", Text = "D" },
                    new SelectListItem() { Value = "E", Text = "E" },
                    new SelectListItem() { Value = "F", Text = "F" },
                    new SelectListItem() { Value = "M", Text = "M" },
                    new SelectListItem() { Value = "N", Text = "N" },
                    new SelectListItem() { Value = "P", Text = "P" },
                };
            }
        }

        public IEnumerable<SelectListItem> DriverIsServings
        {
            get
            {
                return new List<SelectListItem>() 
                {
                    new SelectListItem() { Value = "0", Text = "否" }, 
                    new SelectListItem() { Value = "1", Text = "是" }  
                };
            }
        }


        public IEnumerable<SelectListItem> DriverCardTypes
        {
            get
            {
                return new List<SelectListItem>() 
                {
                    new SelectListItem() { Value = "A1", Text = "A1" }, 
                    new SelectListItem() { Value = "A2", Text = "A2" },
                    new SelectListItem() { Value = "A3", Text = "A3" },
                    new SelectListItem() { Value = "B1", Text = "B1" },
                    new SelectListItem() { Value = "B2", Text = "B2" },
                    new SelectListItem() { Value = "C1", Text = "C1" },
                    new SelectListItem() { Value = "C2", Text = "C2" },
                    new SelectListItem() { Value = "C3", Text = "C3" },
                    new SelectListItem() { Value = "C4", Text = "C4" },
                    new SelectListItem() { Value = "D", Text = "D" },
                    new SelectListItem() { Value = "E", Text = "E" },
                    new SelectListItem() { Value = "F", Text = "F" },
                    new SelectListItem() { Value = "M", Text = "M" },
                    new SelectListItem() { Value = "N", Text = "N" },
                    new SelectListItem() { Value = "P", Text = "P" },
                };
            }
        }
        
       
    }
}