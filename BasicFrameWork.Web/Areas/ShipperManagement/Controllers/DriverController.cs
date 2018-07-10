using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BasicFramework.Biz.ShipperManagement;
using BasicFramework.Common;
using BasicFramework.Entity.ShipperManagement.DriverManagement;
using BasicFramework.MessageContracts.ShipperManagement.DriverManagement;
using BasicFramework.MessageContracts.ShipperManagement.VehicleManagement;
using BasicFramework.Web.Areas.ShipperManagement.Models;
using BasicFramework.Web.Common;
using UtilConstants = BasicFramework.Common.Constants;

namespace BasicFramework.Web.Areas.ShipperManagement.Controllers
{
    public class DriverController : BaseController
    {
        //
        // GET: /ShipperManagement/DriverManagement/
        [HttpGet]
        public ActionResult Index(string CarNo)
        {
            DriverIndexViewModel di = new DriverIndexViewModel();
            di.Driver = new Driver();
            DriverSearchCondition sc = new DriverSearchCondition();
            di.SearchCondition = sc;


            if (!string.IsNullOrEmpty(CarNo))
            {
                sc.DriverCarNo = CarNo;
                var response = new DriverService().GetDriverView(new VehicleMappingDriverRequest() { VehicleNo = CarNo });

                di.CRMDriverCollection = response.Result.DriverCollection;
                di.PageIndex = response.Result.PageIndex;
                di.PageCount = response.Result.PageCount;

            }
            else
            {

                var result = new DriverService().GetDriverByCondition(new GetDriverByConditionRequest()
                {
                    SearchCondition = di.SearchCondition,
                    PageSize = UtilConstants.PAGESIZE,
                    PageIndex = 0,
                });

                if (result.IsSuccess)
                {
                    di.CRMDriverCollection = result.Result.DriverCollection;
                    di.UserID = base.UserInfo.ID.ToString();
                    di.PageIndex = result.Result.PageIndex;
                    di.PageCount = result.Result.PageCount;
                }
            }

            //else
            //{
            //    di.SearchCondition = new DriverSearchCondition();
            //} 
            return View(di);
        }



        [HttpPost]
        public ActionResult Index(DriverIndexViewModel di, string Action)
        {
            //查询导出
            var request = new GetDriverByConditionRequest();
            
            if (Action == "查询" || Action == "Index")
            {
                request.SearchCondition = di.SearchCondition;
                request.PageSize = UtilConstants.PAGESIZE;
                request.PageIndex = di.PageIndex;
                di.ShowEditButton = false;
                di.ShowEditButton = true;
            }
            else if (Action == "导出")
            {
                request.SearchCondition = di.SearchCondition;
                request.PageSize = 0;
                request.PageIndex = 0;
            }
            var response = new DriverService().GetDriverByCondition(request);
           
            if (response.IsSuccess)
            {
                
                if (Action == "导出")
                {
                    return this.Export(response.Result.DriverCollection);
                }
                else
                {
                    di.CRMDriverCollection = response.Result.DriverCollection;
                    di.PageIndex = response.Result.PageIndex;
                    di.PageCount = response.Result.PageCount;
                }

            }
            return View(di);
        }

        //导出
        private ActionResult Export(IEnumerable<Driver> crmDrivers)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("司机姓名", typeof(string));
            dt.Columns.Add("出生日期", typeof(string));
            dt.Columns.Add("联系电话", typeof(string));
            dt.Columns.Add("开始为虹迪服务日期", typeof(string));
            dt.Columns.Add("身份证号码", typeof(string));
            dt.Columns.Add("物流公司", typeof(string));
            dt.Columns.Add("物流公司联系人", typeof(string));
            dt.Columns.Add("物流公司联系电话", typeof(string));
            dt.Columns.Add("驾驶证档案号", typeof(string));
            dt.Columns.Add("驾照类型", typeof(string));
            dt.Columns.Add("是否在服务中", typeof(string));
            dt.Columns.Add("驾驶车辆牌号", typeof(string));
            dt.Columns.Add("司机登记号", typeof(string));
            dt.Columns.Add("登记证签发地", typeof(string));
            dt.Columns.Add("下次年审日期", typeof(string));
            dt.Columns.Add("初次驾照领证日期", typeof(string));
            dt.Columns.Add("下次体检日期", typeof(string));
            dt.Columns.Add("服务区域", typeof(string));
            dt.Columns.Add("主要行驶路线", typeof(string));

