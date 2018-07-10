using System;
using System.Collections.Generic;
using BasicFramework.Common;
using BasicFramework.Dao;
using BasicFramework.Entity;
using BasicFramework.MessageContracts;

namespace BasicFramework.Biz
{
    public class ConfigService : BaseService
    {
        public Response<IEnumerable<Config>> GetConfigs()
        {
            Response<IEnumerable<Config>> response = new Response<IEnumerable<Config>>();

            try
            {
                ConfigAccessor accessor = new ConfigAccessor();
                response.Result = accessor.GetConfigs();
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

        public Response<IEnumerable<Region>> GetRegions()
        {
            Response<IEnumerable<Region>> response = new Response<IEnumerable<Region>>();

            try
            {
                ConfigAccessor accessor = new ConfigAccessor();
                response.Result = accessor.GetRegions();
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

        public Response<IEnumerable<ApplicationConfig>> GetApplicationConfigs()
        {
            Response<IEnumerable<ApplicationConfig>> response = new Response<IEnumerable<ApplicationConfig>>();

            try
            {
                ConfigAccessor accessor = new ConfigAccessor();
                response.Result = accessor.GetApplicationConfigs();
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