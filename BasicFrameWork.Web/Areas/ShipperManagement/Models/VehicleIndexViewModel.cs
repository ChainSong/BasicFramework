using BasicFramework.Entity.ShipperManagement.VehicleManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BasicFramework.Entity.ShipperManagement;

namespace BasicFramework.Web.Areas.ShipperManagement.Models
{
    public class VehicleIndexViewModel
    {

        public VehicleSearchCondition SearchCondition { get; set; }

        public Vehicle Vehicle { get; set; }

        public string UserID { get; set; }

        //public string StatUpLoadTime { get; set; }

        //public string EndUpLoadTime { get; set; }

        public IEnumerable<Vehicle> VehicleCollection { get; set; }

        public IEnumerable<ShipperVehicleMapping> ShipperMappingVehicleCollection { get; set; }

        public int PageIndex { get; set; }

        public int PageCount { get; set; }

        public bool ShowEditButton { get; set; }

        public bool IsForExport { get; set; }

        public string ExportType { get; set; }

        //0 Create 1 View 2 Edit
        public int ViewType { get; set; }

        public int? TypeID { get; set; }

        public IEnumerable<SelectListItem> CarNum
        {
            get
            {
                return new List<SelectListItem>() 
                {
                    new SelectListItem() { Value = "黄牌", Text = "黄牌" }, 
                    new SelectListItem() { Value = "蓝牌", Text = "蓝牌" },  
                };

            }
        }
        public IEnumerable<SelectListItem> Fuel
        {
            get 
            {
                return new List<SelectListItem>() 
                {
                    new SelectListItem() { Value = "柴油", Text = "柴油" }, 
                    new SelectListItem() { Value = "汽油", Text = "汽油" },
                    new SelectListItem() { Value = "液化气", Text = "液化气" },
                };
            }
        }
        public IEnumerable<SelectListItem> CarAge
        {
            get
            {
                return new List<SelectListItem>() 
                {
                    new SelectListItem() { Value = "1", Text = "1年以内" }, 
                    new SelectListItem() { Value = "2", Text = "1-2年" },
                    new SelectListItem() { Value = "3", Text = "2-3年" },
                    new SelectListItem() { Value = "4", Text = "3-4年" },
                    new SelectListItem() { Value = "5", Text = "4-5年" },
                    new SelectListItem() { Value = "6", Text = "5-6年" },
                    new SelectListItem() { Value = "7", Text = "6-7年" },
                    new SelectListItem() { Value = "8", Text = "7-8年" },
                    new SelectListItem() { Value = "9", Text = "8-9年" },
                    new SelectListItem() { Value = "10", Text = "9-10年" },
                    //new SelectListItem() { Value = "10年以上", Text = "10年以上" },
                };
            }
        }

        public IEnumerable<SelectListItem> Transducers
        {
            get
            {
                return new List<SelectListItem>() 
                {
                    new SelectListItem() { Value = "机械", Text = "机械" }, 
                    new SelectListItem() { Value = "电子", Text = "电子" },  
                };
            }
        }

        public IEnumerable<SelectListItem> BackUpBuzze
        {
            get
            {
                return new List<SelectListItem>() 
                {
                    new SelectListItem() { Value = "0", Text = "无" }, 
                    new SelectListItem() { Value = "1", Text = "有" }  
                };
            }
        }

        public IEnumerable<SelectListItem> TheTankerOilSpillProtectionDevice
        {
            get
            {
                return new List<SelectListItem>() 
                {
                    new SelectListItem() { Value = "0", Text = "无" }, 
                    new SelectListItem() { Value = "1", Text = "有" } 
                };
            }
        }

        public IEnumerable<SelectListItem> OilSpillPreventiontools
        {
            get
            {
                return new List<SelectListItem>() 
                {
                    new SelectListItem() { Value = "0", Text = "无" }, 
                    new SelectListItem() { Value = "1", Text = "有" }  
                };
            }
        }

        public IEnumerable<SelectListItem> ReflectBar
        {
            get
            {
                return new List<SelectListItem>() 
                {
                    new SelectListItem() { Value = "0", Text = "无" }, 
                    new SelectListItem() { Value = "1", Text = "有" } 
                };
            }
        }

        public IEnumerable<SelectListItem> HighSideStopLamps
        {
            get
            {
                return new List<SelectListItem>() 
                {
                    new SelectListItem() { Value = "0", Text = "无" }, 
                    new SelectListItem() { Value = "1", Text = "有" } 
                };
            }
        }

        public IEnumerable<SelectListItem> DangerousMark
        {
            get
            {
                return new List<SelectListItem>() 
                {
                    new SelectListItem() { Value = "0", Text = "无" }, 
                    new SelectListItem() { Value = "1", Text = "有" } 
                };
            }
        }

        public IEnumerable<SelectListItem> BackProtection
        {
            get
            {
                return new List<SelectListItem>() 
                {
                    new SelectListItem() { Value = "0", Text = "无" }, 
                    new SelectListItem() { Value = "1", Text = "有" } 
                };
            }
        }

        public IEnumerable<SelectListItem> ThreePointBelt
        {
            get
            {
                return new List<SelectListItem>() 
                {
                    new SelectListItem() { Value = "0", Text = "无" }, 
                    new SelectListItem() { Value = "1", Text = "有" }
                };
            }
        }

        public IEnumerable<SelectListItem> RolloverProtect
        {
            get
            {
                return new List<SelectListItem>() 
                {
                    new SelectListItem() { Value = "0", Text = "无" }, 
                    new SelectListItem() { Value = "1", Text = "有" } 
                };
            }
        }

        public IEnumerable<SelectListItem> ABS
        {
            get
            {
                return new List<SelectListItem>() 
                {
                    new SelectListItem() { Value = "0", Text = "无" }, 
                    new SelectListItem() { Value = "1", Text = "有" } 
                };
            }
        }

        public IEnumerable<SelectListItem> AirbagAmount
        {
            get
            {
                return new List<SelectListItem>() 
                {
                    new SelectListItem() { Value = "2", Text = "2个" }, 
                    new SelectListItem() { Value = "4", Text = "4个" },
                    new SelectListItem() { Value = "6", Text = "6个" },
                    new SelectListItem() { Value = "8", Text = "8个" },
                    new SelectListItem() { Value = "10", Text = "10个" }
                };
            }
        }

        public IEnumerable<SelectListItem> CarriageScope
        {
            get
            {
                return new List<SelectListItem>() 
                {
                    new SelectListItem() { Value = "0", Text = "无" }, 
                    new SelectListItem() { Value = "1", Text = "有" }  
                };
            }
        }

        public IEnumerable<SelectListItem> SafetyBeltAmount
        {
            get
            {
                return new List<SelectListItem>() 
                {
                     new SelectListItem() { Value = "1", Text = "1个" },
                     new SelectListItem() { Value = "2", Text = "2个" },
                     new SelectListItem() { Value = "3", Text = "3个" },
                     new SelectListItem() { Value = "4", Text = "4个" },
                     new SelectListItem() { Value = "5", Text = "5个" },
                };
            }
        }

        public IEnumerable<SelectListItem> CarType
        {
            get
            {
                return new List<SelectListItem>() 
                {
                    new SelectListItem() { Value = "挂车", Text = "挂车" }, 
                    new SelectListItem() { Value = "箱式车", Text = "箱式车" },
                    new SelectListItem() { Value = "尾板车", Text = "尾板车" },
                    new SelectListItem() { Value = "高栏车", Text = "高栏车" },
                    new SelectListItem() { Value = "低栏车", Text = "低栏车" }
                };
            }
        }

        

    }
}