using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using BasicFramework.Entity.ShipperManagement.VehicleManagement;
using SqlTypes = global::System.Data.SqlTypes;

namespace BasicFramework.Entity.DataBaseEntity
{
    public class CRMVehicleToDriverToDb : SqlDataRecord
    {
        public CRMVehicleToDriverToDb(CRMDriverName driver)
            : base(s_metadata)
        {
            SetSqlInt64(0, driver.ID);
            SetSqlInt64(1, driver.VID);
            SetSqlInt64(2, driver.DID);
            SetSqlDateTime(3, driver.CreateTime ?? SqlTypes.SqlDateTime.Null);
            SetSqlString(4, driver.CreateUser);
            SetSqlString(5, driver.VehicleNo);
            SetSqlString(6, driver.DriverName);
            SetSqlString(7, driver.DriverPhone);


        }

        private static readonly SqlMetaData[] s_metadata =
        {
            new SqlMetaData("ID", SqlDbType.BigInt),
            new SqlMetaData("VID", SqlDbType.BigInt),
            new SqlMetaData("DID", SqlDbType.BigInt),
            new SqlMetaData("CreateTime", SqlDbType.DateTime),
            new SqlMetaData("CreateUser", SqlDbType.NVarChar,50),
            new SqlMetaData("VehicleNo", SqlDbType.NVarChar,50),
            new SqlMetaData("DriverName", SqlDbType.NVarChar,50),
            new SqlMetaData("DriverPhone", SqlDbType.NVarChar,50),
           
        };
    }
}
