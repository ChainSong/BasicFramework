using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BasicFramework.Biz;
using BasicFramework.Entity;
using BasicFramework.MessageContracts;
using UtilConstants = BasicFramework.Common.Constants;
using BasicFramework.Web.Areas.ShipperManagement.Models;
using BasicFramework.Common;
using System.Text;
using BasicFramework.Web.Common;
using System.Data;
using BasicFramework.Biz.ShipperManagement;
using BasicFramework.MessageContracts.ShipperManagement.VehicleManagement;
using System.Web.Script.Serialization;
using BasicFramework.MessageContracts.ShipperManagement;
using BasicFramework.Entity.ShipperManagement;

namespace BasicFramework.Web.Areas.ShipperManagement.Controllers
{
    public class ShipperController : BaseController
    {
        public ActionResult Index( )
        {
            ShipperIndexViewModel vm = new ShipperIndexViewModel();

            ShipperSearchCondition ss = new ShipperSearchCondition();
            vm.ShipperSearchCondition = ss;

            //vm.PageIndex = 0;
            //vm.PageCount = 0;
            vm.ShowEditButton = true;
           
            //if (useSession.HasValue && useSession.Value)
            //{

                //if (Session["ShipperCRM_SearchCondition"] != null)
                //{
                //    vm.ShipperSearchCondition = (ShipperSearchCondition)Session["ShipperCRM_SearchCondition"];
                //    vm.PageIndex = Session["ShipperCRM_PageIndex"] != null ? (int)Session["ShipperCRM_PageIndex"] : 0;
                    
                    //bukan
                    if (!string.IsNullOrEmpty(vm.ShipperSearchCondition.TransportMode))
                    {
                        IList<SelectListItem> selectedtransportModeTypes = new List<SelectListItem>();
                        vm.ShipperSearchCondition.TransportMode.Split('|').Each((i, s) =>
                        {
                            selectedtransportModeTypes.Add(new SelectListItem() { Text = s, Value = s });
                        });

                        vm.SelectedTransportModes = selectedtransportModeTypes;
                    }

                    if (!string.IsNullOrEmpty(vm.ShipperSearchCondition.ProductType))
                    {
                        IList<SelectListItem> selectedProductTypes = new List<SelectListItem>();
                        vm.ShipperSearchCondition.ProductType.Split('|').Each((i, s) =>
                        {
                            selectedProductTypes.Add(new SelectListItem() { Text = s, Value = s });
                        });

                        vm.SelectedProductTypes = selectedProductTypes;
                    }
                
                //else
                //{
                //    vm.ShipperSearchCondition = new ShipperSearchCondition();
                //    vm.PageIndex = 0;
                //}

                var getCRMShippersByConditionResponse = new ShipperManagementService().GetShippersByCondition(new GetShippersByConditionRequest()
                {
                    SearchCondition = vm.ShipperSearchCondition,
                    PageSize = UtilConstants.PAGESIZE,
                    PageIndex = vm.PageIndex,
                });

                if (getCRMShippersByConditionResponse.IsSuccess)
                {
                    vm.ShipperCollection = getCRMShippersByConditionResponse.Result.ShipperCollection;
                    vm.PageIndex = getCRMShippersByConditionResponse.Result.PageIndex;
                    vm.PageCount = getCRMShippersByConditionResponse.Result.PageCount;
                }
          
            //else
            //{
            //    vm.ShipperSearchCondition = new ShipperSearchCondition();
            //}
                        
            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(ShipperIndexViewModel vm, int? PageIndex, string Action)
        {
            if (vm.PostedTransportModes != null && vm.PostedTransportModes.Any())
            {
                StringBuilder transportModeSB = new StringBuilder();
                vm.PostedTransportModes.Each((i, s) =>
                {
                    transportModeSB.Append(s).Append("|");
                });
                transportModeSB.Remove(transportModeSB.Length - 1, 1);
                vm.ShipperSearchCondition.TransportMode = transportModeSB.ToString();
            }

            if (vm.PostedProductTypes != null && vm.PostedProductTypes.Any())
            {
                StringBuilder postedProductTypesSB = new StringBuilder();
                vm.PostedProductTypes.Each((i, s) =>
                {
                    postedProductTypesSB.Append(s).Append("|");
                });
                postedProductTypesSB.Remove(postedProductTypesSB.Length - 1, 1);
                vm.ShipperSearchCondition.ProductType = postedProductTypesSB.ToString();
            }
            //查询导出
            var getCRMShippersByConditionRequest = new GetShippersByConditionRequest();

            if (Action == "查询" || Action== "Index")
            {
                getCRMShippersByConditionRequest.SearchCondition = vm.ShipperSearchCondition;
                getCRMShippersByConditionRequest.PageSize = UtilConstants.PAGESIZE;
                getCRMShippersByConditionRequest.PageIndex = PageIndex ?? 0;
            }
            else if (Action == "导出")
            {
                getCRMShippersByConditionRequest.SearchCondition = vm.ShipperSearchCondition;
                getCRMShippersByConditionRequest.PageSize = 0;
                getCRMShippersByConditionRequest.PageIndex = 0;
            }

            var getCRMShippersByConditionResponse = new ShipperManagementService().GetShippersByCondition(getCRMShippersByConditionRequest);
           

            if (getCRMShippersByConditionResponse.IsSuccess)
            {
                if (!string.IsNullOrEmpty(vm.ShipperSearchCondition.TransportMode))
                {
                    IList<SelectListItem> selectedtransportModeTypes = new List<SelectListItem>();
                    vm.ShipperSearchCondition.TransportMode.Split('|').Each((i, s) =>
                    {
                        selectedtransportModeTypes.Add(new SelectListItem() { Text = s, Value = s });
                    });

                    vm.SelectedTransportModes = selectedtransportModeTypes;
                }

                if (!string.IsNullOrEmpty(vm.ShipperSearchCondition.ProductType))
                {
                    IList<SelectListItem> selectedProductTypes = new List<SelectListItem>();
                    vm.ShipperSearchCondition.ProductType.Split('|').Each((i, s) =>
                    {
                        selectedProductTypes.Add(new SelectListItem() { Text = s, Value = s });
                    });

                    vm.SelectedProductTypes = selectedProductTypes;
                }

                vm.ShipperCollection = getCRMShippersByConditionResponse.Result.ShipperCollection;
                vm.PageIndex = getCRMShippersByConditionResponse.Result.PageIndex;
                vm.PageCount = getCRMShippersByConditionResponse.Result.PageCount;
                Session["ShipperCRM_SearchCondition"] = vm.ShipperSearchCondition;
                Session["ShipperCRM_PageIndex"] = vm.PageIndex;

                if (Action == "导出")
                {
                    return this.Export(getCRMShippersByConditionResponse.Result.ShipperCollection);
                }
            }

            return View(vm);
        }
        
        private ActionResult Export(IEnumerable<Shipper> crmShippers)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("归属区域", typeof(string));
            dt.Columns.Add("合作项目", typeof(string));
            dt.Columns.Add("企业名称", typeof(string));
            dt.Columns.Add("合同起始日期", typeof(string));
            dt.Columns.Add("合同结束日期", typeof(string));
            dt.Columns.Add("实际终止合作日期", typeof(string));
            dt.Columns.Add("是否有保单", typeof(string));
            dt.Columns.Add("投保公司", typeof(string));
            dt.Columns.Add("购买险种", typeof(string));
            dt.Columns.Add("保额", typeof(string));
            dt.Columns.Add("有效期限", typeof(string));
            dt.Columns.Add("六证", typeof(string));
            dt.Columns.Add("承运商注册资金", typeof(string));
            dt.Columns.Add("说明", typeof(string));

            crmShippers.Each((i, s) => {
                DataRow dr = dt.NewRow();
                dr[0] = s.Attribution;
                dr[1] = s.Str2;
                dr[2] = s.Name;
                dr[3] = s.DateTime1.HasValue ? s.DateTime1.Value.DateTimeToString() : "";
                dr[4] = s.DateTime2.HasValue ? s.DateTime2.Value.DateTimeToString() : "";
                dr[5] = s.DateTime3.HasValue ? s.DateTime3.Value.DateTimeToString() : "";
                dr[6] = s.Str4;
                dr[7] = s.InsuranceCompanies;
                dr[8] = s.InsuranceType;
                dr[9] = s.SumInsured;
                dr[10] = s.ValidityPeriod;
                dr[11] = s.SixCard;
                dr[12] = s.RegisteredCapital;
                dr[13] = s.Remark;
                dt.Rows.Add(dr);
            });

            return this.ExportDataTableToExcel(dt, "Shipper.xls");
        }
        //
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

