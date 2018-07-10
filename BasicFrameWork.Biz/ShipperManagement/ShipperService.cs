using System;
using System.Collections.Generic;
using System.Linq;
using BasicFramework.Common;
using BasicFramework.Dao;
using BasicFramework.Entity;
using BasicFramework.Entity.ShipperManagement;
using BasicFramework.MessageContracts;
using BasicFramework.MessageContracts.ShipperManagement;

namespace BasicFramework.Biz
{
    public class ShipperManagementService : BaseService
    {
        public Response<CRMShipperInfo> GetCRMShipperInfo(CRMShipperOperationRequest request)
        {
            Response<CRMShipperInfo> response = new Response<CRMShipperInfo>();

            if (request == null || !request.CRMShipperID.HasValue || request.CRMShipperID.Value == 0)
            {
                ArgumentNullException ex = new ArgumentNullException("GetCRMShipperInfo request CRMShipperID");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                ShipperManagementAccessor accessor = new ShipperManagementAccessor();
                response.Result = accessor.GetCRMShipperInfoByID(request.CRMShipperID.Value);
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

        public Response<GetShippersByConditionResponse> GetShippersByCondition(GetShippersByConditionRequest request)
        {
            Response<GetShippersByConditionResponse> response = new Response<GetShippersByConditionResponse>() { Result = new GetShippersByConditionResponse() };

            if (request == null || request.SearchCondition == null)
            {
                ArgumentNullException ex = new ArgumentNullException("GetCRMShippersByCondition request");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                ShipperManagementAccessor accessor = new ShipperManagementAccessor();
                int RowCount;
                if (request.PageSize > 0)
                {
                    response.Result.ShipperCollection = accessor.GetCRMShippersByCondition(request.SearchCondition, request.PageIndex, request.PageSize, out RowCount);
                    response.Result.PageCount = RowCount % request.PageSize == 0 ? RowCount / request.PageSize : RowCount / request.PageSize + 1;
                    response.Result.PageIndex = request.PageIndex;
                }
                else
                {
                    response.Result.PageIndex = 0;
                    response.Result.PageCount = 0;
                    response.Result.ShipperCollection = accessor.GetCRMShippersByConditionNoPaging(request.SearchCondition);
                }
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

        public Response<IEnumerable<ShipperCooperation>> GetCRMShipperCooperations(CRMShipperOperationRequest request)
        {
            Response<IEnumerable<ShipperCooperation>> response = new Response<IEnumerable<ShipperCooperation>>();

            if (request == null || !request.CRMShipperID.HasValue || request.CRMShipperID.Value == 0)
            {
                ArgumentNullException ex = new ArgumentNullException("GetCRMShipper request CRMShipperID");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                ShipperManagementAccessor accessor = new ShipperManagementAccessor();
                response.Result = accessor.GetCRMShipperCooperationsByCRMShipperID(request.CRMShipperID.Value);
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

        public Response<IEnumerable<ShipperTerminalInfo>> GetCRMShipperTerminalInfos(CRMShipperOperationRequest request)
        {
            Response<IEnumerable<ShipperTerminalInfo>> response = new Response<IEnumerable<ShipperTerminalInfo>>();

            if (request == null || !request.CRMShipperID.HasValue || request.CRMShipperID.Value == 0)
            {
                ArgumentNullException ex = new ArgumentNullException("GetCRMShipperTerminalInfos request CRMShipperID");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                ShipperManagementAccessor accessor = new ShipperManagementAccessor();
                response.Result = accessor.GetCRMShipperTerminalInfosByCRMShipperID(request.CRMShipperID.Value);
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

        public Response<IEnumerable<ShipperTransportationLine>> GetCRMShipperTransportationLines(CRMShipperOperationRequest request)
        {
            Response<IEnumerable<ShipperTransportationLine>> response = new Response<IEnumerable<ShipperTransportationLine>>();

            if (request == null || !request.CRMShipperID.HasValue || request.CRMShipperID.Value == 0)
            {
                ArgumentNullException ex = new ArgumentNullException("GetCRMShipper request CRMShipperID");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                ShipperManagementAccessor accessor = new ShipperManagementAccessor();
                response.Result = accessor.GetCRMShipperTransportationLinesByCRMShipperID(request.CRMShipperID.Value);
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

        public Response<bool> DeleteCRMShipper(CRMShipperOperationRequest request)
        {
            Response<bool> response = new Response<bool> { Result = false };

            if (request == null || !request.CRMShipperID.HasValue || request.CRMShipperID.Value == 0)
            {
                ArgumentNullException ex = new ArgumentNullException("GetCRMShipper request CRMShipperID");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                ShipperManagementAccessor accessor = new ShipperManagementAccessor();
                accessor.DeleteCRMShipper(request.CRMShipperID.Value);
                response.Result = true;
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

        public Response<bool> DeleteCRMShipperTransportationLine(CRMShipperOperationRequest request)
        {
            Response<bool> response = new Response<bool> { Result = false };

            if (request == null || !request.CRMShipperTransportationLineID.HasValue || request.CRMShipperTransportationLineID.Value == 0)
            {
                ArgumentNullException ex = new ArgumentNullException("DeleteCRMShipperTransportationLine request CRMShipperTransportationLineID");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                ShipperManagementAccessor accessor = new ShipperManagementAccessor();
                accessor.DeleteCRMShipperTransportationLine(request.CRMShipperTransportationLineID.Value);
                response.Result = true;
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

        public Response<bool> DeleteCRMShipperTerminalInfo(CRMShipperOperationRequest request)
        {
            Response<bool> response = new Response<bool> { Result = false };

            if (request == null || !request.CRMShipperTerminalInfoID.HasValue || request.CRMShipperTerminalInfoID.Value == 0)
            {
                ArgumentNullException ex = new ArgumentNullException("DeleteCRMShipperTerminalInfo request CRMShipperTerminalInfoID");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                ShipperManagementAccessor accessor = new ShipperManagementAccessor();
                accessor.DeleteCRMShipperTerminalInfo(request.CRMShipperTerminalInfoID.Value);
                response.Result = true;
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

        public Response<bool> DeleteCRMShipperCooperation(CRMShipperOperationRequest request)
        {
            Response<bool> response = new Response<bool> { Result = false };

            if (request == null || !request.CRMShipperCooperationID.HasValue || request.CRMShipperCooperationID.Value == 0)
            {
                ArgumentNullException ex = new ArgumentNullException("GetCRMShipper request CRMShipperCooperationID");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                ShipperManagementAccessor accessor = new ShipperManagementAccessor();
                accessor.DeleteCRMShipperCooperation(request.CRMShipperCooperationID.Value);
                response.Result = true;
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

        public Response<IEnumerable<long>> AddOrUpdateShippers(AddOrUpdateCRMShippersRequest request)
        {
            Response<IEnumerable<long>> response = new Response<IEnumerable<long>>();

            if (request == null || request.ShipperCollection == null || !request.ShipperCollection.Any())
            {
                ArgumentNullException ex = new ArgumentNullException("AddOrUpdateCRMShippers request");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                ShipperManagementAccessor accessor = new ShipperManagementAccessor();
                response.Result = accessor.AddOrUpdateCRMShippers(request.ShipperCollection);
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

        public Response<IEnumerable<long>> AddOrUpdateCRMShipperCooperations(AddOrUpdateCRMShipperCooperationsRequest request)
        {
            Response<IEnumerable<long>> response = new Response<IEnumerable<long>>();

            if (request == null || request.ShipperCooperationCollection == null || !request.ShipperCooperationCollection.Any())
            {
                ArgumentNullException ex = new ArgumentNullException("AddOrUpdateCRMShipperCooperations request");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                ShipperManagementAccessor accessor = new ShipperManagementAccessor();
                response.Result = accessor.AddOrUpdateCRMShipperCooperations(request.ShipperCooperationCollection);
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

        public Response<IEnumerable<ShipperTransportationLine>> AddOrUpdateCRMShipperTransportationLines(AddOrUpdateCRMShipperTransportationLineRequest request)
        {
            Response<IEnumerable<ShipperTransportationLine>> response = new Response<IEnumerable<ShipperTransportationLine>>();

            if (request == null || request.ShipperTransportationLineCollection == null || !request.ShipperTransportationLineCollection.Any())
            {
                ArgumentNullException ex = new ArgumentNullException("AddOrUpdateCRMShipperTransportationLines request");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                ShipperManagementAccessor accessor = new ShipperManagementAccessor();
                response.Result = accessor.AddOrUpdateCRMShipperTransportationLines(request.ShipperTransportationLineCollection);
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

        public Response<IEnumerable<ShipperTerminalInfo>> AddOrUpdateCRMShipperTerminalInfos(AddOrUpdateCRMShipperTerminalInfoRequest request)
        {
            Response<IEnumerable<ShipperTerminalInfo>> response = new Response<IEnumerable<ShipperTerminalInfo>>();

            if (request == null || request.ShipperTerminalInfoCollection == null || !request.ShipperTerminalInfoCollection.Any())
            {
                ArgumentNullException ex = new ArgumentNullException("AddOrUpdateCRMShipperTerminalInfos request");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                ShipperManagementAccessor accessor = new ShipperManagementAccessor();
                response.Result = accessor.AddOrUpdateCRMShipperTerminalInfos(request.ShipperTerminalInfoCollection);
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

        /// <summary>
        /// 查询当前承运商已选择的车辆
        /// </summary>
        /// <returns></returns>
        public Response<IEnumerable<ShipperVehicleMapping>> GetShipperToVehicle(ShipperMappingVehicleRequest request)
        {

            Response<IEnumerable<ShipperVehicleMapping>> response = new Response<IEnumerable<ShipperVehicleMapping>>();

            if (request == null)
            {
                ArgumentNullException ex = new ArgumentNullException("GetShipperToVehicle request");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }
            try
            {
                ShipperManagementAccessor stv = new ShipperManagementAccessor();
                response.Result = stv.GetShipperToVehicle(request.SID);
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


        //所有承运商
        public Response<IEnumerable<Shipper>> GetShipperList()
        {
            Response<IEnumerable<Shipper>> response = new Response<IEnumerable<Shipper>>();

            try
            {
                response.Result = new ShipperManagementAccessor().GetAllShippers();
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
