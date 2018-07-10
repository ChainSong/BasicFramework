using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BasicFramework.Entity;

namespace BasicFramework.Web.Areas.ShipperManagement.Models
{
    public class ShipperTerminalInfoViewModel
    {
        public long CRMShipperID { get; set; }

        public int ViewType { get; set; }

        public string TerminalAddress { get; set; }

        public string IsOwn { get; set; }

        public string TerminalOfficeArea { get; set; }

        public string TerminalWareHouseArea { get; set; }

        public string TerminalWareHouseAreaRange { get; set; }

        public string TerminalNumberOfEmployees { get; set; }

        public string TerminalNumberOfCustomerService { get; set; }

        public string TerminalNumberOfStevedores { get; set; }

        public string TerminalForkliftsUsage { get; set; }

        public string TerminalLoadingPlatform { get; set; }

        public string TerminalDeliveryVehicles { get; set; }

        public string Str1 { get; set; }

        public string Str2 { get; set; }

        public string Str3 { get; set; }

        public string Str4 { get; set; }

        public string Str5 { get; set; }

        public IEnumerable<ShipperTerminalInfo> CRMShipperTerminalInfoCollection { get; set; }

        public IEnumerable<SelectListItem> TrueOrFalse
        {
            get
            {
                return new List<SelectListItem>() 
                { 
                    new SelectListItem() { Value = "是", Text = "是" },
                    new SelectListItem() { Value = "否", Text = "否" }
                };
            }
        }

        public IEnumerable<SelectListItem> HaveOrNone
        {
            get
            {
                return new List<SelectListItem>() 
                { 
                    new SelectListItem() { Value = "有", Text = "有" },
                    new SelectListItem() { Value = "无", Text = "无" }
                };
            }
        }

        public IEnumerable<SelectListItem> WarehouseArea
        {
            get
            {
                return new List<SelectListItem>() 
                { 
                    new SelectListItem() { Value = "", Text = "" },
                    new SelectListItem() { Value = "300以内", Text = "300以内" }, 
                    new SelectListItem() { Value = "300-500", Text = "300-500" },
                    new SelectListItem() { Value = "500-800", Text = "500-800" },
                    new SelectListItem() { Value = "800-1000", Text = "800-1000" },
                    new SelectListItem() { Value = "1000-1500", Text = "1000-1500" },
                    new SelectListItem() { Value = "1500-2000", Text = "1500-2000" },
                    new SelectListItem() { Value = "2000以上", Text = "2000以上" }
                };
            }
        }
    }
}