        public ActionResult CreateOrUpdate(long? id, int? ViewType)
        {
            ShipperCreateOrUpdateViewModel vm = new ShipperCreateOrUpdateViewModel();

            if (!id.HasValue)
            {
                vm.ViewType = 1;
                vm.Shipper = new Shipper();
                vm.Shipper.AttachmentGroupID = Guid.NewGuid().ToString();
                vm.Shipper.Str3 = Guid.NewGuid().ToString();
            }
            else
            {
                var getCRMShipperResponse = new ShipperManagementService().GetCRMShipperInfo(new CRMShipperOperationRequest() { CRMShipperID = id });
                if (getCRMShipperResponse.IsSuccess)
                {
                    vm.Shipper = getCRMShipperResponse.Result.Shipper;
                    if (vm.Shipper == null)
                    {
                        vm.Shipper = new Shipper();
                    }

                    if (!string.IsNullOrEmpty(vm.Shipper.DeliveryOfVehicleType))
                    {
                        IList<SelectListItem> selectedDeliveryOfVehicleTypes = new List<SelectListItem>();
                        vm.Shipper.DeliveryOfVehicleType.Split('|').Each((i, s) => {
                            selectedDeliveryOfVehicleTypes.Add(new SelectListItem() { Text = s, Value = s });
                        });
                        vm.SelectedDeliveryOfVehicleTypes = selectedDeliveryOfVehicleTypes;
                    }

                    if (!string.IsNullOrEmpty(vm.Shipper.SixCard))
                    {
                        IList<SelectListItem> selectedSixCards = new List<SelectListItem>();
                        vm.Shipper.SixCard.Split('|').Each((i, s) =>
                        {
                            selectedSixCards.Add(new SelectListItem() { Text = s, Value = s });
                        });
                        vm.SelectedSixCards = selectedSixCards;
                    }

                    if (!string.IsNullOrEmpty(vm.Shipper.TermialOfVehicleType))
                    {
                        IList<SelectListItem> selectedTermialOfVehicleTypes = new List<SelectListItem>();
                        vm.Shipper.TermialOfVehicleType.Split('|').Each((i, s) =>
                        {
                            selectedTermialOfVehicleTypes.Add(new SelectListItem() { Text = s, Value = s });
                        });
                        vm.SelectedTermialOfVehicleTypes = selectedTermialOfVehicleTypes;
                    }

                    if (!string.IsNullOrEmpty(vm.Shipper.TransportMode))
                    {
                        IList<SelectListItem> selectedTransportModes = new List<SelectListItem>();
                        vm.Shipper.TransportMode.Split('|').Each((i, s) =>
                        {
                            selectedTransportModes.Add(new SelectListItem() { Text = s, Value = s });
                        });
                        vm.SelectedTransportModes = selectedTransportModes;
                    }

                    if (!string.IsNullOrEmpty(vm.Shipper.TrunkOfVehicleType))
                    {
                        IList<SelectListItem> selectedTrunkOfVehicleTypes = new List<SelectListItem>();
                        vm.Shipper.TrunkOfVehicleType.Split('|').Each((i, s) =>
                        {
                            selectedTrunkOfVehicleTypes.Add(new SelectListItem() { Text = s, Value = s });
                        });
                        vm.SelectedTrunkOfVehicleTypes = selectedTrunkOfVehicleTypes;
                    }

                    vm.ShipperCooperationCollection = getCRMShipperResponse.Result.ShipperCooperationCollection;
                    vm.ShipperTransportationLineCollection = getCRMShipperResponse.Result.ShipperTransportationLineCollection;
                    vm.ShipperTerminalInfoCollection = getCRMShipperResponse.Result.ShipperTerminalInfoCollection;

                    if (string.IsNullOrEmpty(vm.Shipper.Str3))
                    {
                        vm.Shipper.Str3 = Guid.NewGuid().ToString();
                    }

                    if (string.IsNullOrEmpty(vm.Shipper.AttachmentGroupID))
                    {
                        vm.Shipper.AttachmentGroupID = Guid.NewGuid().ToString();
                    }

                }    

                if (!ViewType.HasValue)
                {
                    vm.ViewType = 0;
                }
                else
                {
                    vm.ViewType = ViewType.Value; 
                }

                vm.ShowEditButton = true;

            }

            return View(vm);
        }

