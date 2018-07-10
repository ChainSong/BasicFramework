using Microsoft.SqlServer.Server;
using BasicFramework.Entity.ShipperManagement.VehicleManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlTypes = global::System.Data.SqlTypes;

namespace BasicFramework.Entity.DataBaseEntity
{
    public class CRMVehicleToDb: SqlDataRecord
    {
        public CRMVehicleToDb(Vehicle vehicle)
            : base(s_metadata)
        {
            SetSqlInt64(0, vehicle.ID);
            SetSqlString(1, vehicle.CarNo);
            SetSqlString(2, vehicle.RunNo);
            SetSqlString(3, vehicle.CarTypeNo);
            SetSqlString(4, vehicle.CarVin);
            SetSqlString(5, vehicle.SecurityContactNum);
            SetSqlString(6, vehicle.LogisticCompany);
            SetSqlDouble(7, vehicle.DrivedJourney);
            SetSqlString(8, vehicle.Qualify);
            SetSqlDateTime(9, vehicle.BoardlotDate);
            SetSqlInt32(10, vehicle.CarAge);
            SetSqlString(11, vehicle.CarNumType);
            SetSqlString(12, vehicle.FuelType);
            SetSqlString(13, vehicle.CarBodyColor);
            SetSqlString(14, vehicle.Manufacturer);
            SetSqlDateTime(15, vehicle.NextYearCheckDate);
            SetSqlString(16, vehicle.Velocity_transducers);
            SetSqlDateTime(17, vehicle.StartServiceDate);
            SetSqlDateTime(18, vehicle.InsuranceEndDate);
            SetSqlDouble(19, vehicle.EntireCarWeight);
            SetSqlString(20, vehicle.MainRoute);
            SetSqlDouble(21, vehicle.LoadWeight);
            SetSqlInt32(22, vehicle.LoadPerson);
            SetSqlString(23, vehicle.Size);
            SetSqlDouble(24, vehicle.TotalWeight);
            SetSqlDouble(25, vehicle.TractionWeight);
            SetSqlInt32(26, vehicle.SafetyBeltAmount);
            SetSqlBoolean(27, vehicle.BackUpBuzze);
            SetSqlBoolean(28, vehicle.TheTankerOilSpillProtectionDevice);
            SetSqlBoolean(29, vehicle.OilSpillPreventiontools);
            SetSqlBoolean(30, vehicle.ReflectBar);
            SetSqlBoolean(31, vehicle.HighSideStopLamps);
            SetSqlBoolean(32, vehicle.DangerousMark);
            SetSqlBoolean(33, vehicle.BackProtection);
            SetSqlBoolean(34, vehicle.ThreePointBelt);
            SetSqlBoolean(35, vehicle.RolloverProtect);
            SetSqlBoolean(36, vehicle.ABS);
            SetSqlInt32(37, vehicle.AirbagAmount);
            SetSqlBoolean(38, vehicle.CarriageScope);
            SetSqlString(39, vehicle.CarType);
            SetSqlString(40, vehicle.TrailerNo);
            SetSqlDouble(41, vehicle.TrailerLoadWeight);
            SetSqlString(42, vehicle.TrailerSize);
            SetSqlDouble(43, vehicle.TrailerTotalWeight);
            SetSqlDouble(44, vehicle.TrailerEntireWeight);
            SetSqlString(45, vehicle.TrailerTypeNo);
            SetSqlDateTime(46, vehicle.TrailerBoardlotDate ?? SqlTypes.SqlDateTime.Null);
            SetSqlString(47, vehicle.TrailerVin);
            SetSqlDateTime(48, vehicle.TrailerNextYearCheckDate ?? SqlTypes.SqlDateTime.Null);
            SetSqlDateTime(49, vehicle.CreateTime ?? SqlTypes.SqlDateTime.Null);
            SetSqlDateTime(50, vehicle.UpdateTime ?? SqlTypes.SqlDateTime.Null);
            SetSqlString(51, vehicle.CreateUser);
            SetSqlString(52, vehicle.UpdateUser);
            SetSqlString(53, vehicle.Str1);
            SetSqlString(54, vehicle.Str2);
            SetSqlString(55, vehicle.Str3);
            SetSqlString(56, vehicle.Str4);
            SetSqlString(57, vehicle.Str5);
            SetSqlString(58, vehicle.Str6);
            SetSqlString(59, vehicle.Str7);
            SetSqlString(60, vehicle.Str8);
            SetSqlString(61, vehicle.Str9);
            SetSqlString(62, vehicle.Str10);
            SetSqlString(63, vehicle.Str11);
            SetSqlString(64, vehicle.Str12);
            SetSqlString(65, vehicle.Str13);
            SetSqlString(66, vehicle.Str14);
            SetSqlString(67, vehicle.Str15);
            SetSqlString(68, vehicle.Str16);
            SetSqlString(69, vehicle.Str17);
            SetSqlString(70, vehicle.Str18);
            SetSqlString(71, vehicle.Str19);
            SetSqlString(72, vehicle.Str20);
            SetSqlDateTime(73, vehicle.Datetime1 ?? SqlTypes.SqlDateTime.Null);
            SetSqlDateTime(74, vehicle.Datetime2 ?? SqlTypes.SqlDateTime.Null);
            SetSqlDateTime(75, vehicle.Datetime3 ?? SqlTypes.SqlDateTime.Null);
            SetSqlDateTime(76, vehicle.Datetime4 ?? SqlTypes.SqlDateTime.Null);
            SetSqlDateTime(77, vehicle.Datetime5 ?? SqlTypes.SqlDateTime.Null);
            SetSqlBoolean(78, vehicle.Bit1);
            SetSqlBoolean(79, vehicle.Bit2);
            SetSqlBoolean(80, vehicle.Bit3);
            SetSqlString(81, vehicle.CarBodyPhoto);
            SetSqlString(82, vehicle.CarFrontPhoto);
            SetSqlString(83, vehicle.CarBackPhoto);
            SetSqlString(84, vehicle.CarFloorPhoto);
            
        }

        

