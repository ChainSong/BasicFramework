using System;
using System.Data;
using Microsoft.SqlServer.Server;
using SqlTypes = global::System.Data.SqlTypes;

namespace BasicFramework.Entity
{
    public class ShipperCoopperationToDb : SqlDataRecord
    {
        public ShipperCoopperationToDb(ShipperCooperation shipperCopperation)
            : base(s_metadata)
        {
            SetSqlInt64(0, shipperCopperation.ID);
            SetSqlInt64(1, shipperCopperation.CRMShipperID);
            SetSqlString(2, shipperCopperation.Name);
            SetSqlString(3, shipperCopperation.Remark);
            SetSqlString(4, shipperCopperation.AttachmentGroupID);
            SetSqlString(5, shipperCopperation.Str1);
            SetSqlString(6, shipperCopperation.Str2);
            SetSqlString(7, shipperCopperation.Str3);
            SetSqlString(8, shipperCopperation.Str4);
            SetSqlString(9, shipperCopperation.Str5);
            SetSqlString(10, shipperCopperation.Str6);
            SetSqlString(11, shipperCopperation.Str7);
            SetSqlString(12, shipperCopperation.Str8);
            SetSqlString(13, shipperCopperation.Str9);
            SetSqlString(14, shipperCopperation.Str10);
            SetSqlDateTime(15, shipperCopperation.DateTime1 ?? SqlTypes.SqlDateTime.Null);
            SetSqlDateTime(16, shipperCopperation.DateTime2 ?? SqlTypes.SqlDateTime.Null);
            SetSqlInt64(17, shipperCopperation.Bigint1 ?? SqlTypes.SqlInt64.Null);
            SetSqlInt32(18, shipperCopperation.Int1 ?? SqlTypes.SqlInt32.Null);
            SetSqlBoolean(19, shipperCopperation.Bit1 ?? SqlTypes.SqlBoolean.Null);
        }

        private static readonly SqlMetaData[] s_metadata =
        {
            new SqlMetaData("ID", SqlDbType.BigInt),
            new SqlMetaData("CRMShipperID", SqlDbType.BigInt),
            new SqlMetaData("Name", SqlDbType.NVarChar,100),
            new SqlMetaData("Remark", SqlDbType.NVarChar,500),
            new SqlMetaData("AttachmentGroupID", SqlDbType.NVarChar,50),
            new SqlMetaData("Str1", SqlDbType.NVarChar,100),
            new SqlMetaData("Str2", SqlDbType.NVarChar,100),
            new SqlMetaData("Str3", SqlDbType.NVarChar,100),
            new SqlMetaData("Str4", SqlDbType.NVarChar,100),
            new SqlMetaData("Str5", SqlDbType.NVarChar,100),
            new SqlMetaData("Str6", SqlDbType.NVarChar,50),
            new SqlMetaData("Str7", SqlDbType.NVarChar,50),
            new SqlMetaData("Str8", SqlDbType.NVarChar,50),
            new SqlMetaData("Str9", SqlDbType.NVarChar,50),
            new SqlMetaData("Str10", SqlDbType.NVarChar,50),
            new SqlMetaData("DateTime1", SqlDbType.DateTime),
            new SqlMetaData("DateTime2", SqlDbType.DateTime),
            new SqlMetaData("Bigint1",SqlDbType.BigInt),
            new SqlMetaData("Int1",SqlDbType.Int),
            new SqlMetaData("Bit1",SqlDbType.Bit)
        };
    }
}