        [HttpPost]
        public ActionResult CreateOrUpdate(ShipperCreateOrUpdateViewModel vm)
        {
            if (vm.PostedDeliveryOfVehicleTypes != null && vm.PostedDeliveryOfVehicleTypes.Any())
            {
                StringBuilder deliveryOfVehicleSB = new StringBuilder();
                vm.PostedDeliveryOfVehicleTypes.Each((i, s) => {
                    deliveryOfVehicleSB.Append(s).Append("|");
                });
                deliveryOfVehicleSB.Remove(deliveryOfVehicleSB.Length - 1, 1);
                vm.Shipper.DeliveryOfVehicleType = deliveryOfVehicleSB.ToString();
            }

            if (vm.PostedSixCards != null && vm.PostedSixCards.Any())
            {
                StringBuilder sixCardsSB = new StringBuilder();
                vm.PostedSixCards.Each((i, s) =>
                {
                    sixCardsSB.Append(s).Append("|");
                });
                sixCardsSB.Remove(sixCardsSB.Length - 1, 1);
                vm.Shipper.SixCard = sixCardsSB.ToString();
            }

            if (vm.PostedTermialOfVehicleTypes != null && vm.PostedTermialOfVehicleTypes.Any())
            {
                StringBuilder termialOfVehicleTypeSB = new StringBuilder();
                vm.PostedTermialOfVehicleTypes.Each((i, s) =>
                {
                    termialOfVehicleTypeSB.Append(s).Append("|");
                });
                termialOfVehicleTypeSB.Remove(termialOfVehicleTypeSB.Length - 1, 1);
                vm.Shipper.TermialOfVehicleType = termialOfVehicleTypeSB.ToString();
            }

            if (vm.PostedTransportModes != null && vm.PostedTransportModes.Any())
            {
                StringBuilder transportModesSB = new StringBuilder();
                vm.PostedTransportModes.Each((i, s) =>
                {
                    transportModesSB.Append(s).Append("|");
                });
                transportModesSB.Remove(transportModesSB.Length - 1, 1);
                vm.Shipper.TransportMode = transportModesSB.ToString();
            }


            if (vm.PostedTrunkOfVehicleTypes != null && vm.PostedTrunkOfVehicleTypes.Any())
            {
                StringBuilder trunkOfVehicleTypesSB = new StringBuilder();
                vm.PostedTrunkOfVehicleTypes.Each((i, s) =>
                {
                    trunkOfVehicleTypesSB.Append(s).Append("|");
                });
                trunkOfVehicleTypesSB.Remove(trunkOfVehicleTypesSB.Length - 1, 1);
                vm.Shipper.TrunkOfVehicleType = trunkOfVehicleTypesSB.ToString();
            }
            //创建时间，创建人，更新时间，更新人
            if (vm.ViewType == 1)
            {
                vm.Shipper.Creator = base.UserInfo.Name;
                vm.Shipper.CreateTime = DateTime.Now;
            }

            vm.Shipper.UpdateTime = DateTime.Now;
            vm.Shipper.Updator = base.UserInfo.Name;      
            //
            var insertOrUpdateCRMShipperResponse = new ShipperManagementService().AddOrUpdateShippers(new AddOrUpdateCRMShippersRequest()
            {
                ShipperCollection = new List<Shipper> { vm.Shipper }
            });


            // 插入更新结果如果成功
            if (insertOrUpdateCRMShipperResponse.IsSuccess)
            {
                if (insertOrUpdateCRMShipperResponse.Result != null && insertOrUpdateCRMShipperResponse.Result.Any())
                {
                    long id = insertOrUpdateCRMShipperResponse.Result.First();
                    var getCRMShipperResponse = new ShipperManagementService().GetCRMShipperInfo(new CRMShipperOperationRequest() { CRMShipperID = id });
                    if (getCRMShipperResponse.IsSuccess)
                    {
                        vm.ViewType = 0;
                        vm.Shipper = getCRMShipperResponse.Result.Shipper;
                        vm.ShipperCooperationCollection = getCRMShipperResponse.Result.ShipperCooperationCollection;
                        vm.ShipperTransportationLineCollection = getCRMShipperResponse.Result.ShipperTransportationLineCollection;
                        return View(vm);
                    }
                }
            }
            return View(vm);
        }