            crmDrivers.Each((i, s) =>
            {
                DataRow dr = dt.NewRow();
                dr[0] = s.DriverName;
                dr[1] = s.DriverBirthday.ToString("yyyy-MM-dd");
                dr[2] = s.DriverPhone;
                dr[3] = s.DriverStartServeForRunbowDate.ToString("yyyy-MM-dd");
                dr[4] = s.DriverIDCard;
                dr[5] = s.DriverLogisticsCompany;
                dr[6] = s.DriverLogisticsContactPerson;
                dr[7] = s.DriverLogisticsCompanyContactPhone;
                dr[8] = s.DriverCardNo;
                dr[9] = s.DriverCardType;
                dr[10] = s.DriverIsServing == true ? "是" : "否";
                //dr[10] = s.DriverIsServing;
                dr[11] = s.DriverCarNo;
                dr[12] = s.DriverRegistrationNo;
                dr[13] = s.DriverRegistrationCardSignedAddress;
                dr[14] = s.DriverNextYearCheckDate.ToString("yyyy-MM-dd");
                dr[15] = s.DriverFirstTimeGetCardDate.ToString("yyyy-MM-dd");
                dr[16] = s.DriverNextYearCheckBodyDate.ToString("yyyy-MM-dd");
                dr[17] = s.DriverServiceArea;
                dr[18] = s.DriverMainRoute;
                dt.Rows.Add(dr);
            });

            return this.ExportDataTableToExcel(dt, "Driver.xls"); 
        }

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


        //点击id显示信息
        [HttpGet]
        public ActionResult CreateOrUpdate(string id, int? type)
        {
            DriverIndexViewModel vi = new DriverIndexViewModel();
            if (string.IsNullOrEmpty(id))
            {
                Driver v = new Driver();
                v.Str1 = Guid.NewGuid().ToString();
                v.Str2 = Guid.NewGuid().ToString();
                v.Str3 = Guid.NewGuid().ToString();
                v.Str4 = Guid.NewGuid().ToString();
                v.DriverIsServing = true;
                vi.Driver = v;
                vi.ViewType = 0;
            }
            else 
            {
                if (type == 1)
                {
                    var response = new DriverService().GetSearcheDriver(id);
                    vi.Driver = response;
                    vi.ViewType = 1;
                }
                else
                {
                    var response = new DriverService().GetSearcheDriver(id);
                    vi.Driver = response;
                    vi.ViewType = 0;
                }
            }
            return View(vi);
        }


        /// <summary>
        /// type 0 添加 1 查询  3 修改 
        /// </summary>
        /// <param name="vi"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateOrUpdate(DriverIndexViewModel vi)
        {
            if (vi.ViewType == 1) 
            {
                vi.Driver.CreateUser = base.UserInfo.ID.ToString();
                vi.Driver.CreateTime = DateTime.Now;
            }
            vi.Driver.UpdateUser = base.UserInfo.ID.ToString();
            vi.Driver.UpdateTime = DateTime.Now;


            var response = new DriverService().AddOrUpdateDriver(new AddOrUpdateDriverRequest()
            {
                DriverCollection = new List<Driver> { vi.Driver}
            });
            vi.ViewType = 1;
            return View(vi);
        }


        [HttpPost]
        public JsonResult DeleteCRMDriver(string id)
        {
            bool response = new DriverService().DeleteCRMDriver(id);
            //var response = new VehicleManagementService().DeleteCRMVehicle(id);
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
