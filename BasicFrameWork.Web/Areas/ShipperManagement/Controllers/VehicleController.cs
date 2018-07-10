using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using BasicFramework.Biz;
using BasicFramework.Biz.ShipperManagement;
using BasicFramework.Common;
using BasicFramework.Entity;
using BasicFramework.Entity.ShipperManagement.VehicleManagement;
using BasicFramework.MessageContracts.ShipperManagement;
using BasicFramework.MessageContracts.ShipperManagement.DriverManagement;
using BasicFramework.MessageContracts.ShipperManagement.VehicleManagement;
//using BasicFramework.MessageContracts.ShipperManagement.VehicleManagement;
using BasicFramework.Web.Areas.ShipperManagement.Models;
using BasicFramework.Web.Common;
using MyFile = System.IO.File;
using UtilConstants = BasicFramework.Common.Constants;


namespace BasicFramework.Web.Areas.ShipperManagement.Controllers
{
    public class VehicleController : BaseController
    {
        
        [HttpGet]
        public ActionResult Index(string id)
        {
            VehicleIndexViewModel vm = new VehicleIndexViewModel();
            vm.Vehicle = new Vehicle();
            VehicleSearchCondition vs = new VehicleSearchCondition();
            vm.SearchCondition = vs;

            if (!string.IsNullOrEmpty(id))
            {
                var result = new VehicleService().GetVehicleView(new ShipperMappingVehicleRequest() { ID = id });

                vm.VehicleCollection = result.Result.VehicleCollection;
                vm.PageIndex = result.Result.PageIndex;
                vm.PageCount = result.Result.PageCount;


            }
            else
            {


                var result = new VehicleService().GetVehicleByCondition(new GetVehicleByConditionRequest()
                {
                    SearchCondition = vm.SearchCondition,
                    PageSize = UtilConstants.PAGESIZE,
                    PageIndex = 0,
                });

                if (result.IsSuccess)
                {
                    vm.VehicleCollection = result.Result.VehicleCollection;
                    vm.UserID = base.UserInfo.ID.ToString();
                    vm.PageIndex = result.Result.PageIndex;
                    vm.PageCount = result.Result.PageCount;
                }
            }
             

            return View(vm);

        }


        [HttpPost]
        public ActionResult Index(VehicleIndexViewModel vi, int? PageIndex, string Action)
        {
            //查询导出
            var request = new GetVehicleByConditionRequest();
            
            if (Action == "查询" || Action == "Index")
            {
                request.SearchCondition = vi.SearchCondition;
                request.PageSize = UtilConstants.PAGESIZE;
                request.PageIndex = PageIndex ?? 0;
                vi.ShowEditButton = false;
                vi.ShowEditButton = true;
            }
            else if (Action == "导出")
            {
                request.SearchCondition = vi.SearchCondition;
                request.PageSize = 0;
                request.PageIndex = 0;
            }
            var response = new VehicleService().GetVehicleByCondition(request);
           
            if (response.IsSuccess)
            {
                if (Action == "导出")
                {
                    return this.Export(response.Result.VehicleCollection);
                }
                else
                {
                    vi.VehicleCollection = response.Result.VehicleCollection;
                    vi.PageIndex = response.Result.PageIndex;
                    vi.PageCount = response.Result.PageCount;
                }

            }
            return View(vi);
        }