        private static readonly SqlMetaData[] s_metadata =
        {
            new SqlMetaData("ID", SqlDbType.BigInt),
            new SqlMetaData("CarNo", SqlDbType.NVarChar, 50),
            new SqlMetaData("RunNo", SqlDbType.NVarChar, 50),
            new SqlMetaData("CarTypeNo", SqlDbType.NVarChar, 50),
            new SqlMetaData("CarVin", SqlDbType.NVarChar, 50),
            new SqlMetaData("SecurityContactNum", SqlDbType.NVarChar, 50),
            new SqlMetaData("LogisticCompany", SqlDbType.NVarChar, 50),
            new SqlMetaData("DrivedJourney", SqlDbType.Float),
            new SqlMetaData("Qualify", SqlDbType.NVarChar, 50),
            new SqlMetaData("BoardlotDate", SqlDbType.Date),
            new SqlMetaData("CarAge", SqlDbType.Int),
            new SqlMetaData("CarNumType", SqlDbType.NVarChar, 50),
            new SqlMetaData("FuelType", SqlDbType.NVarChar, 50),
            new SqlMetaData("CarBodyColor", SqlDbType.NVarChar, 50),
            new SqlMetaData("Manufacturer", SqlDbType.NVarChar, 50),
            new SqlMetaData("NextYearCheckDate", SqlDbType.Date),
            new SqlMetaData("Velocity_transducers", SqlDbType.NVarChar, 50),
            new SqlMetaData("StartServiceDate", SqlDbType.Date),
            new SqlMetaData("InsuranceEndDate", SqlDbType.Date),
            new SqlMetaData("EntireCarWeight", SqlDbType.Float),
            new SqlMetaData("MainRoute", SqlDbType.NVarChar, 50),
            new SqlMetaData("LoadWeight", SqlDbType.Float),
            new SqlMetaData("LoadPerson", SqlDbType.Int),
            new SqlMetaData("Size", SqlDbType.NVarChar, 50),
            new SqlMetaData("TotalWeight", SqlDbType.Float),
            new SqlMetaData("TractionWeight", SqlDbType.Float),
            new SqlMetaData("SafetyBeltAmount", SqlDbType.Int),
            new SqlMetaData("BackUpBuzze", SqlDbType.Bit),
            new SqlMetaData("TheTankerOilSpillProtectionDevice", SqlDbType.Bit),
            new SqlMetaData("OilSpillPreventiontools", SqlDbType.Bit),
            new SqlMetaData("ReflectBar", SqlDbType.Bit),
            new SqlMetaData("HighSideStopLamps", SqlDbType.Bit),
            new SqlMetaData("DangerousMark", SqlDbType.Bit),
            new SqlMetaData("BackProtection", SqlDbType.Bit),
            new SqlMetaData("ThreePointBelt", SqlDbType.Bit),
            new SqlMetaData("RolloverProtect", SqlDbType.Bit),
            new SqlMetaData("ABS", SqlDbType.Bit),
            new SqlMetaData("AirbagAmount", SqlDbType.Int),
            new SqlMetaData("CarriageScope", SqlDbType.Bit),
            new SqlMetaData("CarType", SqlDbType.NVarChar, 50),
            new SqlMetaData("TrailerNo", SqlDbType.NVarChar, 50),
            new SqlMetaData("TrailerLoadWeight", SqlDbType.Float),
            new SqlMetaData("TrailerSize", SqlDbType.NVarChar, 50),
            new SqlMetaData("TrailerTotalWeight", SqlDbType.Float),
            new SqlMetaData("TrailerEntireWeight", SqlDbType.Float),
            new SqlMetaData("TrailerTypeNo", SqlDbType.NVarChar, 50),
            new SqlMetaData("TrailerBoardlotDate", SqlDbType.Date),
            new SqlMetaData("TrailerVin", SqlDbType.NVarChar, 50),
            new SqlMetaData("TrailerNextYearCheckDate", SqlDbType.Date),
            new SqlMetaData("CreateTime", SqlDbType.DateTime),
            new SqlMetaData("UpdateTime", SqlDbType.DateTime),
            new SqlMetaData("CreateUser", SqlDbType.NVarChar, 50),
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
            new SqlMetaData("CarBodyPhoto", SqlDbType.NVarChar, 50),
            new SqlMetaData("CarFrontPhoto", SqlDbType.NVarChar, 50),
            new SqlMetaData("CarBackPhoto", SqlDbType.NVarChar, 50),
            new SqlMetaData("CarFloorPhoto", SqlDbType.NVarChar, 50),


        };
    }
}