        //删除 JsonResult
        [HttpPost]
        public JsonResult DeleteCRMShipper(long id)
        {
            var response = new ShipperManagementService().DeleteCRMShipper(new CRMShipperOperationRequest() { CRMShipperID = id });
            if (response.IsSuccess)
            {
                return Json(new { Message = "删除成功", IsSuccess = true });
            }
            else
            {
               return Json(new { Message = "删除失败，请联系IT", IsSuccess = false });
            }
        }
        // 不看
        [HttpPost]
        public ActionResult DeleteCRMShipperTerminalInfo(long id)
        {
            var response = new ShipperManagementService().DeleteCRMShipperTerminalInfo(new CRMShipperOperationRequest() { CRMShipperTerminalInfoID = id });
            if (response.IsSuccess)
            {
                return Json(new { Message = "删除成功", IsSuccess = true });
            }
            else
            {
                return Json(new { Message = "删除失败，请联系IT", IsSuccess = false });
            }
        }
        //不看
        [HttpPost]
        public ActionResult DeleteCRMShipperTransportationLine(long id)
        {
            var response = new ShipperManagementService().DeleteCRMShipperTransportationLine(new CRMShipperOperationRequest() { CRMShipperTransportationLineID = id });
            if (response.IsSuccess)
            {
                return Json(new { Message = "删除成功", IsSuccess = true });
            }
            else
            {
                return Json(new { Message = "删除失败，请联系IT", IsSuccess = false });
            }
        }

