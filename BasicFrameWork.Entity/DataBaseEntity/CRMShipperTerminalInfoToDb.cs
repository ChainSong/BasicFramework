using System;
using System.Data;
using Microsoft.SqlServer.Server;
using SqlTypes = global::System.Data.SqlTypes;

namespace BasicFramework.Entity
{
    public class ShipperTerminalInfoToDb : SqlDataRecord
    {
        public ShipperTerminalInfoToDb(ShipperTerminalInfo crmShipperTerminalInfo)
            : base(s_metadata)
        {
            SetSqlInt64(0, crmShipperTerminalInfo.ID);
            SetSqlInt64(1, crmShipperTerminalInfo.CRMShipperID);
            SetSqlString(2, crmShipperTerminalInfo.TerminalAddress);
            SetSqlString(3, crmShipperTerminalInfo.IsOwn);
            SetSqlString(4, crmShipperTerminalInfo.TerminalOfficeArea);
            SetSqlString(5, crmShipperTerminalInfo.TerminalWareHouseArea);
            SetSqlString(6, crmShipperTerminalInfo.TerminalWareHouseAreaRange);
            SetSqlString(7, crmShipperTerminalInfo.TerminalNumberOfEmployees);
            SetSqlString(8, crmShipperTerminalInfo.TerminalNumberOfCustomerService);
            SetSqlString(9, crmShipperTerminalInfo.TerminalNumberOfStevedores);
            SetSqlString(10, crmShipperTerminalInfo.TerminalForkliftsUsage);
            SetSqlString(11, crmShipperTerminalInfo.TerminalLoadingPlatform);
            SetSqlString(12, crmShipperTerminalInfo.TerminalDeliveryVehicles);
            SetSqlString(13, crmShipperTerminalInfo.Str1);
            SetSqlString(14, crmShipperTerminalInfo.Str2);
            SetSqlString(15, crmShipperTerminalInfo.Str3);
            SetSqlString(16, crmShipperTerminalInfo.Str4);
            SetSqlString(17, crmShipperTerminalInfo.Str5);
            SetSqlDateTime(18, crmShipperTerminalInfo.DateTime1 ?? SqlTypes.SqlDateTime.Null);
            SetSqlDateTime(19, crmShipperTerminalInfo.DateTime2 ?? SqlTypes.SqlDateTime.Null);
            SetSqlInt64(20, crmShipperTerminalInfo.Bigint1 ?? SqlTypes.SqlInt64.Null);
            SetSqlInt32(21, crmShipperTerminalInfo.Int1 ?? SqlTypes.SqlInt32.Null);
            SetSqlBoolean(22, crmShipperTerminalInfo.Bit1 ?? SqlTypes.SqlBoolean.Null);
        }

        private static readonly SqlMetaData[] s_metadata =
        {
            new SqlMetaData("ID", SqlDbType.BigInt),
            new SqlMetaData("CRMShipperID", SqlDbType.BigInt),
            new SqlMetaData("TerminalAddress", SqlDbType.NVarChar,100),
            new SqlMetaData("IsOwn", SqlDbType.NVarChar,100),
            new SqlMetaData("TerminalOfficeArea", SqlDbType.NVarChar,100),
            new SqlMetaData("TerminalWareHouseArea", SqlDbType.NVarChar,100),
            new SqlMetaData("TerminalWareHouseAreaRange", SqlDbType.NVarChar,100),
            new SqlMetaData("TerminalNumberOfEmployees", SqlDbType.NVarChar,100),
            new SqlMetaData("TerminalNumberOfCustomerService", SqlDbType.NVarChar,100),
            new SqlMetaData("TerminalNumberOfStevedores", SqlDbType.NVarChar,100),
            new SqlMetaData("TerminalForkliftsUsage", SqlDbType.NVarChar,100),
            new SqlMetaData("TerminalLoadingPlatform", SqlDbType.NVarChar,100),
            new SqlMetaData("TerminalDeliveryVehicles", SqlDbType.NVarChar,100),
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
