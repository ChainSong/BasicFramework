using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using BasicFramework.Biz.ShipperManagement;
using BasicFramework.Entity.ShipperManagement;
using BasicFramework.Entity.ShipperManagement.DriverManagement;
using BasicFramework.Entity.ShipperManagement.VehicleManagement;
using BasicFramework.MessageContracts.ShipperManagement;
using BasicFramework.MessageContracts.ShipperManagement.DriverManagement;
using BasicFramework.MessageContracts.ShipperManagement.VehicleManagement;
using BasicFramework.Web.Areas.ShipperManagement.Models;
using BasicFramework.Web.Common;
using UtilConstants = BasicFramework.Common.Constants;

namespace BasicFramework.Web.Areas.ShipperManagement.Controllers
{
    public class MappingController : BaseController
    {
        //承运商车辆管理 分页
        [HttpGet]
        public ActionResult ShipperVehicleMapping(string id, string name)
        {
            ShipperVehicleMappingViewModel sv = new ShipperVehicleMappingViewModel();

            var shipper = ApplicationConfigHelper.GetShipperList().FirstOrDefault(m => m.ID.ToString() == id);

            sv.SID = shipper.ID;
            sv.ShipperName = shipper.Name;

            VehicleSearchCondition svc = new VehicleSearchCondition();
            svc.ShipperID = id;

            var response = new VehicleService().GetAllVehicle(new GetVehicleByConditionRequest()
            {
                SearchCondition = svc,
                PageSize = UtilConstants.PAGESIZE,
                PageIndex = sv.PageIndex,
            });

            if (response.IsSuccess)
            {
                sv.Vehicle = response.Result.VehicleCollection;
                sv.PageIndex = response.Result.PageIndex;
                sv.PageCount = response.Result.PageCount;
            }

            return View(sv);
        }

        // 根据车牌号码查询
        [HttpPost]
        public ActionResult ShipperVehicleMapping(ShipperVehicleMappingViewModel sv)
        {

            VehicleSearchCondition vsc = new VehicleSearchCondition();
            vsc.CarNo = sv.VehicleNo;

            var response = new VehicleService().GetAllVehicles(new GetVehicleByConditionRequest()
            {
                SearchCondition = vsc,
                PageIndex = sv.PageIndex,
                PageSize = UtilConstants.PAGESIZE,

            });


            if (response.IsSuccess)
            {
                sv.Vehicle = response.Result.VehicleCollection;
                sv.PageIndex = response.Result.PageIndex;
                sv.PageCount = response.Result.PageCount;
            }


            return View(sv);
        }

        //新增和删除
        public bool AddShipperVehicleMapping(string shipper, string carno, string where)
        {
            bool response = false;
            if (where == "del")
            {
                response = new VehicleService().DeleteShipperMappingVehicle(new ShipperMappingVehicleRequest
                {
                    VehicleNo = carno,
                });
            }
            else
            {
                response = new VehicleService().AddShipperMappingVehicle(new ShipperMappingVehicleRequest
                {
                    VehicleNo = carno,
                    ShipperName = shipper,
                    UserName = base.UserInfo.Name
                });
            }
            return response;
        }









        //车辆司机管理 分页
        [HttpGet]
        public ActionResult VehicleDriverMapping(string id)
        {
            VehicleDriverMappingViewModel vd = new VehicleDriverMappingViewModel();

            var vehicle = ApplicationConfigHelper.GetVehicleList().FirstOrDefault(m => m.ID.ToString() == id);

            vd.VID = vehicle.ID;
            vd.VehicleNo = vehicle.CarNo;


            //var driver = ApplicationConfigHelper.GetDriverList();
            DriverSearchCondition ds = new DriverSearchCondition();
            ds.VehicleID = id;


            //int pagesize = 17;
            var response = new DriverService().GetAllDriver(new GetDriverByConditionRequest()
            {
                SearchCondition = ds,
                PageIndex = vd.PageIndex,
                PageSize = UtilConstants.PAGESIZE,
            });

            if (response.IsSuccess)
            {
                vd.Driver = response.Result.DriverCollection;
                vd.PageIndex = response.Result.PageIndex;
                vd.PageCount = response.Result.PageCount;
            }


            return View(vd);
        }

        //查询
        [HttpPost]
        public ActionResult VehicleDriverMapping(VehicleDriverMappingViewModel vd)
        {
            DriverSearchCondition ds = new DriverSearchCondition();
            ds.DriverName = vd.DriverName;

            var response = new DriverService().GetAllDrivers(new GetDriverByConditionRequest()
            {
                SearchCondition = ds,
                PageIndex = vd.PageIndex,
                PageSize = UtilConstants.PAGESIZE
            });

            if (response.IsSuccess)
            {
                vd.Driver = response.Result.DriverCollection;
                vd.PageIndex = response.Result.PageIndex;
                vd.PageCount = response.Result.PageCount;
            }

            return View(vd);
        }

        //新增和删除
        public bool AddOrUpdateVehicleDriverMapping(string vehicleno, string drivername, string where)
        {
            bool response = false;
            if (where == "del")
            {
                response = new DriverService().DeleteVehicleDriverMapping(new VehicleMappingDriverRequest()
                {
                    DriverName = drivername

                });

            }
            else
            {
                response = new DriverService().AddOrUpdateVehicleDriverMapping(new VehicleMappingDriverRequest
                {
                    VehicleNo = vehicleno,
                    DriverName = drivername,
                    UserName = base.UserInfo.Name
                });
            }

            return response;
        }





    }




}



