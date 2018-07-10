using System;
using System.Linq;
using System.Collections.Generic;
using BasicFramework.Common;
using BasicFramework.Dao;
using BasicFramework.Entity;
using BasicFramework.MessageContracts;

namespace BasicFramework.Biz
{
    public class RoleService : BaseService
    {
        public Response<int> AddOrUpdateRoles(AddOrUpdateRoleRequest request)
        {
            Response<int> response = new Response<int>();

            if (request == null || request.RoleCollection == null || !request.RoleCollection.Any())
            {
                ArgumentNullException ex = new ArgumentNullException("AddOrUpdateRole request");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                RoleAccessor accessor = new RoleAccessor();
                response.Result = accessor.AddOrUpdateRoles(request.RoleCollection);
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

        public Response<Role> GetRoleInfo(GetObjectByIDRequest request)
        {
            Response<Role> response = new Response<Role>();

            if (request == null || request.ID == 0)
            {
                ArgumentNullException ex = new ArgumentNullException("GetRoleByID request");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                RoleAccessor accessor = new RoleAccessor();
                response.Result = accessor.GetRoleByID(request.ID);
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
        /// 获取crm信息
        /// </summary>
        /// <param name="Sqlwhere"></param>
        /// <returns></returns>
        public Response<RoleRequestAndResponse> GetRolesByCondition(RoleRequestAndResponse request)
        {
            Response<RoleRequestAndResponse> response = new Response<RoleRequestAndResponse>() { Result = new RoleRequestAndResponse() };
            if (request == null)
            {
                ArgumentNullException ex = new ArgumentNullException("GetCRMInfoByID request");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                RoleAccessor Roleccessor = new RoleAccessor();
                int Rowcount;


                response.Result.RoleCollection = Roleccessor.GetRolesByCondition(request.Role, request.PageIndex, request.PageSize, out Rowcount);
                response.Result.PageIndex = request.PageIndex;
                response.Result.TotalCount = Rowcount;
                response.Result.PageCount = Rowcount % request.PageSize == 0 ? Rowcount / request.PageSize : Rowcount / request.PageSize + 1;
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                LogError(ex);
                response.IsSuccess = false;
                response.Exception = ex;
                response.ErrorCode = ErrorCode.Technical;
            }

            return response;
        }
    }
}