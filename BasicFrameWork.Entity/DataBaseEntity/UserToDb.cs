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
    public class UserToDb : SqlDataRecord
    {
        public UserToDb(User user)
            : base(s_metadata)
        {
            SetSqlInt64(0, user.ID);
            SetSqlString(1, user.Name);
            SetSqlString(2, user.DisplayName);
            SetSqlString(3, user.Password);
            SetSqlBoolean(4, user.State ?? true);
            SetSqlString(5, user.Sex.ToString());
            SetSqlString(6, user.Tel);
            SetSqlString(7, user.Mobile);
            SetSqlString(8, user.Email);
            SetSqlDateTime(9, user.CreateDate);
            SetSqlInt32(10, user.UserType ?? 0);
        }


        private static readonly SqlMetaData[] s_metadata =
        {
          new SqlMetaData("ID", SqlDbType.BigInt),
          new SqlMetaData("Name", SqlDbType.NVarChar, 50),
          new SqlMetaData("DisplayName", SqlDbType.NVarChar,50),
          new SqlMetaData("Password", SqlDbType.NVarChar, 50),
          new SqlMetaData("State",  SqlDbType.Bit),
          new SqlMetaData("Sex",  SqlDbType.NVarChar,1),
          new SqlMetaData("Tel", SqlDbType.NVarChar, 50),
          new SqlMetaData("Mobile", SqlDbType.NVarChar, 50),
          new SqlMetaData("Email", SqlDbType.NVarChar, 50),
          new SqlMetaData("CreateDate",  SqlDbType.Date),
          new SqlMetaData("UserType", SqlDbType.Int)
        };
    }
}
