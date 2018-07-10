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
    public class RolesToDb : SqlDataRecord
    {
        public RolesToDb(Role Role)
            : base(s_metadata)
        {
            SetSqlInt64(0, Role.ID);
            SetSqlString(1, Role.Name);
            SetSqlString(2, Role.Description);
            SetSqlBoolean(3, Role.State??true);
            SetSqlDateTime(4, Role.CreateDate);
        }


        private static readonly SqlMetaData[] s_metadata =
        {
          new SqlMetaData("ID", SqlDbType.BigInt),
          new SqlMetaData("Name", SqlDbType.NVarChar, 50),
          new SqlMetaData("Description", SqlDbType.NVarChar, 500),
          new SqlMetaData("State",  SqlDbType.Bit),
          new SqlMetaData("CreateDate",  SqlDbType.Date)
        };
    }
}
