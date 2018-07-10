using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BasicFramework.Entity;
using BasicFramework.Web.Common;

namespace BasicFramework.Web.Areas.ShipperManagement.Models
{
    public class ShipperCreateOrUpdateViewModel : BaseViewModel
    {
        public Shipper Shipper { get; set; }

        public IEnumerable<ShipperTransportationLine> ShipperTransportationLineCollection { get; set; }

        public IEnumerable<ShipperCooperation> ShipperCooperationCollection { get; set; }

        public IEnumerable<ShipperTerminalInfo> ShipperTerminalInfoCollection { get; set; }

        //0 View 1 Create 2 Edit
        public int ViewType { get; set; }

        public bool ShowEditButton { get; set; }

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

        public string[] PostedSixCards { get; set; }

        public IEnumerable<SelectListItem> SelectedSixCards { get; set; }
        
        public IEnumerable<SelectListItem> SixCards
        {
            get
            {
                return new List<SelectListItem>() 
                { 
                    new SelectListItem() { Value = "营业执照", Text = "营业执照" },
                    new SelectListItem() { Value = "税务登记证", Text = "税务登记证" }, 
                    new SelectListItem() { Value = "道路运输许可证", Text = "道路运输许可证" },
                    new SelectListItem() { Value = "企业组织机构代码证", Text = "企业组织机构代码证" },
                    new SelectListItem() { Value = "开户许可证", Text = "开户许可证" },
                    new SelectListItem() { Value = "法人身份证", Text = "法人身份证" }     
                };
            }
        }

        public IEnumerable<SelectListItem> LoadingPlatforms
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

        public IEnumerable<SelectListItem> HasGPS
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

        public string[] PostedTrunkOfVehicleTypes { get; set; }

        public IEnumerable<SelectListItem> SelectedTrunkOfVehicleTypes { get; set; }

        public IEnumerable<SelectListItem> TrunkOfVehicleTypes
        {
            get
            {
                return new List<SelectListItem>() 
                { 
                    new SelectListItem() { Value = "厢车", Text = "厢车" },
                    new SelectListItem() { Value = "平板车", Text = "平板车" }, 
                    new SelectListItem() { Value = "高栏车", Text = "高栏车" },
                    new SelectListItem() { Value = "冷藏车", Text = "冷藏车" },
                    new SelectListItem() { Value = "甩挂车", Text = "甩挂车" },
                    new SelectListItem() { Value = "危险品车", Text = "危险品车" }     
                };
            }
        }

        public IEnumerable<SelectListItem> DeliveryOfVehicles
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

        public string[] PostedDeliveryOfVehicleTypes { get; set; }

        public IEnumerable<SelectListItem> SelectedDeliveryOfVehicleTypes { get; set; }

        public IEnumerable<SelectListItem> DeliveryOfVehicleTypes
        {
            get
            {
                return new List<SelectListItem>() 
                { 
                    new SelectListItem() { Value = "4.2m", Text = "4.2m" },
                    new SelectListItem() { Value = "6.2m", Text = "6.2m" }, 
                    new SelectListItem() { Value = "8.6m", Text = "8.6m" },
                    new SelectListItem() { Value = "9.6m", Text = "9.6m" },
                    new SelectListItem() { Value = "12.5m", Text = "12.5m" },
                    new SelectListItem() { Value = "17.5m", Text = "17.5m" }     
                };
            }
        }

        public string[] PostedTermialOfVehicleTypes { get; set; }

        public IEnumerable<SelectListItem> SelectedTermialOfVehicleTypes { get; set; }

        public IEnumerable<SelectListItem> TermialOfVehicleTypes
        {
            get
            {
                return new List<SelectListItem>() 
                { 
                    new SelectListItem() { Value = "4.2m", Text = "4.2m" },
                    new SelectListItem() { Value = "6.2m", Text = "6.2m" }, 
                    new SelectListItem() { Value = "8.6m", Text = "8.6m" },
                    new SelectListItem() { Value = "9.6m", Text = "9.6m" },
                    new SelectListItem() { Value = "12.5m", Text = "12.5m" },
                    new SelectListItem() { Value = "金杯", Text = "金杯" },     
                    new SelectListItem() { Value = "依维柯", Text = "依维柯" }
                };
            }
        }
        
        public IEnumerable<SelectListItem> GoodsStructures
        {
            get
            {
                return new List<SelectListItem>() 
                { 
                    new SelectListItem() { Value = "", Text = "" },
                    new SelectListItem() { Value = "重货", Text = "重货" }, 
                    new SelectListItem() { Value = "泡货", Text = "泡货" },
                    new SelectListItem() { Value = "重泡货", Text = "重泡货" }
                };
            }
        }

        public IEnumerable<SelectListItem> PartnerShipTypes
        {
            get
            {
                return new List<SelectListItem>() 
                { 
                    new SelectListItem() { Value = "推荐", Text = "推荐" }, 
                    new SelectListItem() { Value = "合作", Text = "合作" },
                    new SelectListItem() { Value = "黑名单", Text = "黑名单" }
                };
            }
        }

        public IEnumerable<SelectListItem> Status
        {
            get
            {
                return new List<SelectListItem>() 
                { 
                    new SelectListItem() { Value = "true", Text = "是" }, 
                    new SelectListItem() { Value = "false", Text = "否" }
                };
            }
        }

        public IEnumerable<SelectListItem> Status_String
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

        public IEnumerable<SelectListItem> FrequencyOfDepartures
        {
            get
            {
                return new List<SelectListItem>() 
                { 
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
    }
}