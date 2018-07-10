using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BasicFramework.Entity;

namespace BasicFramework.Web.Areas.ShipperManagement.Models
{
    public class ShipperCooperationViewModel
    {
        public long CRMShipperID { get; set; }

        public int ViewType { get; set; }

        public string Name { get; set; }

        public string Remark { get; set; }

        public string AttachmentGroupID { get; set; }

        public string Str1 { get; set; }

        public string Str2 { get; set; }

        public string Str3 { get; set; }

        public string Str4 { get; set; }

        public string Str5 { get; set; }

        public string Str6 { get; set; }

        public string Str7 { get; set; }

        public string Str8 { get; set; }

        public string Str9 { get; set; }

        public string Str10 { get; set; }

        public IEnumerable<ShipperCooperation> CRMShipperCooperationCollection { get; set; }

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

        public string[] PostedProductTypes { get; set; }

        public IEnumerable<SelectListItem> SelectedProductTypes { get; set; }

        public IEnumerable<SelectListItem> ProductTypes
        {
            get
            {
                return new List<SelectListItem>() 
                { 
                    new SelectListItem() { Value = "服装", Text = "服装" },
                    new SelectListItem() { Value = "医药", Text = "医药" }, 
                    new SelectListItem() { Value = "化妆品", Text = "化妆品" },
                    new SelectListItem() { Value = "家居", Text = "家居" },
                    new SelectListItem() { Value = "电子产品", Text = "电子产品" },
                    new SelectListItem() { Value = "快消", Text = "快消" }, 
                    new SelectListItem() { Value = "酒类", Text = "酒类" }, 
                    new SelectListItem() { Value = "家电", Text = "家电" }, 
                    new SelectListItem() { Value = "钢铁建材", Text = "钢铁建材" },
                    new SelectListItem() { Value = "煤炭", Text = "煤炭" },
                    new SelectListItem() { Value = "汽配", Text = "汽配" }, 
                    new SelectListItem() { Value = "化工", Text = "化工" }, 
                    new SelectListItem() { Value = "冷链", Text = "冷链" }, 
                    new SelectListItem() { Value = "危险品", Text = "危险品" }, 
                    new SelectListItem() { Value = "其他", Text = "其他" }
                };
            }
        }
    }
}