        //导出
        private ActionResult Export(IEnumerable<Vehicle> crmVehicles)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("车牌号码", typeof(string));
            dt.Columns.Add("营运证号", typeof(string));
            dt.Columns.Add("车型编码", typeof(string));
            dt.Columns.Add("车辆VIN", typeof(string));
            dt.Columns.Add("物流公司", typeof(string));
            dt.Columns.Add("物流公司安全专员联系电话", typeof(string));
            dt.Columns.Add("已行驶公里数", typeof(string));
            dt.Columns.Add("车龄", typeof(string));
            dt.Columns.Add("资质", typeof(string));
            dt.Columns.Add("速度传感制式", typeof(string));
            dt.Columns.Add("号牌种类", typeof(string));
            dt.Columns.Add("燃料种类", typeof(string));
            dt.Columns.Add("车身颜色", typeof(string));
            dt.Columns.Add("生产厂家", typeof(string));
            dt.Columns.Add("整备质量(吨)", typeof(string));
            dt.Columns.Add("加入虹迪服务时间", typeof(string));
            dt.Columns.Add("上牌日期", typeof(string));
            dt.Columns.Add("下次年检日期", typeof(string));
            dt.Columns.Add("保险有效截止日期", typeof(string));
            dt.Columns.Add("主要行驶路线", typeof(string));
            dt.Columns.Add("核载(吨)", typeof(string));
            dt.Columns.Add("核定载客(人)", typeof(string));
            dt.Columns.Add("尺寸", typeof(string));
            dt.Columns.Add("总质量(吨)", typeof(string));
            dt.Columns.Add("牵引总质量(吨)", typeof(string));
            dt.Columns.Add("安全带数量", typeof(string));
            dt.Columns.Add("倒车蜂鸣器", typeof(string));
            dt.Columns.Add("油罐车溢油保护装置", typeof(string));
            dt.Columns.Add("防溢油工具", typeof(string));
            dt.Columns.Add("反射条", typeof(string));
            dt.Columns.Add("高位刹车灯", typeof(string));
            dt.Columns.Add("危险品标记", typeof(string));
            dt.Columns.Add("后部行人保护装置", typeof(string));
            dt.Columns.Add("三点式带传感器安全带", typeof(string));
            dt.Columns.Add("翻车保护装置", typeof(string));
            dt.Columns.Add("ABS", typeof(string));
            dt.Columns.Add("承运范围", typeof(string));
            dt.Columns.Add("安全气囊数量", typeof(string));
            dt.Columns.Add("车型类别", typeof(string));
            dt.Columns.Add("挂车号牌", typeof(string));
            dt.Columns.Add("挂车核载(吨)", typeof(string));
            dt.Columns.Add("挂车尺寸", typeof(string));
            dt.Columns.Add("挂车总质量(吨)", typeof(string));
            dt.Columns.Add("挂车整备质量(吨)", typeof(string));
            dt.Columns.Add("挂车车型编号", typeof(string));
            dt.Columns.Add("挂车上牌日期", typeof(string));
            dt.Columns.Add("挂车车辆VIN", typeof(string));
            dt.Columns.Add("挂车下次年检日期", typeof(string));




            crmVehicles.Each((i, s) =>
            {
                DataRow dr = dt.NewRow();
                dr[0] = s.CarNo;
                dr[1] = s.RunNo;
                dr[2] = s.CarTypeNo;
                dr[3] = s.CarVin;
                dr[4] = s.LogisticCompany;
                dr[5] = s.SecurityContactNum;
                dr[6] = s.DrivedJourney;
                dr[7] = s.CarAge;
                dr[8] = s.Qualify;
                dr[9] = s.Velocity_transducers;
                dr[10] = s.CarNumType;
                dr[11] = s.FuelType;
                dr[12] = s.CarBodyColor;
                dr[13] = s.Manufacturer;
                dr[14] = s.EntireCarWeight;
                dr[15] = s.StartServiceDate.ToString("yyyy-MM-dd");
                dr[16] = s.BoardlotDate.ToString("yyyy-MM-dd");
                dr[17] = s.NextYearCheckDate.ToString("yyyy-MM-dd");
                dr[18] = s.InsuranceEndDate.ToString("yyyy-MM-dd");
                dr[19] = s.MainRoute;
                dr[20] = s.LoadWeight;
                dr[21] = s.LoadPerson;
                dr[22] = s.Size;
                dr[23] = s.TotalWeight;
                dr[24] = s.TractionWeight;
                dr[25] = s.SafetyBeltAmount;
                dr[26] = s.BackUpBuzze == true ? "有" : "无";
                dr[27] = s.TheTankerOilSpillProtectionDevice == true ? "有" : "无";
                dr[28] = s.OilSpillPreventiontools == true ? "有" : "无";
                dr[29] = s.ReflectBar == true ? "有" : "无";
                dr[30] = s.HighSideStopLamps == true ? "有" : "无";
                dr[31] = s.DangerousMark == true ? "有" : "无";
                dr[32] = s.BackProtection == true ? "有" : "无";
                dr[33] = s.ThreePointBelt == true ? "有" : "无";
                dr[34] = s.RolloverProtect == true ? "有" : "无";
                dr[35] = s.ABS == true ? "有" : "无";
                dr[36] = s.CarriageScope == true ? "有" : "无";
                dr[37] = s.AirbagAmount;
                dr[38] = s.CarType;
                dr[39] = s.TrailerNo;
                dr[40] = s.TrailerLoadWeight;  
                dr[41] = s.TrailerSize;
                dr[42] = s.TrailerTotalWeight;
                dr[43] = s.TrailerEntireWeight;
                dr[44] = s.TrailerTypeNo;
                dr[45] = s.TrailerBoardlotDate;
                dr[46] = s.TrailerVin;
                dr[47] = s.TrailerNextYearCheckDate;
                dt.Rows.Add(dr);
            }); 

