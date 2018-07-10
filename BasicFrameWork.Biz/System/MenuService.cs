using System;
using System.Collections.Generic;
using BasicFramework.Common;
using BasicFramework.Dao;
using BasicFramework.Entity;
using BasicFramework.MessageContracts;

namespace BasicFramework.Biz
{
    public class MenuService : BaseService
    {
        public Response<IEnumerable<Menu>> GetApplicationMenus()
        {
            Response<IEnumerable<Menu>> response = new Response<IEnumerable<Menu>>();

            try
            {
                response.Result = new MenuAccessor().GetApplicationMenus();
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