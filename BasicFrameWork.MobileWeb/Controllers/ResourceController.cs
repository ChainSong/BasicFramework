using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using BasicFramework.Biz;
using BasicFramework.Biz.ShipperManagement;
using BasicFramework.Common;
using BasicFramework.Entity;
using BasicFramework.Entity.ShipperManagement.DriverManagement;
using BasicFramework.Entity.ShipperManagement.VehicleManagement;
using BasicFramework.MessageContracts;
using BasicFramework.MessageContracts.ShipperManagement.DriverManagement;
using BasicFramework.MessageContracts.ShipperManagement.VehicleManagement;
using BasicFramework.MobileWeb.Common;
using BasicFramework.MobileWeb.Models.Resource;

namespace BasicFramework.MobileWeb.Controllers
{
    public class ResourceController : Controller
    {
        public async Task<ActionResult> Shipper()
        {
            return await Task.Run<ActionResult>(() =>
            {
                ShipperViewModel vm = new ShipperViewModel();

                var getCRMShippersByConditionRequest = new GetShippersByConditionRequest();
                getCRMShippersByConditionRequest.SearchCondition = new ShipperSearchCondition();
                getCRMShippersByConditionRequest.PageSize = BasicFramework.Common.Constants.PAGESIZE;
                getCRMShippersByConditionRequest.PageIndex = 0;

                var getCRMShippersByConditionResponse = new ShipperManagementService().GetShippersByCondition(getCRMShippersByConditionRequest);

                if (getCRMShippersByConditionResponse.IsSuccess)
                {
                    vm.CRMShipperCollection = getCRMShippersByConditionResponse.Result.ShipperCollection;
                    vm.PageIndex = getCRMShippersByConditionResponse.Result.PageIndex;
                    vm.PageCount = getCRMShippersByConditionResponse.Result.PageCount;
                }

                return View(vm);
            });
        }

        [HttpPost]
        public async Task<ActionResult> Shipper(string keyword, int? pageIndex)
        {
            return await Task.Run<ActionResult>(() =>
            {
                var getCRMShippersByConditionRequest = new GetShippersByConditionRequest();
                getCRMShippersByConditionRequest.SearchCondition = new ShipperSearchCondition() { KeyWord = keyword };
                getCRMShippersByConditionRequest.PageSize = BasicFramework.Common.Constants.PAGESIZE;
                getCRMShippersByConditionRequest.PageIndex = pageIndex ?? 0;

                ShipperViewModel vm = new ShipperViewModel();
                var getCRMShippersByConditionResponse = new ShipperManagementService().GetShippersByCondition(getCRMShippersByConditionRequest);

                if (getCRMShippersByConditionResponse.IsSuccess)
                {
                    vm.CRMShipperCollection = getCRMShippersByConditionResponse.Result.ShipperCollection;
                    vm.PageIndex = getCRMShippersByConditionResponse.Result.PageIndex;
                    vm.PageCount = getCRMShippersByConditionResponse.Result.PageCount;
                }
                else
                {
                    throw new Exception(getCRMShippersByConditionResponse.Exception.Message);
                }
                return Json(vm, JsonRequestBehavior.AllowGet);

            });
        }

        public async Task<ActionResult> ShipperInfos(int? id)
        {
            return await Task.Run<ActionResult>(() =>
            {
                ShipperInfosModel vm = new ShipperInfosModel();
                var getCRMShipperResponse = new ShipperManagementService().GetCRMShipperInfo(new CRMShipperOperationRequest() { CRMShipperID = id });
                if (getCRMShipperResponse.IsSuccess)
                {
                    vm.Shipper = getCRMShipperResponse.Result.Shipper;
                    if (vm.Shipper == null)
                    {
                        vm.Shipper = new Shipper();
                    }

                    vm.CRMShipperCooperationCollection = getCRMShipperResponse.Result.ShipperCooperationCollection;
                    vm.CRMShipperTransportationLineCollection = getCRMShipperResponse.Result.ShipperTransportationLineCollection;
                    vm.CRMShipperTerminalInfoCollection = getCRMShipperResponse.Result.ShipperTerminalInfoCollection;

                    if (string.IsNullOrEmpty(vm.Shipper.Str3))
                    {
                        vm.Shipper.Str3 = Guid.NewGuid().ToString();
                    }

                    if (string.IsNullOrEmpty(vm.Shipper.AttachmentGroupID))
                    {
                        vm.Shipper.AttachmentGroupID = Guid.NewGuid().ToString();
                    }

                }
                else
                {
                    throw new Exception(getCRMShipperResponse.Exception.Message);
                }
                return View(vm);
            });
        }
        [HttpGet]

