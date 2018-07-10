using System;
using System.Linq;
using System.Collections.Generic;
using BasicFramework.Common;
using BasicFramework.Dao;
using BasicFramework.Entity;
using BasicFramework.MessageContracts;
using BasicFramework.Common;

namespace BasicFramework.Biz
{
    public class MappingService : BaseService
    {
        public Response<IEnumerable<UserRoleMapping>> GetUserRoleMapping()
        {
            Response<IEnumerable<UserRoleMapping>> response = new Response<IEnumerable<UserRoleMapping>>();

            try
            {
                MappingAccessor accessor = new MappingAccessor();
                response.Result = accessor.GetUserRoleMapping();
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

        public Response<int> AddOrUpdateUserRoleMapping(AddOrUpdateMappingRequest request)
        {
            Response<int> response = new Response<int>();

            if (request == null || request.MapingCollection == null || !request.MapingCollection.Any())
            {
                ArgumentNullException ex = new ArgumentNullException("AddOrUpdateUserRoleMapping request");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                IList<UserRoleMapping> userRoleMappingCollection = new List<UserRoleMapping>();
                request.MapingCollection.Each((i, m) =>
                {
                    userRoleMappingCollection.Add(new UserRoleMapping()
                    {
                        UserID = m.SourceID,
                        RoleID = m.DestID,
                        CreateDate = DateTime.Now,
                        State = m.DestID == 0 ? false : true
                    });
                });

                MappingAccessor accessor = new MappingAccessor();
                response.Result = accessor.AddOrUpdateUserRoleMapping(userRoleMappingCollection);
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

        public Response<int> AddRoleMenuMapping(AddOrUpdateMappingRequest request)
        {
            Response<int> response = new Response<int>();

            if (request == null || request.MapingCollection == null || !request.MapingCollection.Any())
            {
                ArgumentNullException ex = new ArgumentNullException("AddOrUpdateUserRoleMapping request");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                MappingAccessor accessor = new MappingAccessor();
                response.Result = accessor.AddRoleMenuMapping(request.MapingCollection);
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

        public Response<IEnumerable<RoleMenu>> GetAllRoleMenus()
        {
            Response<IEnumerable<RoleMenu>> response = new Response<IEnumerable<RoleMenu>>();
            try
            {
                MappingAccessor accessor = new MappingAccessor();
                response.Result = accessor.GetAllRoleMenus();
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