            return this.ExportDataTableToExcel(dt, "Vehicle.xls");
        }
        //导入Excel
        private ActionResult ExportDataTableToExcel(DataTable dt, string FileName)
        {
            var sbHtml = new StringBuilder();
            sbHtml.Append("<style>td{mso-number-format:\"\\@\";}</style>");
            sbHtml.Append("<table border='1' cellspacing='0' cellpadding='0'>");
            sbHtml.Append("<tr>");
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", dt.Columns[i].ColumnName);
            }

            sbHtml.Append("</tr>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sbHtml.Append("<tr>");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", dt.Rows[i][j].ToString());
                }
                sbHtml.Append("</tr>");
            }

            sbHtml.Append("</table>");
            Response.Charset = "UTF-8";
            Response.HeaderEncoding = Encoding.UTF8;
            Response.AppendHeader("content-disposition", "attachment;filename=" + FileName);
            Response.ContentEncoding = Encoding.UTF8;
            Response.ContentType = "application/ms-excel";
            Response.Write("<meta http-equiv='content-type' content='application/ms-excel; charset=UTF-8'/>" + sbHtml.ToString());
            Response.Flush();
            Response.End();
            return new EmptyResult();
        }



        [HttpGet]
        public ActionResult CreateOrUpdate(string id, int? type)
        {
            VehicleIndexViewModel vi = new VehicleIndexViewModel();
            if (string.IsNullOrEmpty(id))
            {
                Vehicle v = new Vehicle();
                v.CarBodyPhoto = Guid.NewGuid().ToString();
                v.CarFrontPhoto = Guid.NewGuid().ToString();
                v.CarBackPhoto = Guid.NewGuid().ToString();
                v.CarFloorPhoto = Guid.NewGuid().ToString();
                vi.Vehicle = v;
                vi.ViewType = 0;
            }
            else
            {
                if (type == 1)
                {
                    var response = new VehicleService().GetSearchVehicle(id);
                    vi.Vehicle = response;
                    vi.ViewType = 1;
                }
                else
                {
                    var response = new VehicleService().GetSearchVehicle(id);
                    vi.Vehicle = response;
                    vi.ViewType = 0;
                }

            }

            
            return View(vi);
        }
        /// <summary>
        /// type 0 添加 1 查看  3 修改 
        /// </summary>
        /// <param name="vi"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateOrUpdate(VehicleIndexViewModel vi)
        {
            if (vi.ViewType == 1) 
            {
                vi.Vehicle.CreateUser = base.UserInfo.ID.ToString();
                vi.Vehicle.CreateTime = DateTime.Now; 
            }
            vi.Vehicle.UpdateUser = base.UserInfo.ID.ToString();
            vi.Vehicle.UpdateTime = DateTime.Now;

            var response = new VehicleService().AddOrUpdateVehicles(new AddOrUpdateVehicleRequest()
            {
                VehicleCollection = new List<Vehicle> { vi.Vehicle}
                

            });
            vi.ViewType = 1;
            return View(vi);
        }


        //删除
        [HttpPost]
        public JsonResult DeleteCRMVehicle(string id)
        {
            bool response = new VehicleService().DeleteVehicle(id);
            
            if (response)
            {
                return Json(new { Message = "删除成功", IsSuccess = true });
            }
            else
            {
                return Json(new { Message = "删除失败，请联系IT", IsSuccess = false });
            }
        }

    }
}
