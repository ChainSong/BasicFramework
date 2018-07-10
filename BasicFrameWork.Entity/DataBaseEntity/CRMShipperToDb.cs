using System;
using System.Data;
using Microsoft.SqlServer.Server;
using SqlTypes = global::System.Data.SqlTypes;

namespace BasicFramework.Entity
{
    public class ShipperToDb : SqlDataRecord
    {
        public ShipperToDb(Shipper shipper)
            : base(s_metadata)
        {
            SetSqlInt64(0, shipper.ID);
            SetSqlString(1, shipper.Name);
            SetSqlString(2, shipper.LegalRepresentative);
            SetSqlString(3, shipper.LegalRepresentativeConta);
            SetSqlString(4, shipper.PersonInCharge);
            SetSqlString(5, shipper.PersonInChargeContact);
            SetSqlString(6, shipper.Attribution);
            SetSqlString(7, shipper.TransportMode);
            SetSqlString(8, shipper.RegisteredCapital);
            SetSqlString(9, shipper.RegisteredCapitalRange);
            SetSqlString(10, shipper.AnnualTurnover);
            SetSqlString(11, shipper.AnnualTurnoverRange);
            SetSqlString(12, shipper.SixCard);
            SetSqlString(13, shipper.FrontEndAddress);
            SetSqlString(14, shipper.OfficeArea);
            SetSqlString(15, shipper.WarehouseArea);
            SetSqlString(16, shipper.WarehouseAreaRange);
            SetSqlString(17, shipper.NumberOfEmployees);
            SetSqlString(18, shipper.NumberOfCustomerService);
            SetSqlString(19, shipper.NumberOfStevedores);
            SetSqlString(20, shipper.ForkliftsUsage);
            SetSqlString(21, shipper.LoadingPlatform);
            SetSqlString(22, shipper.TrunkOfVehicle);
            SetSqlString(23, shipper.TrunkOfVehicleRange);
            SetSqlString(24, shipper.TrunkOfVehicleType);
            SetSqlString(25, shipper.DeliveryOfVehicle);
            SetSqlString(26, shipper.DeliveryOfVehicleRange);
            SetSqlString(27, shipper.DeliveryOfVehicleType);
            SetSqlString(28, shipper.TermialOfVehicle);
            SetSqlString(29, shipper.TermialOfVehicleType);
            SetSqlString(30, shipper.FrequencyOfDeparture);
            SetSqlString(31, shipper.GoodsStructure);
            SetSqlString(32, shipper.InsuranceCompanies);
            SetSqlString(33, shipper.InsuranceType);
            SetSqlString(34, shipper.SumInsured);
            SetSqlString(35, shipper.ValidityPeriod);
            SetSqlString(36, shipper.CargoDamageControl);
            SetSqlString(37, shipper.CargoDamageHanding);
            SetSqlString(38, shipper.PartnershipTypes);
            SetSqlString(39, shipper.BlackListReason);
            SetSqlString(40, shipper.CompanyImage);
            SetSqlString(41, shipper.StaffQuality);
            SetSqlString(42, shipper.OnsiteCustomerService);
            SetSqlString(43, shipper.Rating);
            SetSqlString(44, shipper.Recommended);
            SetSqlString(45, shipper.Remark);
            SetSqlString(46, shipper.AttachmentGroupID);
            SetSqlString(47, shipper.Creator);
            SetSqlDateTime(48, shipper.CreateTime ?? SqlTypes.SqlDateTime.Null);
            SetSqlString(49, shipper.Updator);
            SetSqlDateTime(50, shipper.UpdateTime ?? SqlTypes.SqlDateTime.Null);
            SetSqlBoolean(51, shipper.Status ?? SqlTypes.SqlBoolean.Null);    
            SetSqlString(52, shipper.Str1);
            SetSqlString(53, shipper.Str2);
            SetSqlString(54, shipper.Str3);
            SetSqlString(55, shipper.Str4);
            SetSqlString(56, shipper.Str5);
            SetSqlString(57, shipper.Str6);
            SetSqlString(58, shipper.Str7);
            SetSqlString(59, shipper.Str8);
            SetSqlString(60, shipper.Str9);
            SetSqlString(61, shipper.Str10);
            SetSqlDateTime(62, shipper.DateTime1 ?? SqlTypes.SqlDateTime.Null);
            SetSqlDateTime(63, shipper.DateTime2 ?? SqlTypes.SqlDateTime.Null);
            SetSqlDateTime(64, shipper.DateTime3 ?? SqlTypes.SqlDateTime.Null);
            SetSqlDateTime(65, shipper.DateTime4 ?? SqlTypes.SqlDateTime.Null);
            SetSqlDateTime(66, shipper.DateTime5 ?? SqlTypes.SqlDateTime.Null);
            SetSqlInt64(67, shipper.Bigint1 ?? SqlTypes.SqlInt64.Null);
            SetSqlInt32(68, shipper.Int1 ?? SqlTypes.SqlInt32.Null);
            SetSqlBoolean(69, shipper.Bit1 ?? SqlTypes.SqlBoolean.Null);
        }

