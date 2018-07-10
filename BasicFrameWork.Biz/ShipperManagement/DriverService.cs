using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicFramework.Common;
using BasicFramework.Dao.ShipperManagement;
using BasicFramework.Entity.ShipperManagement.DriverManagement;
using BasicFramework.Entity.ShipperManagement.VehicleManagement;
using BasicFramework.MessageContracts;
using BasicFramework.MessageContracts.ShipperManagement.DriverManagement;
using BasicFramework.MessageContracts.ShipperManagement.VehicleManagement;

namespace BasicFramework.Biz.ShipperManagement 
{
    public class DriverService : BaseService
    {
        /// <summary>
        /// 查询
        /// </summary> 
        /// <param name="request"></param>
        /// <returns></returns>
        public Response<GetDriverByConditionResponse> GetDriverByCondition(GetDriverByConditionRequest request)
        {
            Response<GetDriverByConditionResponse> response = new Response<GetDriverByConditionResponse>() { Result = new GetDriverByConditionResponse() };

            if (request == null || request.SearchCondition == null)
            {
                ArgumentNullException ex = new ArgumentNullException("GetCRMDriverByCondition request ");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                DriverManagementAccessor accessor = new DriverManagementAccessor();
                int RowCount;
                if (request.PageSize > 0)
                {
                    response.Result.DriverCollection = accessor.GetCRMDriverByCondition(request.SearchCondition, request.PageIndex, request.PageSize, out RowCount); //request.PageIndex, request.PageSize, out RowCount
                    response.Result.PageCount = RowCount % request.PageSize == 0 ? RowCount / request.PageSize : RowCount / request.PageSize + 1;
                    response.Result.PageIndex = request.PageIndex;
                }
                else
                {
                    response.Result.PageIndex = 0;
                    response.Result.PageCount = 0;
                    response.Result.DriverCollection = accessor.GetCRMDriverByConditionNoPaging(request.SearchCondition);
                }
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                LogError(ex);
                response.IsSuccess = false;
                response.ErrorCode = ErrorCode.Technical;
            }
            return response;
        }

        /// <summary>
        /// 通过车辆id查询该车由哪几位司机驾驶
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Response<GetDriverByConditionResponse> GetVehicleMappingDriverVID(GetDriverByConditionRequest request)
        {
            Response<GetDriverByConditionResponse> response = new Response<GetDriverByConditionResponse>() { Result = new GetDriverByConditionResponse() };

            if (request == null || request.SearchCondition == null)
            {
                ArgumentNullException ex = new ArgumentNullException("GetCRMVehicleByCondition request ");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                DriverManagementAccessor accessor = new DriverManagementAccessor();
                int RowCount;
                if (request.PageSize > 0)
                {
                    response.Result.DriverCollection = accessor.GetVehicleMappingDriverVID(request.keyword, request.PageIndex, request.PageSize, out RowCount); //request.PageIndex, request.PageSize, out RowCount
                    response.Result.PageCount = RowCount % request.PageSize == 0 ? RowCount / request.PageSize : RowCount / request.PageSize + 1;
                    response.Result.PageIndex = request.PageIndex;
                }
                else
                {
                    response.Result.PageIndex = 0;
                    response.Result.PageCount = 0;
                    response.Result.DriverCollection = accessor.GetCRMDriverByConditionNoPaging(request.SearchCondition);
                }
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                LogError(ex);
                response.IsSuccess = false;
                response.ErrorCode = ErrorCode.Technical;
            }
            return response;
        }

        /// <summary>
        /// 通过车辆id查询该车由哪几位司机驾驶待条件分页
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public Response<GetDriverByConditionResponse> GetVehicleMappingDriverInfoByVIDandkeyWord(string id, GetDriverByConditionRequest request)
        {
            Response<GetDriverByConditionResponse> response = new Response<GetDriverByConditionResponse>() { Result = new GetDriverByConditionResponse() };

            if (request == null || request.SearchCondition == null)
            {
                ArgumentNullException ex = new ArgumentNullException("GetCRMVehicleByCondition request ");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                DriverManagementAccessor accessor = new DriverManagementAccessor();
                int RowCount;
                if (request.PageSize > 0)
                {
                    response.Result.DriverCollection = accessor.GetVehicleMappingDriverInfoByVIDandkeyWord(id, request.keyword, request.PageIndex, request.PageSize, out RowCount); //request.PageIndex, request.PageSize, out RowCount
                    response.Result.PageCount = RowCount % request.PageSize == 0 ? RowCount / request.PageSize : RowCount / request.PageSize + 1;
                    response.Result.PageIndex = request.PageIndex;
                }
                else
                {
                    response.Result.PageIndex = 0;
                    response.Result.PageCount = 0;
                    response.Result.DriverCollection = accessor.GetCRMDriverByConditionNoPaging(request.SearchCondition);
                }
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                LogError(ex);
                response.IsSuccess = false;
                response.ErrorCode = ErrorCode.Technical;
            }
            return response;
        }