        public ActionResult InsertCRMShipperTransportationLine(long id, string StartPlaceID, string StartPlaceName, string EndPlaceID, string EndPlaceName,string CoverRegionID, string CoverRegionName, int Period)
        {
            var startPlaceIDArray = StartPlaceID.Split(',');
            var startPlaceNameArray = StartPlaceName.Split(',');
            var endPlaceIDArray = EndPlaceID.Split(',');
            var endPlaceNameArray = EndPlaceName.Split(',');
            var coverRegionIDArray = CoverRegionID.Split(',');
            var coverRegionNameArray = CoverRegionName.Split(',');

            IList<ShipperTransportationLine> lines = new List<ShipperTransportationLine>();
            
            for (int i = 0; i < startPlaceIDArray.Length; i++)
            {
                for (int j = 0; j < endPlaceIDArray.Length; j++)
                {
                    for (int k = 0; k < coverRegionIDArray.Length; k++)
                    {
                        lines.Add(new ShipperTransportationLine()
                        {
                            ID = 0,
                            CRMShipperID = id,
                            StartCityID = startPlaceIDArray[i].ObjectToInt64(),
                            StartCityName = startPlaceNameArray[i],
                            EndCityID = endPlaceIDArray[j].ObjectToInt64(),
                            EndCityName = endPlaceNameArray[j],
                            CoverRegionID = coverRegionIDArray[k].ObjectToInt64(),
                            CoverRegionName = coverRegionNameArray[k],
                            Period = Period
                        });
                    }
                }
            }

            var response = new ShipperManagementService().AddOrUpdateCRMShipperTransportationLines(new AddOrUpdateCRMShipperTransportationLineRequest() { ShipperTransportationLineCollection = lines });

            if (response.IsSuccess)
            {
                return Json(new { Message = "新增成功", IsSuccess = true, Lines = response.Result.ToJsonString() }); 
            }

            return Json(new { Message = "新增线路失败，请联系IT", IsSuccess = false });
        }

