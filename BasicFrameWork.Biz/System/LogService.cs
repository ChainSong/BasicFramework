using System;
using System.Collections.Generic;
using System.Linq;
using BasicFramework.Common;
using BasicFramework.Dao;
using BasicFramework.Entity;
using BasicFramework.Entity.System;
using BasicFramework.MessageContracts;

namespace BasicFramework.Biz.System
{
    public class LogService : BaseService
    {
        public void Log(LogRequest request)
        {
            if (request == null || request.LogHistory == null)
            {
                ArgumentNullException ex = new ArgumentNullException("EditUser request");
                LogError(ex);
            }

            try
            {
                LogAccessor accessor = new LogAccessor();
                accessor.Log(request.LogHistory);
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }
    }
}