        private static readonly SqlMetaData[] s_metadata =
        {
            new SqlMetaData("ID", SqlDbType.BigInt),
            new SqlMetaData("Name", SqlDbType.NVarChar,100),
            new SqlMetaData("LegalRepresentative", SqlDbType.NVarChar,100),
            new SqlMetaData("LegalRepresentativeConta", SqlDbType.NVarChar,100),
            new SqlMetaData("PersonInCharge", SqlDbType.NVarChar,100),
            new SqlMetaData("PersonInChargeContact", SqlDbType.NVarChar,100),
            new SqlMetaData("Attribution", SqlDbType.NVarChar,100),
            new SqlMetaData("TransportMode", SqlDbType.NVarChar,100),
            new SqlMetaData("RegisteredCapital", SqlDbType.NVarChar,100),
            new SqlMetaData("RegisteredCapitalRange", SqlDbType.NVarChar,100),
            new SqlMetaData("AnnualTurnover", SqlDbType.NVarChar,100),
            new SqlMetaData("AnnualTurnoverRange", SqlDbType.NVarChar,100),
            new SqlMetaData("SixCard", SqlDbType.NVarChar,100),
            new SqlMetaData("FrontEndAddress", SqlDbType.NVarChar,100),
            new SqlMetaData("OfficeArea", SqlDbType.NVarChar,100),
            new SqlMetaData("WarehouseArea", SqlDbType.NVarChar,100),
            new SqlMetaData("WarehouseAreaRange", SqlDbType.NVarChar,100),
            new SqlMetaData("NumberOfEmployees", SqlDbType.NVarChar,100),
            new SqlMetaData("NumberOfCustomerService", SqlDbType.NVarChar,100),
            new SqlMetaData("NumberOfStevedores", SqlDbType.NVarChar,100),
            new SqlMetaData("ForkliftsUsage", SqlDbType.NVarChar,100),
            new SqlMetaData("LoadingPlatform", SqlDbType.NVarChar,100),
            new SqlMetaData("TrunkOfVehicle", SqlDbType.NVarChar,100),
            new SqlMetaData("TrunkOfVehicleRange", SqlDbType.NVarChar,100),
            new SqlMetaData("TrunkOfVehicleType", SqlDbType.NVarChar,200),
            new SqlMetaData("DeliveryOfVehicle", SqlDbType.NVarChar,100),
            new SqlMetaData("DeliveryOfVehicleRange", SqlDbType.NVarChar,100),
            new SqlMetaData("DeliveryOfVehicleType", SqlDbType.NVarChar,200),
            new SqlMetaData("TermialOfVehicle", SqlDbType.NVarChar,100),
            new SqlMetaData("TermialOfVehicleType", SqlDbType.NVarChar,100),
            new SqlMetaData("FrequencyOfDeparture", SqlDbType.NVarChar,100),
            new SqlMetaData("GoodsStructure", SqlDbType.NVarChar,100),
            new SqlMetaData("InsuranceCompanies", SqlDbType.NVarChar,100),
            new SqlMetaData("InsuranceType", SqlDbType.NVarChar,100),
            new SqlMetaData("SumInsured", SqlDbType.NVarChar,100),
            new SqlMetaData("ValidityPeriod", SqlDbType.NVarChar,100),
            new SqlMetaData("CargoDamageControl", SqlDbType.NVarChar,100),
            new SqlMetaData("CargoDamageHanding", SqlDbType.NVarChar,100),
            new SqlMetaData("PartnershipTypes", SqlDbType.NVarChar,200),
            new SqlMetaData("BlackListReason", SqlDbType.NVarChar,200),
            new SqlMetaData("CompanyImage", SqlDbType.NVarChar,100),
            new SqlMetaData("StaffQuality", SqlDbType.NVarChar,100),
            new SqlMetaData("OnsiteCustomerService", SqlDbType.NVarChar,100),
            new SqlMetaData("Rating", SqlDbType.NVarChar,100),
            new SqlMetaData("Recommended", SqlDbType.NVarChar,100),
            new SqlMetaData("Remark", SqlDbType.NVarChar,500),
            new SqlMetaData("AttachmentGroupID", SqlDbType.NVarChar,100),
            new SqlMetaData("Creator", SqlDbType.NVarChar,50),
            new SqlMetaData("CreateTime", SqlDbType.DateTime),
            new SqlMetaData("Updator", SqlDbType.NVarChar,50),
            new SqlMetaData("UpdateTime", SqlDbType.DateTime),
            new SqlMetaData("Status",SqlDbType.Bit),           
            new SqlMetaData("Str1", SqlDbType.NVarChar,100),
            new SqlMetaData("Str2", SqlDbType.NVarChar,100),
            new SqlMetaData("Str3", SqlDbType.NVarChar,100),
            new SqlMetaData("Str4", SqlDbType.NVarChar,100),
            new SqlMetaData("Str5", SqlDbType.NVarChar,100),
            new SqlMetaData("Str6", SqlDbType.NVarChar,500),
            new SqlMetaData("Str7", SqlDbType.NVarChar,500),
            new SqlMetaData("Str8", SqlDbType.NVarChar,500),
            new SqlMetaData("Str9",SqlDbType.NVarChar,500),
            new SqlMetaData("Str10",SqlDbType.NVarChar,500),
            new SqlMetaData("DateTime1", SqlDbType.DateTime),
            new SqlMetaData("DateTime2", SqlDbType.DateTime),
            new SqlMetaData("DateTime3", SqlDbType.DateTime),
            new SqlMetaData("DateTime4", SqlDbType.DateTime),
            new SqlMetaData("DateTime5", SqlDbType.DateTime),
            new SqlMetaData("Bigint1",SqlDbType.BigInt),
            new SqlMetaData("Int1",SqlDbType.Int),
            new SqlMetaData("Bit1",SqlDbType.Bit)
        };
    }
}