        /// <summary>
        /// 通过shipperID查询当前承运商有哪些司机
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Response<GetDriverByConditionResponse> GetShippingMappingDriverSID(GetDriverByConditionRequest request)
        {
            Response<GetDriverByConditionResponse> response = new Response<GetDriverByConditionResponse>() { Result = new GetDriverByConditionResponse() };

            if (request == null || request.SearchCondition == null)
            {
                ArgumentNullException ex = new ArgumentNullException("GetCRMVehicleByCondition request ");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                DriverManagementAccessor accessor = new DriverManagementAccessor();
                int RowCount;
                if (request.PageSize > 0)
                {
                    response.Result.DriverCollection = accessor.GetShippingMappingDriverSID(request.keyword, request.PageIndex, request.PageSize, out RowCount); //request.PageIndex, request.PageSize, out RowCount
                    response.Result.PageCount = RowCount % request.PageSize == 0 ? RowCount / request.PageSize : RowCount / request.PageSize + 1;
                    response.Result.PageIndex = request.PageIndex;
                }
                else
                {
                    response.Result.PageIndex = 0;
                    response.Result.PageCount = 0;
                    response.Result.DriverCollection = accessor.GetCRMDriverByConditionNoPaging(request.SearchCondition);
                }
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                LogError(ex);
                response.IsSuccess = false;
                response.ErrorCode = ErrorCode.Technical;
            }
            return response;
        }

        /// <summary>
        ///通过shipperID查询当前承运商有哪些司机服务  条件分页
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public Response<GetDriverByConditionResponse> GetShipperMappingDriverInfoBySIDandkeyWord(string id, GetDriverByConditionRequest request)
        {
            Response<GetDriverByConditionResponse> response = new Response<GetDriverByConditionResponse>() { Result = new GetDriverByConditionResponse() };

            if (request == null || request.SearchCondition == null)
            {
                ArgumentNullException ex = new ArgumentNullException("GetCRMVehicleByCondition request ");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                DriverManagementAccessor accessor = new DriverManagementAccessor();
                int RowCount;
                if (request.PageSize > 0)
                {
                    response.Result.DriverCollection = accessor.GetShipperMappingDriverInfoBySIDandkeyWord(id, request.keyword, request.PageIndex, request.PageSize, out RowCount); //request.PageIndex, request.PageSize, out RowCount
                    response.Result.PageCount = RowCount % request.PageSize == 0 ? RowCount / request.PageSize : RowCount / request.PageSize + 1;
                    response.Result.PageIndex = request.PageIndex;
                }
                else
                {
                    response.Result.PageIndex = 0;
                    response.Result.PageCount = 0;
                    response.Result.DriverCollection = accessor.GetCRMDriverByConditionNoPaging(request.SearchCondition);
                }
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                LogError(ex);
                response.IsSuccess = false;
                response.ErrorCode = ErrorCode.Technical;
            }
            return response;
        }








        public Response<GetDriverByConditionResponse> GetCRMDriverBykeyword(GetDriverByConditionRequest request)
        {
            Response<GetDriverByConditionResponse> response = new Response<GetDriverByConditionResponse>() { Result = new GetDriverByConditionResponse() };

            if (request == null || request.SearchCondition == null)
            {
                ArgumentNullException ex = new ArgumentNullException("GetCRMDriverByCondition request ");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                DriverManagementAccessor accessor = new DriverManagementAccessor();
                int RowCount;
                if (request.PageSize > 0)
                {
                    response.Result.DriverCollection = accessor.GetCRMDriverBykeyWord(request.keyword, request.PageIndex, request.PageSize, out RowCount); //request.PageIndex, request.PageSize, out RowCount
                    response.Result.PageCount = RowCount % request.PageSize == 0 ? RowCount / request.PageSize : RowCount / request.PageSize + 1;
                    response.Result.PageIndex = request.PageIndex;
                }
                else
                {
                    response.Result.PageIndex = 0;
                    response.Result.PageCount = 0;
                    response.Result.DriverCollection = accessor.GetCRMDriverByConditionNoPaging(request.SearchCondition);
                }
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                LogError(ex);
                response.IsSuccess = false;
                response.ErrorCode = ErrorCode.Technical;
            }
            return response;
        }

