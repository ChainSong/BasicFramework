using System;
using System.Collections.Generic;
using System.Linq;
using BasicFramework.Biz;
using BasicFramework.Common;
using BasicFramework.Dao;
using BasicFramework.Entity;
using BasicFramework.MessageContracts;
using BasicFramework.Dao;
using BasicFramework.MessageContracts;

namespace BasicFramework.Biz
{
    public class RegionService : BaseService
    {
        public Response<Region> AddRegion(AddRegionRequest request)
        {
            Response<Region> response = new Response<Region>();
            if (request == null || request.Region == null)
            {
                ArgumentNullException ex = new ArgumentNullException("AddRegionRequest request");
                LogError(ex);
                response.ErrorCode = ErrorCode.Argument;
                response.Exception = ex;
                return response;
            }

            try
            {
                RegionAccessor accessor = new RegionAccessor();
                response.Result = accessor.AddRegion(request.Region);
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