        public ActionResult ShipperTransportationLine(long id, int? ViewType) 
        {
            ShipperTransportationLineViewModel vm = new ShipperTransportationLineViewModel();
            vm.CRMShipperID = id;
            vm.ViewType = ViewType ?? 0;

            var getCRMShipperTransportationLinesResponse = new ShipperManagementService().GetCRMShipperTransportationLines(new CRMShipperOperationRequest() { CRMShipperID = id });

            if (getCRMShipperTransportationLinesResponse.IsSuccess)
            {
                vm.ShipperTransportationLineCollection = getCRMShipperTransportationLinesResponse.Result;
            }

            return View(vm);
        }

        public ActionResult ShipperCooperation(long id, int? ViewType)
        {
            ShipperCooperationViewModel vm = new ShipperCooperationViewModel();
            vm.CRMShipperID = id;
            vm.ViewType = ViewType ?? 0;
            vm.AttachmentGroupID = Guid.NewGuid().ToString();

            var getCRMShipperCooperationsResponse = new ShipperManagementService().GetCRMShipperCooperations(new CRMShipperOperationRequest() { CRMShipperID = id });
            if (getCRMShipperCooperationsResponse.IsSuccess)
            {
                vm.CRMShipperCooperationCollection = getCRMShipperCooperationsResponse.Result;
            }

            return View(vm);
        }

        [HttpPost]
        public ActionResult DeleteCRMShipperCooperation(long id)
        {
            var response = new ShipperManagementService().DeleteCRMShipperCooperation(new CRMShipperOperationRequest() { CRMShipperCooperationID = id });
            if (response.IsSuccess)
            {
                return Json(new { Message = "删除成功", IsSuccess = true });
            }
            else
            {
                return Json(new { Message = "删除失败，请联系IT", IsSuccess = false });
            }
        }

        [HttpPost]
        public ActionResult ShipperCooperation(ShipperCooperationViewModel vm)
        {
            IList<ShipperCooperation> cooperations = new List<ShipperCooperation>();
            StringBuilder productTypesSB = new StringBuilder();
            if (vm.PostedProductTypes != null && vm.PostedProductTypes.Any())
            {
                vm.PostedProductTypes.Each((i, p) => { productTypesSB.Append(p).Append("|"); });
                productTypesSB.Remove(productTypesSB.Length - 1, 1);
            }

            cooperations.Add(new ShipperCooperation() { CRMShipperID = vm.CRMShipperID, Name = vm.Name, Remark = vm.Remark, AttachmentGroupID = vm.AttachmentGroupID,
                                                           Str1 = vm.Str1,
                                                           Str2 = vm.Str2,
                                                           Str3 = vm.Str3,
                                                           Str4 = vm.Str4,
                                                           Str5 = vm.Str5,
                                                           Str6 = vm.Str6,
                                                           Str7 = productTypesSB.ToString(),
                                                           Str8 = vm.Str8,
                                                           Str9 = vm.Str9,
                                                           Str10 = vm.Str10
            });

            new ShipperManagementService().AddOrUpdateCRMShipperCooperations(new AddOrUpdateCRMShipperCooperationsRequest() { ShipperCooperationCollection = cooperations });
            return RedirectToAction("ShipperCooperation", new { id = vm.CRMShipperID, ViewType = vm.ViewType });      
        }


        public ActionResult ShipperTerminalInfo(long id, int? ViewType)
        {
            ShipperTerminalInfoViewModel vm = new ShipperTerminalInfoViewModel();
            vm.CRMShipperID = id;
            vm.ViewType = ViewType ?? 0;

            var getCRMShipperTerminalInfoResponse = new ShipperManagementService().GetCRMShipperTerminalInfos(new CRMShipperOperationRequest() { CRMShipperID = id });
            if (getCRMShipperTerminalInfoResponse.IsSuccess)
            {
                vm.CRMShipperTerminalInfoCollection = getCRMShipperTerminalInfoResponse.Result;
            }

            return View(vm);
        }