        public async Task<ActionResult> Driver()
        {
            return await Task.Run<ActionResult>(() =>
            {
                var getCRMDriverByConditionRequest = new GetDriverByConditionRequest();
                getCRMDriverByConditionRequest.SearchCondition = new DriverSearchCondition();
                getCRMDriverByConditionRequest.PageSize = BasicFramework.Common.Constants.PAGESIZE;
                getCRMDriverByConditionRequest.PageIndex = 0;

                DriverViewModel vm = new DriverViewModel();
                var getCRMDriverByConditionResponse = new DriverService().GetCRMDriverBykeyword(getCRMDriverByConditionRequest);

                if (getCRMDriverByConditionResponse.IsSuccess)
                {
                    vm.DriverCollection = getCRMDriverByConditionResponse.Result.DriverCollection;
                    vm.PageIndex = getCRMDriverByConditionResponse.Result.PageIndex;
                    vm.PageCount = getCRMDriverByConditionResponse.Result.PageCount;
                }
                else
                {
                    throw new Exception(getCRMDriverByConditionResponse.Exception.Message);
                }
                return View(vm);
            });
        }

        [HttpPost]
        public async Task<ActionResult> Driver(string keyword, int? pageIndex)
        {
            return await Task.Run<ActionResult>(() =>
            {
                var getCRMDriverByConditionRequest = new GetDriverByConditionRequest();
                getCRMDriverByConditionRequest.SearchCondition = new DriverSearchCondition();
                getCRMDriverByConditionRequest.keyword = keyword;
                getCRMDriverByConditionRequest.PageSize = BasicFramework.Common.Constants.PAGESIZE;
                getCRMDriverByConditionRequest.PageIndex = pageIndex ?? 0;

                DriverViewModel vm = new DriverViewModel();
                var getCRMDriverByConditionResponse = new DriverService().GetCRMDriverBykeyword(getCRMDriverByConditionRequest);

                if (getCRMDriverByConditionResponse.IsSuccess)
                {
                    vm.DriverCollection = getCRMDriverByConditionResponse.Result.DriverCollection;

                    vm.PageIndex = getCRMDriverByConditionResponse.Result.PageIndex;
                    vm.PageCount = getCRMDriverByConditionResponse.Result.PageCount;
                }
                else
                {
                    throw new Exception(getCRMDriverByConditionResponse.Exception.Message);
                }
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                serializer.RegisterConverters(new JavaScriptConverter[] { new DateTimeConverter() });
                string js = serializer.Serialize(vm);

                return Json(js, JsonRequestBehavior.AllowGet);
            });
        }
        //查询司机信息
        public async Task<ActionResult> Driverinfos(string id)
        {
            return await Task.Run<ActionResult>(() =>
            {
                DriverInfosModel vm = new DriverInfosModel();
                var getCRMDriverResponse = new DriverService().GetSearcheDriver(id);
                vm.CRMdriver = getCRMDriverResponse;
                return View(vm);
            });
        }

      

