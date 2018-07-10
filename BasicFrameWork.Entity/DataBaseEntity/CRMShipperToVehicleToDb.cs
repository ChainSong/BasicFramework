using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using BasicFramework.Entity.ShipperManagement;
using SqlTypes = global::System.Data.SqlTypes;

namespace BasicFramework.Entity.DataBaseEntity
{
    public class CRMShipperToVehicleToDb : SqlDataRecord
    {
        public CRMShipperToVehicleToDb(CRMCar vehicle)
            : base(s_metadata)
        {
            SetSqlInt64(0, vehicle.ID);
            SetSqlInt64(1, vehicle.SID);
            SetSqlInt64(2, vehicle.VID);
            SetSqlDateTime(3, vehicle.CreateTime ?? SqlTypes.SqlDateTime.Null);
            SetSqlString(4, vehicle.CreateUser);
            SetSqlString(5, vehicle.ShipperName);
            SetSqlString(6, vehicle.VehicleNo);
            SetSqlString(7, vehicle.Remark);


        }

        private static readonly SqlMetaData[] s_metadata =
        {
            new SqlMetaData("ID", SqlDbType.BigInt),
            new SqlMetaData("SID", SqlDbType.BigInt),
            new SqlMetaData("VID", SqlDbType.BigInt),
            new SqlMetaData("CreateTime", SqlDbType.DateTime),
            new SqlMetaData("CreateUser", SqlDbType.NVarChar,50),
            new SqlMetaData("ShipperName", SqlDbType.NVarChar,50),
            new SqlMetaData("VehicleNo", SqlDbType.NVarChar,50),
            new SqlMetaData("Remark", SqlDbType.NVarChar,50),
           
        };
    }
}
