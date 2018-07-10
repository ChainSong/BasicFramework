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
    public class SimpleMappingToDb : SqlDataRecord
    {
        public SimpleMappingToDb(Mapping mapping)
            : base(s_metadata)
        {
            SetSqlInt64(0, 0);
            SetSqlInt64(1, mapping.SourceID);
            SetSqlInt64(2, mapping.DestID);
            SetSqlDateTime(3, DateTime.Now);
            SetSqlBoolean(4, true);
        }


        private static readonly SqlMetaData[] s_metadata =
        {
          new SqlMetaData("ID", SqlDbType.BigInt),
          new SqlMetaData("SourceID", SqlDbType.BigInt),
          new SqlMetaData("DestID", SqlDbType.BigInt),
          new SqlMetaData("CreateDate",  SqlDbType.Date),
          new SqlMetaData("State",  SqlDbType.Bit)
        };
    }
}
