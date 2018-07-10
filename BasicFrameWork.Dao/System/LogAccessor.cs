using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicFramework.Entity;

namespace BasicFramework.Dao
{
    public class LogAccessor : BaseAccessor
    {
        public void Log(LogHistory logHistory)
        {
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@Name", DbType.String, string.IsNullOrEmpty(logHistory.Name) ?  System.Data.SqlTypes.SqlString.Null : logHistory.Name , ParameterDirection.Input),
                new DbParam("@Time", DbType.DateTime, logHistory.Time, ParameterDirection.Input),
                new DbParam("@Action", DbType.String, string.IsNullOrEmpty(logHistory.Action) ? System.Data.SqlTypes.SqlString.Null : logHistory.Action, ParameterDirection.Input)
            };

            this.ExecuteNoQuery("Proc_AddLog", dbParams);
        }
    }
}