        [HttpGet]
        public async Task<ActionResult> Vehicle()
        {
            return await Task.Run<ActionResult>(() =>
            {
                var getCRMDriverByConditionRequest = new GetVehicleByConditionRequest();
                getCRMDriverByConditionRequest.SearchCondition = new VehicleSearchCondition();
                getCRMDriverByConditionRequest.PageSize = BasicFramework.Common.Constants.PAGESIZE;
                getCRMDriverByConditionRequest.PageIndex = 0;

                VehicleViewModel vm = new VehicleViewModel();
                var getCRMVehicleByConditionResponse = new VehicleService().GetCRMVehicleBykeyword(getCRMDriverByConditionRequest);

                if (getCRMVehicleByConditionResponse.IsSuccess)
                {
                    //var a = getCRMVehicleByConditionResponse.Result.CRMVehicleCollection.Each<CRMVehicle, CRMVehicle>((i, k) =>
                    //{
                    //    if (!string.IsNullOrEmpty(k.url))
                    //    {
                    //        k.url = YasuoPicture.GetPicThumbnail(k.url, k.url, 40, 40, 20);
                    //    }
                    //    return k;
                    //});
                    vm.CRMVehicleCollection = getCRMVehicleByConditionResponse.Result.VehicleCollection;//getCRMVehicleByConditionResponse.Result.CRMVehicleCollection;
                    vm.PageIndex = getCRMVehicleByConditionResponse.Result.PageIndex;
                    vm.PageCount = getCRMVehicleByConditionResponse.Result.PageCount;
                }
                else
                {
                    throw new Exception(getCRMVehicleByConditionResponse.Exception.Message);
                }
                return View(vm);
            });
        }
        [HttpPost]
        public async Task<ActionResult> Vehicle(string keyword, int? pageIndex)
        {
            return await Task.Run<ActionResult>(() =>
            {
                var getCRMVehicleByConditionRequest = new GetVehicleByConditionRequest();
                getCRMVehicleByConditionRequest.SearchCondition = new VehicleSearchCondition();
                getCRMVehicleByConditionRequest.keyword = keyword;
                getCRMVehicleByConditionRequest.PageSize = BasicFramework.Common.Constants.PAGESIZE;
                getCRMVehicleByConditionRequest.PageIndex = pageIndex ?? 0;

                VehicleViewModel vm = new VehicleViewModel();
                var getCRMVehicleByConditionResponse = new VehicleService().GetCRMVehicleBykeyword(getCRMVehicleByConditionRequest);

                if (getCRMVehicleByConditionResponse.IsSuccess)
                {
                    vm.CRMVehicleCollection = getCRMVehicleByConditionResponse.Result.VehicleCollection;
                    vm.PageIndex = getCRMVehicleByConditionResponse.Result.PageIndex;
                    vm.PageCount = getCRMVehicleByConditionResponse.Result.PageCount;
                }
                else
                {
                    throw new Exception(getCRMVehicleByConditionResponse.Exception.Message);
                }

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                serializer.RegisterConverters(new JavaScriptConverter[] { new DateTimeConverter() });
                string js = serializer.Serialize(vm);
                return Json(js, JsonRequestBehavior.AllowGet);
                
            });
        }

        //查询车辆信息
        public async Task<ActionResult> Vehicleinfos(string id)
        {
            return await Task.Run<ActionResult>(() =>
            {
                VehicleInfosModel vm = new VehicleInfosModel();
                var getCRMVehicleResponse = new VehicleService().GetCRMVehiclebyID(id);
                vm.CRMVehicle = getCRMVehicleResponse;
                return View(vm);
            });
        }
        #region  承运商关联车辆表的查询
        /// <summary>
        /// 通过承运商ID查询该承运商下面有哪些车辆
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public async Task<ActionResult> ShipperMappingVehicleBySID(int id)
        {
            return await Task.Run<ActionResult>(() =>
            {
                var getCRMVehicleByConditionRequest = new GetVehicleByConditionRequest();
                getCRMVehicleByConditionRequest.SearchCondition = new VehicleSearchCondition();

                getCRMVehicleByConditionRequest.keyword = id.ToString();
                getCRMVehicleByConditionRequest.PageSize = BasicFramework.Common.Constants.PAGESIZE;
                getCRMVehicleByConditionRequest.PageIndex = 0;

                VehicleViewModel vm = new VehicleViewModel();
                var getCRMVehicleByConditionResponse = new VehicleService().GetShipperMappingVehicleBySID(getCRMVehicleByConditionRequest);

                if (getCRMVehicleByConditionResponse.IsSuccess)
                {
                    vm.CRMVehicleCollection = getCRMVehicleByConditionResponse.Result.VehicleCollection;
                    vm.PageIndex = getCRMVehicleByConditionResponse.Result.PageIndex;
                    vm.PageCount = getCRMVehicleByConditionResponse.Result.PageCount;
                }
                else
                {
                    throw new Exception(getCRMVehicleByConditionResponse.Exception.Message);
                }

                ViewData["id"] = id;
                return View(vm);
            });
        }