        public Response<IEnumerable<Driver>> AddOrUpdateDriver(AddOrUpdateDriverRequest request)
        {
            Response<IEnumerable<Driver>> response = new Response<IEnumerable<Driver>>();

            if (request == null || request.DriverCollection == null || !request.DriverCollection.Any())
            {
                ArgumentNullException ex = new ArgumentNullException("AddOrUpdateDriver request");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                DriverManagementAccessor accessor = new DriverManagementAccessor();
                response.Result = accessor.AddOrUpdateCRMDriver(request.DriverCollection);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                LogError(ex);
                response.Exception = ex;
                response.IsSuccess = false;
                response.ErrorCode = ErrorCode.Technical;
            }

            return response;
        }






        //public Driver addCreateDriver(GetDriverByConditionRequest request)
        //{

        //    Driver CreateDriver = new Driver();
        //    try
        //    {
        //        Driver Driver = new Driver();
        //        IList<Driver> CRMDriver = new List<Driver>();
        //        CRMDriver.Add(request.AddDriver);
        //        DriverManagementAccessor accessor = new DriverManagementAccessor();
        //        CreateDriver = accessor.AddOrUpdateCRMDriver(CRMDriver);// request.PageIndex, request.PageSize, out RowCount
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return CreateDriver;

        //}

        //删除
        public bool DeleteCRMDriver(string id)
        {
            bool dr = true;
            try
            {
                dr = new DriverManagementAccessor().DeleteCRMDriver(id);
            }
            catch (Exception ex)
            {
                LogError(ex);
            }

            return dr;
        }



        public Driver GetSearcheDriver(string id)
        {
            Driver SearcheFiles = new Driver();
            try
            {

                DriverManagementAccessor accessor = new DriverManagementAccessor();
                SearcheFiles = accessor.GetCRMDriverSearchConditionByID(id);
            }
            catch (Exception)
            {
                throw;
            }
            return SearcheFiles;
        }

        public Response<IEnumerable<Driver>> GetDriverList()
        {
            Response<IEnumerable<Driver>> response = new Response<IEnumerable<Driver>>();

            try
            {
                response.Result = new DriverManagementAccessor().GetDriverList();
                response.IsSuccess = true;
            }

            catch (Exception ex)
            {
                LogError(ex);
                response.IsSuccess = false;
                response.ErrorCode = ErrorCode.Technical;
            }

            return response;
        }


        //车辆司机管理
        public Response<GetDriverByConditionResponse> GetAllDriver(GetDriverByConditionRequest request)
        {
            Response<GetDriverByConditionResponse> response = new Response<GetDriverByConditionResponse>() { Result = new GetDriverByConditionResponse() };

            if (request == null)
            {
                ArgumentNullException ex = new ArgumentNullException("GetVehicleToDriver request ");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                DriverManagementAccessor accessor = new DriverManagementAccessor();
                int RowCount;

                response.Result.DriverCollection = accessor.GetAllDriver(request.SearchCondition, request.PageIndex, request.PageSize, out RowCount); //request.PageIndex, request.PageSize, out RowCount
                response.Result.PageCount = RowCount % request.PageSize == 0 ? RowCount / request.PageSize : RowCount / request.PageSize + 1;
                response.Result.PageIndex = request.PageIndex;

                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                LogError(ex);
                response.IsSuccess = false;
                response.ErrorCode = ErrorCode.Technical;
            }
            return response;
        }

        public Response<GetDriverByConditionResponse> GetAllDrivers(GetDriverByConditionRequest request)
        {
            Response<GetDriverByConditionResponse> response = new Response<GetDriverByConditionResponse>() { Result = new GetDriverByConditionResponse() };

            if (request == null)
            {
                ArgumentNullException ex = new ArgumentNullException("GetVehicleToDriver request ");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                DriverManagementAccessor accessor = new DriverManagementAccessor();
                int RowCount;

                response.Result.DriverCollection = accessor.GetAllDrivers(request.SearchCondition, request.PageIndex, request.PageSize, out RowCount); //request.PageIndex, request.PageSize, out RowCount
                response.Result.PageCount = RowCount % request.PageSize == 0 ? RowCount / request.PageSize : RowCount / request.PageSize + 1;
                response.Result.PageIndex = request.PageIndex;

                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                LogError(ex);
                response.IsSuccess = false;
                response.ErrorCode = ErrorCode.Technical;
            }
            return response;
        }

