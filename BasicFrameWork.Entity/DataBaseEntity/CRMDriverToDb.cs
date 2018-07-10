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
    public class CRMDriverToDb : SqlDataRecord
    {
        public CRMDriverToDb(Driver Driver)
            : base(s_metadata)
        {
            SetSqlInt64(0, Driver.ID);
            SetSqlString(1, Driver.DriverName);
            SetSqlDateTime(2, Driver.DriverBirthday);
            SetSqlString(3, Driver.DriverPhone);
            SetSqlString(4, Driver.DriverLogisticsCompany);
            SetSqlDateTime(5, Driver.DriverStartServeForRunbowDate);
            SetSqlString(6, Driver.DriverIDCard);
            SetSqlString(7, Driver.DriverLogisticsContactPerson);
            SetSqlString(8, Driver.DriverCardNo);
            SetSqlString(9, Driver.DriverLogisticsCompanyContactPhone);
            SetSqlString(10, Driver.DriverCardType);
            SetSqlBoolean(11, Driver.DriverIsServing);
            SetSqlString(12, Driver.DriverRegistrationNo);
            SetSqlString(13, Driver.DriverRegistrationCardSignedAddress);
            SetSqlDateTime(14, Driver.DriverNextYearCheckDate);
            SetSqlDateTime(15, Driver.DriverFirstTimeGetCardDate);
            SetSqlDateTime(16, Driver.DriverNextYearCheckBodyDate);
            SetSqlString(17, Driver.DriverServiceArea);
            SetSqlString(18, Driver.DriverCarNo);
            SetSqlString(19, Driver.DriverMainRoute);
            SetSqlDateTime(20, Driver.CreateTime ?? SqlTypes.SqlDateTime.Null);
            SetSqlString(21, Driver.CreateUser);
            SetSqlDateTime(22, Driver.UpdateTime ?? SqlTypes.SqlDateTime.Null);
            SetSqlString(23, Driver.UpdateUser);
            SetSqlString(24, Driver.Str1);
            SetSqlString(25, Driver.Str2);
            SetSqlString(26, Driver.Str3);
            SetSqlString(27, Driver.Str4);
            SetSqlString(28, Driver.Str5);
            SetSqlString(29, Driver.Str6);
            SetSqlString(30, Driver.Str7);
            SetSqlString(31, Driver.Str8);
            SetSqlString(32, Driver.Str9);
            SetSqlString(33, Driver.Str10);
            SetSqlString(34, Driver.Str11);
            SetSqlString(35, Driver.Str12);
            SetSqlString(36, Driver.Str13);
            SetSqlString(37, Driver.Str14);
            SetSqlString(38, Driver.Str15);
            SetSqlString(39, Driver.Str16);
            SetSqlString(40, Driver.Str17);
            SetSqlString(41, Driver.Str18);
            SetSqlString(42, Driver.Str19);
            SetSqlString(43, Driver.Str20);
            SetSqlDateTime(44, Driver.Datetime1 ?? SqlTypes.SqlDateTime.Null);
            SetSqlDateTime(45, Driver.Datetime2 ?? SqlTypes.SqlDateTime.Null);
            SetSqlDateTime(46, Driver.Datetime3 ?? SqlTypes.SqlDateTime.Null);
            SetSqlDateTime(47, Driver.Datetime4 ?? SqlTypes.SqlDateTime.Null);
            SetSqlDateTime(48, Driver.Datetime5 ?? SqlTypes.SqlDateTime.Null);
            SetSqlBoolean(49, Driver.Bit1);
            SetSqlBoolean(50, Driver.Bit2);
            SetSqlBoolean(51, Driver.Bit3);
      

        }


        private static readonly SqlMetaData[] s_metadata =
        {
          new SqlMetaData("ID", SqlDbType.BigInt),
          new SqlMetaData("DriverName", SqlDbType.NVarChar, 50),
          new SqlMetaData("DriverBirthday", SqlDbType.Date),
          new SqlMetaData("DriverPhone", SqlDbType.NVarChar, 50),
          new SqlMetaData("DriverLogisticsCompany", SqlDbType.NVarChar, 50),
          new SqlMetaData("DriverStartServeForRunbowDate", SqlDbType.Date),
          new SqlMetaData("DriverIDCard", SqlDbType.NVarChar, 50),
          new SqlMetaData("DriverLogisticsContactPerson", SqlDbType.NVarChar, 50),
          new SqlMetaData("DriverCardNo", SqlDbType.NVarChar, 50),
          new SqlMetaData("DriverLogisticsCompanyContactPhone", SqlDbType.NVarChar, 50),
          new SqlMetaData("DriverCardType", SqlDbType.NVarChar, 50),
          new SqlMetaData("DriverIsServing", SqlDbType.Bit),
          new SqlMetaData("DriverRegistrationNo", SqlDbType.NVarChar, 50),
          new SqlMetaData("DriverRegistrationCardSignedAddress", SqlDbType.NVarChar, 100),
          new SqlMetaData("DriverNextYearCheckDate", SqlDbType.Date),
          new SqlMetaData("DriverFirstTimeGetCardDate", SqlDbType.Date),
          new SqlMetaData("DriverNextYearCheckBodyDate", SqlDbType.Date),
          new SqlMetaData("DriverServiceArea", SqlDbType.NVarChar, 100),
          new SqlMetaData("DriverCarNo", SqlDbType.NVarChar, 50),
          new SqlMetaData("DriverMainRoute", SqlDbType.NVarChar, 200),
          new SqlMetaData("CreateTime", SqlDbType.DateTime),
          new SqlMetaData("CreateUser", SqlDbType.NVarChar, 50),
          new SqlMetaData("UpdateTime", SqlDbType.DateTime),
          new SqlMetaData("UpdateUser", SqlDbType.NVarChar, 50),
          new SqlMetaData("Str1", SqlDbType.NVarChar, 50),
          new SqlMetaData("Str2", SqlDbType.NVarChar, 50),
          new SqlMetaData("Str3", SqlDbType.NVarChar, 50),
          new SqlMetaData("Str4", SqlDbType.NVarChar, 50),
          new SqlMetaData("Str5", SqlDbType.NVarChar, 50),
          new SqlMetaData("Str6", SqlDbType.NVarChar, 50),
          new SqlMetaData("Str7", SqlDbType.NVarChar, 50),
          new SqlMetaData("Str8", SqlDbType.NVarChar, 50),
          new SqlMetaData("Str9", SqlDbType.NVarChar, 50),
          new SqlMetaData("Str10", SqlDbType.NVarChar, 50),
          new SqlMetaData("Str11", SqlDbType.NVarChar, 50),
          new SqlMetaData("Str12", SqlDbType.NVarChar, 50),
          new SqlMetaData("Str13", SqlDbType.NVarChar, 50),
          new SqlMetaData("Str14", SqlDbType.NVarChar, 50),
          new SqlMetaData("Str15", SqlDbType.NVarChar, 50),
          new SqlMetaData("Str16", SqlDbType.NVarChar, 50),
          new SqlMetaData("Str17", SqlDbType.NVarChar, 50),
          new SqlMetaData("Str18", SqlDbType.NVarChar, 50),
          new SqlMetaData("Str19", SqlDbType.NVarChar, 50),
          new SqlMetaData("Str20", SqlDbType.NVarChar, 50),
          new SqlMetaData("Datetime1", SqlDbType.DateTime),
          new SqlMetaData("Datetime2", SqlDbType.DateTime),
          new SqlMetaData("Datetime3", SqlDbType.DateTime),
          new SqlMetaData("Datetime4", SqlDbType.DateTime),
          new SqlMetaData("Datetime5", SqlDbType.DateTime),
          new SqlMetaData("Bit1", SqlDbType.Bit),
          new SqlMetaData("Bit2", SqlDbType.Bit),
          new SqlMetaData("Bit3", SqlDbType.Bit),
        };
    }
}