        /// <summary>
        /// 通过shipperid 查询司机  条件分页
        /// </summary>
        /// <param name="id"></param>
        /// <param name="keyword"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> GetShipperMappingVehicleInfoByShipperIDandkeyWord(string id, string keyword, int? pageIndex)
        {
            return await Task.Run<ActionResult>(() =>
            {
                var getCRMVehicleByConditionRequest = new GetVehicleByConditionRequest();
                getCRMVehicleByConditionRequest.SearchCondition = new VehicleSearchCondition();
                getCRMVehicleByConditionRequest.keyword = keyword;
                getCRMVehicleByConditionRequest.PageSize = BasicFramework.Common.Constants.PAGESIZE;
                getCRMVehicleByConditionRequest.PageIndex = pageIndex ?? 0;

                VehicleViewModel vm = new VehicleViewModel();

                var getCRMVehicleByConditionResponse = new VehicleService().GetShipperMappingVehicleInfoByShipperIDandkeyWord(id, getCRMVehicleByConditionRequest);

                if (getCRMVehicleByConditionResponse.IsSuccess)
                {
                    vm.CRMVehicleCollection = getCRMVehicleByConditionResponse.Result.VehicleCollection;
                    vm.PageIndex = getCRMVehicleByConditionResponse.Result.PageIndex;
                    vm.PageCount = getCRMVehicleByConditionResponse.Result.PageCount;
                }
                else
                {
                    throw new Exception(getCRMVehicleByConditionResponse.Exception.Message);
                }

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                serializer.RegisterConverters(new JavaScriptConverter[] { new DateTimeConverter() });
                string js = serializer.Serialize(vm);
                return Json(js, JsonRequestBehavior.AllowGet);
            });
        }
        #endregion


        #region  车辆关联司机的查询
        /// <summary>
        /// 通过车辆ID查询该车辆是由哪位司机驾驶
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> VehicleMappingDriverByVID(int id)
        {
            return await Task.Run<ActionResult>(() =>
            {
                var getCRMVehicleByConditionRequest = new GetDriverByConditionRequest();
                getCRMVehicleByConditionRequest.SearchCondition = new DriverSearchCondition();

                getCRMVehicleByConditionRequest.keyword = id.ToString();
                getCRMVehicleByConditionRequest.PageSize = BasicFramework.Common.Constants.PAGESIZE;
                getCRMVehicleByConditionRequest.PageIndex = 0;

                DriverViewModel vm = new DriverViewModel();
                var getCRMDriverByConditionResponse = new DriverService().GetVehicleMappingDriverVID(getCRMVehicleByConditionRequest);

                if (getCRMDriverByConditionResponse.IsSuccess)
                {
                    vm.DriverCollection = getCRMDriverByConditionResponse.Result.DriverCollection;
                    vm.PageIndex = getCRMDriverByConditionResponse.Result.PageIndex;
                    vm.PageCount = getCRMDriverByConditionResponse.Result.PageCount;
                }
                else
                {
                    throw new Exception(getCRMDriverByConditionResponse.Exception.Message);
                }

                ViewData["id"] = id;
                return View(vm);
            });
        }

        /// <summary>
        /// 通过车辆id 查询司机  条件，分页
        /// </summary>
        /// <param name="id"></param>
        /// <param name="keyword"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> GetVehicleMappingDriverInfoByVIDandkeyWord(string id, string keyword, int? pageIndex)
        {
            return await Task.Run<ActionResult>(() =>
            {
                var getCRMDriverByConditionRequest = new GetDriverByConditionRequest();
                getCRMDriverByConditionRequest.SearchCondition = new DriverSearchCondition();
                getCRMDriverByConditionRequest.keyword = keyword;
                getCRMDriverByConditionRequest.PageSize = BasicFramework.Common.Constants.PAGESIZE;
                getCRMDriverByConditionRequest.PageIndex = pageIndex ?? 0;

                DriverViewModel vm = new DriverViewModel();

                var getCRMDriverByConditionResponse = new DriverService().GetVehicleMappingDriverInfoByVIDandkeyWord(id, getCRMDriverByConditionRequest);

                if (getCRMDriverByConditionResponse.IsSuccess)
                {
                    vm.DriverCollection = getCRMDriverByConditionResponse.Result.DriverCollection;
                    vm.PageIndex = getCRMDriverByConditionResponse.Result.PageIndex;
                    vm.PageCount = getCRMDriverByConditionResponse.Result.PageCount;
                }
                else
                {
                    throw new Exception(getCRMDriverByConditionResponse.Exception.Message);
                }

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                serializer.RegisterConverters(new JavaScriptConverter[] { new DateTimeConverter() });
                string js = serializer.Serialize(vm);
                return Json(js, JsonRequestBehavior.AllowGet);
            });
        }
        #endregion

