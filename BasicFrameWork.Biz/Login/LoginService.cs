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
    public class LoginService : BaseService
    {
        public Response<User> CheckLogin(GetUserByCheckLoginRequest request)
        {
            Response<User> response = new Response<User>();
            if (request == null || string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.Password))
            {
                ArgumentNullException ex = new ArgumentNullException("CheckLogin request");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            LoginAccessor accessor = new LoginAccessor();
            try
            {
                response.Result = accessor.CheckLoginUser(request.Name, request.Password);
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
