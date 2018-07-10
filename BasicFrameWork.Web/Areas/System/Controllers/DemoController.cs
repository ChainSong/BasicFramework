using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BasicFramework.Common;
using BasicFramework.Entity;
using BasicFramework.Web.Areas.System.Models;
using BasicFramework.Web.Common;
using MyFile = System.IO.File;

namespace BasicFramework.Web.Areas.System.Controllers
{
    public class DemoController : BaseController
    {
        public ActionResult Demo()
        {
            //ViewBag.___IsReadonly___ = true;
            DemoViewModel vm = new DemoViewModel();
            int pageCount;
            int pageCountSecond;
            vm.DemoPagerViewModel = DemoPagerViewModel.GetList(0, 5, out pageCount);
            vm.DemoPagerViewModel_Second = DemoPagerViewModel.GetList(0, 5, out pageCountSecond);
            ViewBag.FirstPageCount = pageCount;
            ViewBag.FirstPageIndex = 0;
            ViewBag.PageCountSecond = pageCountSecond;
            ViewBag.PageIndexSecond = 0;
            return View(vm);
        }

        [HttpPost]
        public ActionResult Demo(DemoViewModel vm, int? FirstPageIndex, int? SecondPageIndex)
        {
            int pageIndex = FirstPageIndex.HasValue ? FirstPageIndex.Value : 0;
            int pageIndexSecond = SecondPageIndex.HasValue ? SecondPageIndex.Value : 0;
            int pageCount;
            int pageCountSecond;
            vm.DemoPagerViewModel = DemoPagerViewModel.GetList(pageIndex, 5, out pageCount);
            vm.DemoPagerViewModel_Second = DemoPagerViewModel.GetList(pageIndexSecond, 5, out pageCountSecond);
            ViewBag.FirstPageCount = pageCount;
            ViewBag.FirstPageIndex = pageIndex;
            ViewBag.PageCountSecond = pageCountSecond;
            ViewBag.PageIndexSecond = pageIndexSecond;
            return View(vm);
        }

        [HttpPost]
        public string ExcelInput()
        {
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase hpf = Request.Files[0] as HttpPostedFileBase;
                if (hpf.ContentLength > 0)
                {
                    string uploadFolderPath = BasicFramework.Common.Constants.UPLOAD_FOLDER_PATH;
                    string targetPath = Path.Combine(uploadFolderPath, "1", "Temp");

                    if (!Directory.Exists(targetPath))
                    {
                        Directory.CreateDirectory(targetPath);
                    }

                    string fileName = base.UserInfo.ID.ToString() + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + Path.GetFileName(hpf.FileName);
                    string fullPath = Path.Combine(targetPath, fileName);

                    hpf.SaveAs(fullPath);
                    hpf.InputStream.Close();

                    ExcelHelper excelHelper = new ExcelHelper(fullPath);
                    DataSet ds = excelHelper.GetAllDataFromAllSheets();
                    excelHelper.Dispose();

                    MyFile.Delete(fullPath);

                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        Session["ExcelInput"] = ds.Tables[0];
                        return ds.Tables[0].ConvertToEntityCollection<BasicFramework.Entity.User>().ToJsonString();
                    }
                }
            }

            throw new Exception("没有文件读取");
        }

        public ActionResult ExportToExcel()
        {
            DataTable dt = Session["ExcelInput"] as DataTable;

            try
            {
                if (dt != null)
                {
                    ExcelHelper excelHelper = new ExcelHelper();
                    string targetPath = Path.Combine(BasicFramework.Common.Constants.UPLOAD_FOLDER_PATH, "1", "Temp");

                    string fileFullPath = Path.Combine(targetPath, "DataInExcel.xlsx");

                    excelHelper.CreateExcelByDataTable(fileFullPath, dt);

                    excelHelper.Dispose();

                    string mimeType = "application/msexcel";

                    FileStream fs = MyFile.Open(fileFullPath, FileMode.Open);

                    return File(fs, mimeType, "DataInExcel.xlsx");
                }

                return RedirectToAction("Error", new { msg = "请重新登录" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { msg = ex.Message });
            }
        }

        //ReportDemo
        public ActionResult ReportDemo()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ShowMap()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetData()
        {
            IList<Map> mapList = new List<Map>()
            {
                new Map(){CenterLat = 112.3579643582M, CenterLng=31.1376622409M,Zoom=8,Title="上海虹迪物流科技有限公司"},
                new Map(){ CenterLat=116.5588026064M, CenterLng=39.857843146M, Zoom=8,Title="北京虹迪"}
            };

            StringBuilder str = new StringBuilder();
            foreach (Map map in mapList)
            {
                str.Append(string.Format("{0},{1},{2},{3};",
                       map.CenterLat,
                       map.CenterLng,
                       map.Zoom,
                       map.Title
                      ));
            }
            return Json(str.ToString(), JsonRequestBehavior.AllowGet);
        }

        //public FileResult File()
        //{
        //    ReportViewer rv = new Microsoft.Reporting.WebForms.ReportViewer();
        //    rv.ProcessingMode = ProcessingMode.Local;
        //    rv.LocalReport.ReportPath = Server.MapPath("~/Reports/TestReport.rdlc");
        //    rv.LocalReport.Refresh();

        //    byte[] streamBytes = null;
        //    string mimeType = "";
        //    string encoding = "";
        //    string filenameExtension = "";
        //    string[] streamids = null;
        //    Warning[] warnings = null;

        //    streamBytes = rv.LocalReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);

        //    return File(streamBytes, mimeType, "TestReport.pdf");
        //}
    }

    public class DemoViewModel
    {
        public DateTime DateTime1
        {
            get
            {
                return DateTime.Now;
            }
        }

        public DateTime? DateTime2 { get; set; }

        public IEnumerable<DemoPagerViewModel> DemoPagerViewModel { get; set; }

        public IEnumerable<DemoPagerViewModel> DemoPagerViewModel_Second { get; set; }
    }
}