        [HttpPost]
        public ActionResult ShipperTerminalInfo(ShipperTerminalInfoViewModel vm)
        {
            IList<ShipperTerminalInfo> terminalInfos = new List<ShipperTerminalInfo>();
            terminalInfos.Add(new ShipperTerminalInfo()
            {
                CRMShipperID = vm.CRMShipperID,
                TerminalAddress = vm.TerminalAddress,
                IsOwn = vm.IsOwn,
                TerminalOfficeArea = vm.TerminalOfficeArea,
                TerminalWareHouseArea = vm.TerminalWareHouseArea,
                TerminalWareHouseAreaRange = vm.TerminalWareHouseAreaRange,
                TerminalNumberOfEmployees = vm.TerminalNumberOfEmployees,
                TerminalNumberOfCustomerService = vm.TerminalNumberOfCustomerService,
                TerminalNumberOfStevedores = vm.TerminalNumberOfStevedores,
                TerminalForkliftsUsage = vm.TerminalForkliftsUsage,
                TerminalLoadingPlatform = vm.TerminalLoadingPlatform,
                TerminalDeliveryVehicles = vm.TerminalDeliveryVehicles,
                Str1 = vm.Str1,
                Str2 = vm.Str2,
                Str3 = vm.Str3,
                Str4 = vm.Str4,
                Str5 = vm.Str5,
            });

            new ShipperManagementService().AddOrUpdateCRMShipperTerminalInfos(new AddOrUpdateCRMShipperTerminalInfoRequest() { ShipperTerminalInfoCollection = terminalInfos });
            return RedirectToAction("ShipperTerminalInfo", new { id = vm.CRMShipperID, ViewType = vm.ViewType });      
        }


    //    //所有承运商和车辆 分页
    //    [HttpGet]
    //    public ActionResult ShipperVehicleMapping(string id,int? type)
    //    {
    //        ShipperVehicleMappingViewModel sv = new ShipperVehicleMappingViewModel()
    //        {
    //            Shipper = ApplicationConfigHelper.GetShipperList(),
    //            Vehicle = ApplicationConfigHelper.GetVehicleList()
    //        };


    //        int pagesize = 17;
    //        var response = new VehicleService().GetAllVehicle(new GetVehicleByConditionRequest() 
    //        {
                
    //            PageSize = pagesize,
    //            PageIndex = sv.PageIndex,
    //        });


    //        if (response.IsSuccess)
    //        {
    //            sv.Vehicle = response.Result.VehicleCollection;
    //            sv.PageIndex = response.Result.PageIndex;
    //            sv.PageCount = response.Result.PageCount;
    //        }

    //        return View(sv);
    //    }

   
    //    //查询
    //    public string SearchShipperVehicleMapping(string vehicleNo)//int? Index,  string Action
    //    {
    //        ShipperVehicleMappingViewModel sv = new ShipperVehicleMappingViewModel();
       
    //        sv.VehicleNo = vehicleNo;
    //        var request = new GetVehicleByConditionRequest();

    //         int pagesize = 17;
    //         request.PageIndex = sv.PageIndex;
    //         request.PageSize = pagesize;
    //         request.vehicleNo = vehicleNo;
            
    //        var response = new VehicleService().GetAllVehicle(request);

    //        if (response.IsSuccess)
    //        {
    //            sv.Vehicle = response.Result.VehicleCollection;
    //            sv.PageIndex = response.Result.PageIndex;
    //            sv.PageCount = response.Result.PageCount;
    //        }
    //        JavaScriptSerializer Serializer = new JavaScriptSerializer();
    //        string js = Serializer.Serialize(response);

    //        return js;
    //    }


    //    [HttpPost]
    //    public string ShipperVehicleMapping(string shipperName, string vehicleNo, long SID, int? Index)
    //    {
    //        ShipperVehicleMappingViewModel sv = new ShipperVehicleMappingViewModel();
    //        sv.PageIndex = Index??0;
    //        sv.SID = (SID);
    //        sv.ShipperName = shipperName;
    //        //sv.VehicleNo = vehicle;
            
            
    //        var request = new GetVehicleByConditionRequest();

    //         int pagesize = 17;
    //         request.PageIndex = sv.PageIndex;
    //         request.PageSize = pagesize;
    //         request.vehicleNo = vehicleNo;
            

