using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using BasicFramework.Entity.ShipperManagement.DriverManagement;
using SqlTypes = global::System.Data.SqlTypes;

namespace BasicFramework.Entity.DataBaseEntity
{
    public class UserRoleMappingToDb : SqlDataRecord
    {
        public UserRoleMappingToDb(UserRoleMapping userRoleMapping)
            : base(s_metadata)
        {
            SetSqlInt64(0, userRoleMapping.ID);
            SetSqlInt64(1, userRoleMapping.UserID);
            SetSqlInt64(2, userRoleMapping.RoleID);
            SetSqlDateTime(3, userRoleMapping.CreateDate);
            SetSqlBoolean(4, userRoleMapping.State);
        }


        private static readonly SqlMetaData[] s_metadata =
        {
          new SqlMetaData("ID", SqlDbType.BigInt),
          new SqlMetaData("UserID", SqlDbType.BigInt),
          new SqlMetaData("RoleID", SqlDbType.BigInt),
          new SqlMetaData("CreateDate",  SqlDbType.Date),
          new SqlMetaData("State",  SqlDbType.Bit)
        };
    }
}
