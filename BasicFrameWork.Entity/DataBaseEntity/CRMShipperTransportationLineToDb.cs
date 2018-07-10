using System;
using System.Data;
using Microsoft.SqlServer.Server;
using SqlTypes = global::System.Data.SqlTypes;

namespace BasicFramework.Entity
{
    public class ShipperTransportationLineToDb : SqlDataRecord
    {
        public ShipperTransportationLineToDb(ShipperTransportationLine shipperTransportationLine)
            : base(s_metadata)
        {
            SetSqlInt64(0, shipperTransportationLine.ID);
            SetSqlInt64(1, shipperTransportationLine.CRMShipperID);
            SetSqlInt64(2, shipperTransportationLine.StartCityID);
            SetSqlString(3, shipperTransportationLine.StartCityName);
            SetSqlInt64(4, shipperTransportationLine.EndCityID);
            SetSqlString(5, shipperTransportationLine.EndCityName);
            SetSqlInt64(6, shipperTransportationLine.CoverRegionID);
            SetSqlString(7, shipperTransportationLine.CoverRegionName);
            SetSqlInt32(8, shipperTransportationLine.Period ?? SqlTypes.SqlInt32.Null);
            SetSqlString(9, shipperTransportationLine.Str1);
            SetSqlString(10, shipperTransportationLine.Str2);
            SetSqlString(11, shipperTransportationLine.Str3);
            SetSqlString(12, shipperTransportationLine.Str4);
            SetSqlString(13, shipperTransportationLine.Str5);
            SetSqlDateTime(14, shipperTransportationLine.DateTime1 ?? SqlTypes.SqlDateTime.Null);
            SetSqlDateTime(15, shipperTransportationLine.DateTime2 ?? SqlTypes.SqlDateTime.Null);
            SetSqlInt64(16, shipperTransportationLine.Bigint1 ?? SqlTypes.SqlInt64.Null);
            SetSqlInt32(17, shipperTransportationLine.Int1 ?? SqlTypes.SqlInt32.Null);
            SetSqlBoolean(18, shipperTransportationLine.Bit1 ?? SqlTypes.SqlBoolean.Null);
        }

        private static readonly SqlMetaData[] s_metadata =
        {
            new SqlMetaData("ID", SqlDbType.BigInt),
            new SqlMetaData("CRMShipperID", SqlDbType.BigInt),
            new SqlMetaData("StartCityID", SqlDbType.BigInt),
            new SqlMetaData("StartCityName", SqlDbType.NVarChar,50),
            new SqlMetaData("EndCityID", SqlDbType.BigInt),
            new SqlMetaData("EndCityName", SqlDbType.NVarChar,50),
            new SqlMetaData("CoverRegionID", SqlDbType.BigInt),
            new SqlMetaData("CoverRegionName", SqlDbType.NVarChar,50),
            new SqlMetaData("Period", SqlDbType.Int),
            new SqlMetaData("Str1", SqlDbType.NVarChar,100),
            new SqlMetaData("Str2", SqlDbType.NVarChar,100),
            new SqlMetaData("Str3", SqlDbType.NVarChar,100),
            new SqlMetaData("Str4", SqlDbType.NVarChar,100),
            new SqlMetaData("Str5", SqlDbType.NVarChar,100),
            new SqlMetaData("DateTime1", SqlDbType.DateTime),
            new SqlMetaData("DateTime2", SqlDbType.DateTime),
            new SqlMetaData("Bigint1",SqlDbType.BigInt),
            new SqlMetaData("Int1",SqlDbType.Int),
            new SqlMetaData("Bit1",SqlDbType.Bit)
        };
    }
}
