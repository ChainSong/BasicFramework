using System;
using System.Collections.Generic;
using System.Linq;
using BasicFramework.Common;
using BasicFramework.Dao;
using BasicFramework.Entity;
using BasicFramework.Entity.System;
using BasicFramework.MessageContracts;

namespace BasicFramework.Biz
{
    public class UserService : BaseService
    {
        public Response<int> AddOrUpdateUsers(AddOrUpdateUserRequest request)
        {
            Response<int> response = new Response<int>();

            if (request == null || request.UserCollection == null || !request.UserCollection.Any())
            {
                ArgumentNullException ex = new ArgumentNullException("AddOrUpdateUser request");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                UserAccessor accessor = new UserAccessor();
                response.Result = accessor.AddOrUpdateUsers(request.UserCollection);
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

        public Response<User> GetUserInfo(GetObjectByIDRequest request)
        {
            Response<User> response = new Response<User>();
            if (request == null || request.ID == 0)
            {
                ArgumentNullException ex = new ArgumentNullException("GetUserInfo request");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                UserAccessor accessor = new UserAccessor();
                response.Result = accessor.GetUserById(request.ID);
                if (response.Result == null)
                {
                    response.IsSuccess = false;
                    response.ErrorCode = ErrorCode.DataEffective;
                }
                else
                {
                    response.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                response.IsSuccess = false;
                response.ErrorCode = ErrorCode.Technical;
            }

            return response;
        }

        public Response<UserRequestAndResponse> GetUsersByCondition(UserRequestAndResponse request)
        {
            Response<UserRequestAndResponse> response = new Response<UserRequestAndResponse>() { Result = new UserRequestAndResponse() };
            if (request == null)
            {
                ArgumentNullException ex = new ArgumentNullException("GetUsersInfo request");
                LogError(ex);
                response.IsSuccess = false;
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                UserAccessor accessor = new UserAccessor();
                int rowCount;
                response.Result.UserCollection = accessor.GetUsersByCondition(request.User, request.PageIndex, request.PageSize, out rowCount).ToList();
                response.Result.TotalCount = rowCount;
                response.Result.PageIndex = request.PageIndex;
                response.Result.PageCount = rowCount % request.PageSize == 0 ? rowCount / request.PageSize : rowCount / request.PageSize + 1;
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

        public Response<IEnumerable<User>> GetAllUsers()
        {
            Response<IEnumerable<User>> response = new Response<IEnumerable<User>>();

            try
            {
                response.Result = new UserAccessor().GetAllUsers();
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