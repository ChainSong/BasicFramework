using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BasicFramework.Entity;

namespace BasicFramework.Web.Areas.ShipperManagement.Models
{
    public class ShipperIndexViewModel
    {
        public IEnumerable<Shipper> ShipperCollection { get; set; }

        public ShipperSearchCondition ShipperSearchCondition { get; set; }

        public int PageIndex { get; set; }

        public int PageCount { get; set; }

        public bool ShowEditButton { get; set; }

        public IEnumerable<SelectListItem> RegisteredCapital
        {
            get
            {
                return new List<SelectListItem>() 
                { 
                    new SelectListItem() { Value = "", Text = "" },
                    new SelectListItem() { Value = "100万以内", Text = "100万以内" },
                    new SelectListItem() { Value = "100万-300万", Text = "100万-300万" }, 
                    new SelectListItem() { Value = "300万-500万", Text = "300万-500万" },
                    new SelectListItem() { Value = "500万-800万", Text = "500万-800万" },
                    new SelectListItem() { Value = "800万-1200万", Text = "800万-1200万" },
                    new SelectListItem() { Value = "1200万-2000万", Text = "1200万-2000万" },
                    new SelectListItem() { Value = "2000万以上", Text = "2000万以上" }
                };
            }
        }

        public IEnumerable<SelectListItem> AnnualTurnover
        {
            get
            {
                return new List<SelectListItem>() 
                { 
                    new SelectListItem() { Value = "", Text = "" },
                    new SelectListItem() { Value = "500万以内", Text = "500万以内" }, 
                    new SelectListItem() { Value = "500万-800万", Text = "500万-800万" },
                    new SelectListItem() { Value = "800万-1200万", Text = "800万-1200万" },
                    new SelectListItem() { Value = "1200万-2000万", Text = "1200万-2000万" },
                    new SelectListItem() { Value = "2000万-5000万", Text = "2000万-5000万" },
                    new SelectListItem() { Value = "5000万-1亿", Text = "5000万-1亿" },
                    new SelectListItem() { Value = "1亿以上", Text = "1亿以上" }
                };
            }
        }

        public string[] PostedTransportModes { get; set; }

        public IEnumerable<SelectListItem> SelectedTransportModes { get; set; }

        public IEnumerable<SelectListItem> TransportModes
        {
            get
            {
                return new List<SelectListItem>() 
                { 
                    new SelectListItem() { Value = "公路", Text = "公路" },
                    new SelectListItem() { Value = "铁路", Text = "铁路" }, 
                    new SelectListItem() { Value = "航空", Text = "航空" },
                    new SelectListItem() { Value = "水路", Text = "水路" },
                    new SelectListItem() { Value = "快递", Text = "快递" },
                    new SelectListItem() { Value = "落地配", Text = "落地配" }     
                };
            }
        }

        public IEnumerable<SelectListItem> TrunkOfVehicleTypes
        {
            get
            {
                return new List<SelectListItem>() 
                { 
                    new SelectListItem() { Value = "", Text = "" },
                    new SelectListItem() { Value = "厢车", Text = "厢车" },
                    new SelectListItem() { Value = "平板车", Text = "平板车" }, 
                    new SelectListItem() { Value = "高栏车", Text = "高栏车" },
                    new SelectListItem() { Value = "冷藏车", Text = "冷藏车" },
                    new SelectListItem() { Value = "甩挂车", Text = "甩挂车" },
                    new SelectListItem() { Value = "危险品车", Text = "危险品车" }     
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

        public IEnumerable<SelectListItem> FrequencyOfDepartures
        {
            get
            {
                return new List<SelectListItem>() 
                { 
                    new SelectListItem() { Value = "", Text = "" },
                    new SelectListItem() { Value = "1", Text = "1" },
                    new SelectListItem() { Value = "2", Text = "2" }, 
                    new SelectListItem() { Value = "3", Text = "3" },
                    new SelectListItem() { Value = "4", Text = "4" },
                    new SelectListItem() { Value = "5", Text = "5" },
                    new SelectListItem() { Value = "6", Text = "6" },
                    new SelectListItem() { Value = "7", Text = "7" },
                    new SelectListItem() { Value = "8", Text = "8" }, 
                    new SelectListItem() { Value = "9", Text = "9" },
                    new SelectListItem() { Value = "10", Text = "10" },
                    new SelectListItem() { Value = "11", Text = "11" },
                    new SelectListItem() { Value = "12", Text = "12" },
                    new SelectListItem() { Value = "13", Text = "13" },
                    new SelectListItem() { Value = "14", Text = "14" }, 
                    new SelectListItem() { Value = "15", Text = "15" }
                };
            }
        }

        public IEnumerable<SelectListItem> TrunkOfVehicles
        {
            get
            {
                return new List<SelectListItem>() 
                { 
                    new SelectListItem() { Value = "", Text = "" },
                    new SelectListItem() { Value = "8辆以下", Text = "8辆以下" }, 
                    new SelectListItem() { Value = "8辆-12辆", Text = "8辆-12辆" },
                    new SelectListItem() { Value = "12-18辆", Text = "12-18辆" },
                    new SelectListItem() { Value = "18-25辆", Text = "18-25辆" },
                    new SelectListItem() { Value = "25辆以上", Text = "25辆以上" }
                };
            }
        }

        public IEnumerable<SelectListItem> WarehouseAreas
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

        public IEnumerable<SelectListItem> Recommendeds
        {
            get
            {
                return new List<SelectListItem>() 
                { 
                    new SelectListItem() { Value = "", Text = "" },
                    new SelectListItem() { Value = "1", Text = "1星" },
                    new SelectListItem() { Value = "2", Text = "2星" }, 
                    new SelectListItem() { Value = "3", Text = "3星" },
                    new SelectListItem() { Value = "4", Text = "4星" },
                    new SelectListItem() { Value = "5", Text = "5星" }   
                };
            }
        }

        public IEnumerable<SelectListItem> PartnerShipTypes
        {
            get
            {
                return new List<SelectListItem>() 
                { 
                    new SelectListItem() { Value = "", Text = "" },
                    new SelectListItem() { Value = "推荐", Text = "推荐" }, 
                    new SelectListItem() { Value = "合作", Text = "合作" },
                    new SelectListItem() { Value = "黑名单", Text = "黑名单" }
                };
            }
        }

    }
}