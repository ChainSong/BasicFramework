using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicFramework.Common;
using BasicFramework.Dao.ShipperManagement;
using BasicFramework.Entity.ShipperManagement.VehicleManagement;
using BasicFramework.MessageContracts;
using BasicFramework.MessageContracts.ShipperManagement.VehicleManagement;
using BasicFramework.Entity.ShipperManagement;
using BasicFramework.Entity;
using BasicFramework.MessageContracts.ShipperManagement; 

namespace BasicFramework.Biz.ShipperManagement
{
    public class VehicleService : BaseService
    {
        /// <summary>
        /// 查询
        /// </summary> 
        /// <param name="request"></param>
        /// <returns></returns>
        public Response<GetVehicleByConditionResponse> GetVehicleByCondition(GetVehicleByConditionRequest request)
        {
            Response<GetVehicleByConditionResponse> response = new Response<GetVehicleByConditionResponse>() { Result = new GetVehicleByConditionResponse() };

            if (request == null || request.SearchCondition == null)
            {
                ArgumentNullException ex = new ArgumentNullException("GetVehicleByCondition request ");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                VehicleManagementAccessor accessor = new VehicleManagementAccessor();
                int RowCount;
                if (request.PageSize > 0)
                {
                    response.Result.VehicleCollection = accessor.GetVehicleByCondition(request.SearchCondition, request.PageIndex, request.PageSize, out RowCount); //request.PageIndex, request.PageSize, out RowCount
                    response.Result.PageCount = RowCount % request.PageSize == 0 ? RowCount / request.PageSize : RowCount / request.PageSize + 1;
                    response.Result.PageIndex = request.PageIndex;
                    if (response.Result.PageCount <= response.Result.PageIndex)
                    {
                        response.Result.PageIndex = 0;
                    }
                }
                else
                {
                    response.Result.PageIndex = 0;
                    response.Result.PageCount = 0;
                    response.Result.VehicleCollection = accessor.GetCRMVehicleByConditionNoPaging(request.SearchCondition);
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


        public Response<ShipperMappingVehicleResponse> GetVehicleView(ShipperMappingVehicleRequest request)
        {
            Response<ShipperMappingVehicleResponse> response = new Response<ShipperMappingVehicleResponse>() { Result = new ShipperMappingVehicleResponse() };

            if (request == null)
            {
                ArgumentNullException ex = new ArgumentNullException("GetVehicleView request ");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;

            }
            try
            {
                VehicleManagementAccessor accessor = new VehicleManagementAccessor();
                response.Result.VehicleCollection = accessor.GetVehicleView(request.ID);
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
        /// 手机端查询 通过关键字
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Response<GetVehicleByConditionResponse> GetCRMVehicleBykeyword(GetVehicleByConditionRequest request)
        {
            Response<GetVehicleByConditionResponse> response = new Response<GetVehicleByConditionResponse>() { Result = new GetVehicleByConditionResponse() };

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
                VehicleManagementAccessor accessor = new VehicleManagementAccessor();
                int RowCount;
                if (request.PageSize > 0)
                {
                    response.Result.VehicleCollection = accessor.GetCRMVehicleBykeyword(request.keyword, request.PageIndex, request.PageSize, out RowCount); //request.PageIndex, request.PageSize, out RowCount
                    response.Result.PageCount = RowCount % request.PageSize == 0 ? RowCount / request.PageSize : RowCount / request.PageSize + 1;
                    response.Result.PageIndex = request.PageIndex;
                }
                else
                {
                    response.Result.PageIndex = 0;
                    response.Result.PageCount = 0;
                    response.Result.VehicleCollection = accessor.GetCRMVehicleByConditionNoPaging(request.SearchCondition);
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



        public Response<GetVehicleByConditionResponse> GetShipperMappingVehicleInfoByShipperIDandkeyWord(string id, GetVehicleByConditionRequest request)
        {
            Response<GetVehicleByConditionResponse> response = new Response<GetVehicleByConditionResponse>() { Result = new GetVehicleByConditionResponse() };

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
                VehicleManagementAccessor accessor = new VehicleManagementAccessor();
                int RowCount;
                if (request.PageSize > 0)
                {
                    response.Result.VehicleCollection = accessor.GetShipperMappingVehicleInfoByShipperIDandkeyWord(id, request.keyword, request.PageIndex, request.PageSize, out RowCount); //request.PageIndex, request.PageSize, out RowCount
                    response.Result.PageCount = RowCount % request.PageSize == 0 ? RowCount / request.PageSize : RowCount / request.PageSize + 1;
                    response.Result.PageIndex = request.PageIndex;
                }
                else
                {
                    response.Result.PageIndex = 0;
                    response.Result.PageCount = 0;
                    response.Result.VehicleCollection = accessor.GetCRMVehicleByConditionNoPaging(request.SearchCondition);
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
        /// 通过承运商ID查询该承运商下面有哪些车辆
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Response<GetVehicleByConditionResponse> GetShipperMappingVehicleBySID(GetVehicleByConditionRequest request)
        {
            Response<GetVehicleByConditionResponse> response = new Response<GetVehicleByConditionResponse>() { Result = new GetVehicleByConditionResponse() };

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
                VehicleManagementAccessor accessor = new VehicleManagementAccessor();
                int RowCount;
                if (request.PageSize > 0)
                {
                    response.Result.VehicleCollection = accessor.GetShipperMappingVehicleBySID(request.keyword, request.PageIndex, request.PageSize, out RowCount); //request.PageIndex, request.PageSize, out RowCount
                    response.Result.PageCount = RowCount % request.PageSize == 0 ? RowCount / request.PageSize : RowCount / request.PageSize + 1;
                    response.Result.PageIndex = request.PageIndex;
                }
                else
                {
                    response.Result.PageIndex = 0;
                    response.Result.PageCount = 0;
                    response.Result.VehicleCollection = accessor.GetCRMVehicleByConditionNoPaging(request.SearchCondition);
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


        public Response<IEnumerable<Vehicle>> AddOrUpdateVehicles(AddOrUpdateVehicleRequest request)
        {
            Response<IEnumerable<Vehicle>> response = new Response<IEnumerable<Vehicle>>();

            if (request == null || request.VehicleCollection == null || !request.VehicleCollection.Any())
            {
                ArgumentNullException ex = new ArgumentNullException("AddOrUpdateCRMVehicle request");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                VehicleManagementAccessor accessor = new VehicleManagementAccessor();
                response.Result = accessor.AddOrUpdateVehicles(request.VehicleCollection);
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


        //新增和更新
        //public Vehicle addCreateVehicle(GetVehicleByConditionRequest request)
        //{

        //    Vehicle CreateFiles = new Vehicle();
        //    try
        //    {
        //        Vehicle Vehicle = new Vehicle();
        //        IList<Vehicle> CRMVehicle = new List<Vehicle>();
        //       // CRMVehicle.Add(request.CreateFiles);
        //        VehicleManagementAccessor accessor = new VehicleManagementAccessor();
        //        CreateFiles = accessor.AddOrUpdateCRMVehicle(CRMVehicle);// request.PageIndex, request.PageSize, out RowCount
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return CreateFiles;

        //}


        //通过id查询
        public Vehicle GetSearchVehicle(string id)
        {
            Vehicle SearcheFiles = new Vehicle();
            try
            {

                VehicleManagementAccessor accessor = new VehicleManagementAccessor();
                SearcheFiles = accessor.GetCRMVehicleSearchConditionID(id);
            }
            catch (Exception)
            {
                throw;
            }
            return SearcheFiles;
        }

        public Vehicle GetCRMVehiclebyID(string id)
        {
            Vehicle SearcheFiles = new Vehicle();
            try
            {
                VehicleManagementAccessor accessor = new VehicleManagementAccessor();
                SearcheFiles = accessor.GetCRMVehiclebyID(id);
            }
            catch (Exception)
            {
                throw;
            }
            return SearcheFiles;
        }

        /// <summary>
        /// 删除crm信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        //public Response<long> DeleteCRMVehicle(DeleteCRMVehicleRequest request)
        //{
        //    Response<bool> response = new Response<bool> { Result = false };
        //    if (request == null)
        //    {
        //        ArgumentNullException ex = new ArgumentNullException("DeleteCRMVehicle request CRMVehicleID");
        //        LogError(ex);
        //        response.ErrorCode = ErrorCode.Argument;
        //        response.Exception = ex;
        //        return response;
        //    }



        //删除
        public bool DeleteVehicle(string id)
        {
            bool ve = true;
            try
            {
                ve = new VehicleManagementAccessor().DeleteVehicle(id);
            }
            catch (Exception ex)
            {
                LogError(ex);
            }

            return ve;
        }

        /// <summary>
        /// 获取车辆列表
        /// </summary>
        /// <returns></returns>
        public Response<IEnumerable<Vehicle>> GetVehicleList()
        {
            Response<IEnumerable<Vehicle>> response = new Response<IEnumerable<Vehicle>>();
            //if (request == null)
            //{
            //    ArgumentNullException ex = new ArgumentNullException("GetVehicleList request");
            //    LogError(ex);
            //    response.IsSuccess = false;
            //    response.ErrorCode = ErrorCode.Argument;
            //    response.Exception = ex;
            //    return response;
            //}
            try
            {
                VehicleManagementAccessor accessor = new VehicleManagementAccessor();
                response.Result = accessor.GetVehicleList().ToList();

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
        /// 车辆分页显示,且已选择的打钩
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Response<GetVehicleByConditionResponse> GetAllVehicle(GetVehicleByConditionRequest request)
        {
            Response<GetVehicleByConditionResponse> response = new Response<GetVehicleByConditionResponse>() { Result = new GetVehicleByConditionResponse() };

            if (request == null)
            {
                ArgumentNullException ex = new ArgumentNullException("GetAllVehicle request ");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                VehicleManagementAccessor accessor = new VehicleManagementAccessor();
                int RowCount;

                response.Result.VehicleCollection = accessor.GetAllVehicle(request.SearchCondition, request.PageIndex, request.PageSize, out RowCount);//request.Vehicle,
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

        /// <summary>
        /// 根据车牌号码查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Response<GetVehicleByConditionResponse> GetAllVehicles(GetVehicleByConditionRequest request)
        {
            Response<GetVehicleByConditionResponse> response = new Response<GetVehicleByConditionResponse>() { Result = new GetVehicleByConditionResponse() };

            if (request == null)
            {
                ArgumentNullException ex = new ArgumentNullException("GetAllVehicle request ");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                VehicleManagementAccessor accessor = new VehicleManagementAccessor();
                int RowCount;

                response.Result.VehicleCollection = accessor.GetAllVehicles(request.SearchCondition, request.PageIndex, request.PageSize, out RowCount);//request.Vehicle,
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



        /// <summary>
        /// 已选车辆信息
        /// </summary>
        /// <param name="crmCar"></param>
        /// <returns></returns>
        public bool AddShipperMappingVehicle(ShipperMappingVehicleRequest request)
        {
            bool IsSuccess = false;
            try
            {
                VehicleManagementAccessor accessor = new VehicleManagementAccessor();
                var a = accessor.AddShipperMappingVehicle(request.VehicleNo, request.ShipperName, request.UserName);
                if (a != null)
                {
                    IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
            return IsSuccess;
        }

        public bool DeleteShipperMappingVehicle(ShipperMappingVehicleRequest request)
        {
            bool IsSuccess = false;
            try
            {
                VehicleManagementAccessor accessor = new VehicleManagementAccessor();
                IsSuccess = accessor.DeleteShipperMappingVehicle(request.VehicleNo);
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
            return IsSuccess;
        }

        //Response<IEnumerable<Vehicle>> response = new Response<IEnumerable<Vehicle>>();

        //    if (request == null || request.VehicleCollection == null || !request.VehicleCollection.Any())
        //    {
        //        ArgumentNullException ex = new ArgumentNullException("AddOrUpdateCRMVehicle request");
        //        LogError(ex);
        //        response.ErrorCode = ErrorCode.Argument;
        //        response.Exception = ex;
        //        return response;
        //    }

        //    try
        //    {
        //        VehicleManagementAccessor accessor = new VehicleManagementAccessor();
        //        response.Result = accessor.AddOrUpdateVehicles(request.VehicleCollection);
        //        response.IsSuccess = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        LogError(ex);
        //        response.Exception = ex;
        //        response.IsSuccess = false;
        //        response.ErrorCode = ErrorCode.Technical;
        //    }



        //根据承运商名称查询已选择车辆
        public Response<GetVehicleByConditionResponse> GetCRM_ShipperMappingVehicle(ShipperMappingVehicleRequest request)
        {
            Response<GetVehicleByConditionResponse> response = new Response<GetVehicleByConditionResponse>() { Result = new GetVehicleByConditionResponse() };

            if (request == null)
            {
                ArgumentNullException ex = new ArgumentNullException("GetAllVehicle request ");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }
            try
            {
                VehicleManagementAccessor accessor = new VehicleManagementAccessor();


                response.Result.VehicleCollection = accessor.GetCRM_ShipperMappingVehicle(request.ShipperName); //request.PageIndex, request.PageSize, out RowCount
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
        public Response<GetVehicleByConditionResponse> GetCRMShipperMappingVehicle(ShipperMappingVehicleRequest request)
        {
            Response<GetVehicleByConditionResponse> response = new Response<GetVehicleByConditionResponse>() { Result = new GetVehicleByConditionResponse() };

            if (request == null)
            {
                ArgumentNullException ex = new ArgumentNullException("GetCRMShipperMappingVehicle request ");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }
            try
            {
                VehicleManagementAccessor accessor = new VehicleManagementAccessor();
                response.Result.VehicleCollection = accessor.GetCRMShipperMappingVehicle(request.ShipperName, request.VehicleNo);

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



        public Response<ShipperMappingVehicleResponse> GetShipperVehicleView(ShipperMappingVehicleRequest request)
        {
            Response<ShipperMappingVehicleResponse> response = new Response<ShipperMappingVehicleResponse>() { Result = new ShipperMappingVehicleResponse() };

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
                VehicleManagementAccessor accessor = new VehicleManagementAccessor();
                response.Result.ShipperMappingVehicleCollection = accessor.GetShipperMappingVehicle(request.ShipperName);

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



    }
}