        public bool AddOrUpdateVehicleDriverMapping(VehicleMappingDriverRequest request)
        {
            bool bo = false;
            try
            {
                DriverManagementAccessor accessor = new DriverManagementAccessor();
                var IsSuccess = accessor.AddOrUpdateVehicleDriverMapping(request.VehicleNo, request.DriverName, request.UserName);
                if (IsSuccess != null)
                {
                    bo = true;
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
            return bo;
        }


        //根据车牌号码查询已选择司机
        public Response<GetDriverByConditionResponse> GetCRM_VehicleMappingDriver(VehicleMappingDriverRequest request)
        {
            Response<GetDriverByConditionResponse> response = new Response<GetDriverByConditionResponse>() { Result = new GetDriverByConditionResponse() };

            if (request == null)
            {
                ArgumentNullException ex = new ArgumentNullException("GetCRM_VehicleMappingDriver request ");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }
            try
            {
                DriverManagementAccessor accessor = new DriverManagementAccessor();


                response.Result.DriverCollection = accessor.GetCRM_VehicleMappingDriver(request.VehicleNo); //request.PageIndex, request.PageSize, out RowCount
                //  response.Result.PageCount = RowCount % request.PageSize == 0 ? RowCount / request.PageSize : RowCount / request.PageSize + 1;
                //response.Result.PageIndex = request.PageIndex;

                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                LogError(ex);
                response.IsSuccess = false;
                response.ErrorCode = ErrorCode.Technical;
            }
            return response;
        }


        //右边表格查询
        public Response<GetDriverByConditionResponse> GetCRMVehicleMappingDriver(VehicleMappingDriverRequest request)
        {
            Response<GetDriverByConditionResponse> response = new Response<GetDriverByConditionResponse>() { Result = new GetDriverByConditionResponse() };

            if (request == null)
            {
                ArgumentNullException ex = new ArgumentNullException("GetCRMVehicleMappingDriver request ");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }
            try
            {
                DriverManagementAccessor accessor = new DriverManagementAccessor();
                response.Result.DriverCollection = accessor.GetCRMVehicleMappingDriver(request.VehicleNo, request.DriverName);

                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                LogError(ex);
                response.IsSuccess = false;
                response.ErrorCode = ErrorCode.Technical;
            }
            return response;
        }



        public Response<VehicleMappingDriverResponse> GetVehicleDriverView(VehicleMappingDriverRequest request)
        {
            Response<VehicleMappingDriverResponse> response = new Response<VehicleMappingDriverResponse>() { Result = new VehicleMappingDriverResponse() };

            if (request == null)
            {
                ArgumentNullException ex = new ArgumentNullException("GetShipperVehicleView request ");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                DriverManagementAccessor accessor = new DriverManagementAccessor();
                response.Result.VehicleMappingDriverCollection = accessor.GetVehicleMappingDriver(request.VehicleNo);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                LogError(ex);
                response.IsSuccess = false;
                response.ErrorCode = ErrorCode.Technical;
            }


            return response;
        }


        public Response<VehicleMappingDriverResponse> GetDriverView(VehicleMappingDriverRequest request)
        {
            Response<VehicleMappingDriverResponse> response = new Response<VehicleMappingDriverResponse>() { Result = new VehicleMappingDriverResponse() };

            if (request == null)
            {
                ArgumentNullException ex = new ArgumentNullException("GetDriverView request ");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;

            }
            try
            {
                DriverManagementAccessor accessor = new DriverManagementAccessor();
                response.Result.DriverCollection = accessor.GetDriverView(request.VehicleNo);
                response.IsSuccess = true;


            }
            catch (Exception ex)
            {
                LogError(ex);
                response.IsSuccess = false;
                response.ErrorCode = ErrorCode.Technical;
            }



            return response;
        }

        public bool DeleteVehicleDriverMapping(VehicleMappingDriverRequest request)
        {
            bool IsSuccess = false;
            try
            {
                DriverManagementAccessor accessor = new DriverManagementAccessor();
                IsSuccess = accessor.DeleteVehicleDriverMapping(request.DriverName);
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
            return IsSuccess;
        }


    }



}