    //        var response = new VehicleService().GetAllVehicle(request);

    //        if (response.IsSuccess)
    //        {
    //            sv.Vehicle = response.Result.VehicleCollection;
    //            sv.PageIndex = response.Result.PageIndex;
    //            sv.PageCount = response.Result.PageCount;
    //        }
    //        JavaScriptSerializer Serializer = new JavaScriptSerializer();
    //        string js = Serializer.Serialize(response);


    //        return js;
    //    }

    //    //

    //    //提交
    //    public bool AddShipperVehicleMapping(string shipper, string jsonStr)
    //    {

    //        var request = JsonToModel<CRMCar>(jsonStr);
    //        var response = new VehicleService().AddShipperToVehicle(new ShipperMappingVehicleRequest
    //        {
    //            car = request,
    //            ShipperName = shipper,

    //            UserName = base.UserInfo.Name
    //        });
    //        if (response == "操作成功")
    //            return true;
    //        else
    //            return false;
    //    }

    //    public static List<T> JsonToModel<T>(string jsonStr)
    //    {
    //        JavaScriptSerializer Serializer = new JavaScriptSerializer();
    //        return Serializer.Deserialize<List<T>>(jsonStr);
    //    }

    //    ////提交
    //    //public bool AddShipperToVehicle(string shippername, string vehicleno)
    //    //{
    //    //    ShipperToVehicleViewModel sv = new ShipperToVehicleViewModel();
    //    //    sv.ShipperName = shippername;
    //    //    sv.VehicleNo = vehicleno;

    //    //    var request = new ShipperMappingVehicleRequest();
    //    //    request.ShipperName = shippername;
    //    //    request.VehicleNo = vehicleno;
    //    //    request.UserName = base.UserInfo.Name;

    //    //    var response = new VehicleManagementService().AddShipperToVehicle(request);

    //    //    if (response == "操作成功")
    //    //    {
    //    //        return true;
    //    //    }
    //    //    else
    //    //    {
    //    //        return false;
    //    //    }
        
    //    //}

         


    //    //模糊查询显示承运商
    //    [HttpPost]
    //    public ActionResult GetAllShippersbySID(string name)
    //    {
    //        var shippers = ApplicationConfigHelper.GetShipperList();
    //        return Json(shippers.Where(s => s.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0).Select(t => new { Value = t.ID.ToString(), Text = t.Name }), JsonRequestBehavior.AllowGet);
    //    }


    //    //输入承运商名称，显示车辆列表
    //    public string GetCRM_ShipperMappingVehicle(string name)
    //    {
    //        ShipperVehicleMappingViewModel sv = new ShipperVehicleMappingViewModel(); 
 
    //        var request = new ShipperMappingVehicleRequest();
    //        request.ShipperName = name;
            
             

    //        var response = new VehicleService().GetCRM_ShipperMappingVehicle(request);

    //        if (response.IsSuccess)
    //        {
    //            sv.Vehicle = response.Result.VehicleCollection;
    //            sv.PageIndex = response.Result.PageIndex;
    //            sv.PageCount = response.Result.PageCount;
    //        }



    //        JavaScriptSerializer Serializer = new JavaScriptSerializer();
    //        string js = Serializer.Serialize(response);

    //        return js;
             
    //    }

    //    //右边表格查询
    //    public string GetCRMShipperMappingVehicle(string name, string vehicleno)
    //    {
    //        ShipperVehicleMappingViewModel sv = new ShipperVehicleMappingViewModel();
    //        sv.ShipperName = name;
    //        sv.VehicleNo = vehicleno;

    //        var request = new ShipperMappingVehicleRequest();
    //        request.ShipperName = name;
    //        request.VehicleNo = vehicleno;


    //        var response = new VehicleService().GetCRMShipperMappingVehicle(request);

    //        if (response.IsSuccess)
    //        {
    //            sv.Vehicle = response.Result.VehicleCollection;
    //        }

    //        JavaScriptSerializer Serializer = new JavaScriptSerializer();
    //        string js = Serializer.Serialize(response);

    //        return js;
        
    //    }

       
    }
}