        #region   承运商关联车辆  车辆再关联司机查询
        /// <summary>
        /// 通过shipperID查询该车辆是由哪位司机驾驶
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> ShipperMappingDriverBySID(int id)
        {
            return await Task.Run<ActionResult>(() =>
            {
                var getCRMVehicleByConditionRequest = new GetDriverByConditionRequest();
                getCRMVehicleByConditionRequest.SearchCondition = new DriverSearchCondition();

                getCRMVehicleByConditionRequest.keyword = id.ToString();
                getCRMVehicleByConditionRequest.PageSize = BasicFramework.Common.Constants.PAGESIZE;
                getCRMVehicleByConditionRequest.PageIndex = 0;

                DriverViewModel vm = new DriverViewModel();
                var getCRMDriverByConditionResponse = new DriverService().GetShippingMappingDriverSID(getCRMVehicleByConditionRequest);

                if (getCRMDriverByConditionResponse.IsSuccess)
                {
                    vm.DriverCollection = getCRMDriverByConditionResponse.Result.DriverCollection;
                    vm.PageIndex = getCRMDriverByConditionResponse.Result.PageIndex;
                    vm.PageCount = getCRMDriverByConditionResponse.Result.PageCount;
                }
                else
                {
                    throw new Exception(getCRMDriverByConditionResponse.Exception.Message);
                }
            
                ViewData["id"] = id;
              
                return View(vm);
            });
        }

        /// <summary>
        /// 通过shipperid 查询司机  条件，分页
        /// </summary>
        /// <param name="id"></param>
        /// <param name="keyword"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> GetShipperMappingDriverInfoBySIDandkeyWord(string id, string keyword, int? pageIndex)
        {
            return await Task.Run<ActionResult>(() =>
            {
                var getCRMDriverByConditionRequest = new GetDriverByConditionRequest();
                getCRMDriverByConditionRequest.SearchCondition = new DriverSearchCondition();
                getCRMDriverByConditionRequest.keyword = keyword;
                getCRMDriverByConditionRequest.PageSize = BasicFramework.Common.Constants.PAGESIZE;
                getCRMDriverByConditionRequest.PageIndex = pageIndex ?? 0;

                DriverViewModel vm = new DriverViewModel();

                var getCRMDriverByConditionResponse = new DriverService().GetShipperMappingDriverInfoBySIDandkeyWord(id, getCRMDriverByConditionRequest);

                if (getCRMDriverByConditionResponse.IsSuccess)
                {
                    vm.DriverCollection = getCRMDriverByConditionResponse.Result.DriverCollection;
                    vm.PageIndex = getCRMDriverByConditionResponse.Result.PageIndex;
                    vm.PageCount = getCRMDriverByConditionResponse.Result.PageCount;
                }
                else
                {
                    throw new Exception(getCRMDriverByConditionResponse.Exception.Message);
                }

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                serializer.RegisterConverters(new JavaScriptConverter[] { new DateTimeConverter() });
                string js = serializer.Serialize(vm);
                return Json(js, JsonRequestBehavior.AllowGet);
            });
        }
        #endregion




        //[HttpPost]
        //public async Task<ActionResult> Vehicleinfo(int id)
        //{
        //    return await Task.Run<ActionResult>(() =>
        //    {
        //        VehicleInfosModel vm = new VehicleInfosModel();
        //      var getCRMVehicleResponse = new VehicleManagementService().GetVehiclebyid(id);
        //        vm.CRMVehicle = getCRMVehicleResponse;
        //        return Json(vm, JsonRequestBehavior.AllowGet);
        //    });
        //}




    }
}
