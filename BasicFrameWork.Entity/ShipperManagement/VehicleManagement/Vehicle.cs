using BasicFramework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFramework.Entity.ShipperManagement.VehicleManagement
{
    public class Vehicle
    {
        [EntityPropertyExtension("ID", "ID")]
        public long ID { get; set; }

        [EntityPropertyExtension("CarNo", "CarNo")]
        public string CarNo { get; set; }

        [EntityPropertyExtension("ShipperName", "ShipperName")]
        public string ShipperName { get; set; }

        [EntityPropertyExtension("SID", "SID")]
        public string SID { get; set; }

        [EntityPropertyExtension("RunNo", "RunNo")]
        public string RunNo { get; set; }

        [EntityPropertyExtension("CarTypeNo", "CarTypeNo")]
        public string CarTypeNo { get; set; }

        [EntityPropertyExtension("CarVin", "CarVin")]
        public string CarVin { get; set; }

        [EntityPropertyExtension("SecurityContactNum", "SecurityContactNum")]
        public string SecurityContactNum { get; set; }

        [EntityPropertyExtension("LogisticCompany", "LogisticCompany")]
        public string LogisticCompany { get; set; }

        [EntityPropertyExtension("DrivedJourney", "DrivedJourney")]
        public float DrivedJourney { get; set; }

        [EntityPropertyExtension("Qualify", "Qualify")]
        public string Qualify { get; set; }

        [EntityPropertyExtension("BoardlotDate", "BoardlotDate")]
        public DateTime BoardlotDate { get; set; }

        [EntityPropertyExtension("CarAge", "CarAge")]
        public int CarAge { get; set; }

        [EntityPropertyExtension("CarNumType", "CarNumType")]
        public string CarNumType { get; set; }

        [EntityPropertyExtension("FuelType", "FuelType")]
        public string FuelType { get; set; }

        [EntityPropertyExtension("CarBodyColor", "CarBodyColor")]
        public string CarBodyColor { get; set; }

        [EntityPropertyExtension("Manufacturer", "Manufacturer")]
        public string Manufacturer { get; set; }

        [EntityPropertyExtension("NextYearCheckDate", "NextYearCheckDate")]
        public DateTime NextYearCheckDate { get; set; }

        [EntityPropertyExtension("Velocity_transducers", "Velocity_transducers")]
        public string Velocity_transducers { get; set; }

        [EntityPropertyExtension("StartServiceDate", "StartServiceDate")]
        public DateTime StartServiceDate { get; set; }

        [EntityPropertyExtension("InsuranceEndDate", "InsuranceEndDate")]
        public DateTime InsuranceEndDate { get; set; }

        [EntityPropertyExtension("EntireCarWeight", "EntireCarWeight")]
        public float EntireCarWeight { get; set; }

        [EntityPropertyExtension("MainRoute", "MainRoute")]
        public string MainRoute { get; set; }

        [EntityPropertyExtension("LoadWeight", "LoadWeight")]
        public float LoadWeight { get; set; }

        [EntityPropertyExtension("LoadPerson", "LoadPerson")]
        public int LoadPerson { get; set; }

        [EntityPropertyExtension("Size", "Size")]
        public string Size { get; set; }

        [EntityPropertyExtension("TotalWeight", "TotalWeight")]
        public float TotalWeight { get; set; }

        [EntityPropertyExtension("TractionWeight", "TractionWeight")]
        public float TractionWeight { get; set; }

        [EntityPropertyExtension("SafetyBeltAmount", "SafetyBeltAmount")]
        public int SafetyBeltAmount { get; set; }

        [EntityPropertyExtension("BackUpBuzze", "BackUpBuzze")]
        public bool BackUpBuzze { get; set; }

        [EntityPropertyExtension("TheTankerOilSpillProtectionDevice", "TheTankerOilSpillProtectionDevice")]
        public bool TheTankerOilSpillProtectionDevice { get; set; }

        [EntityPropertyExtension("OilSpillPreventiontools", "OilSpillPreventiontools")]
        public bool OilSpillPreventiontools { get; set; }

        [EntityPropertyExtension("ReflectBar", "ReflectBar")]
        public bool ReflectBar { get; set; }

        [EntityPropertyExtension("HighSideStopLamps", "HighSideStopLamps")]
        public bool HighSideStopLamps { get; set; }

        [EntityPropertyExtension("DangerousMark", "DangerousMark")]
        public bool DangerousMark { get; set; }

        [EntityPropertyExtension("BackProtection", "BackProtection")]
        public bool BackProtection { get; set; }

        [EntityPropertyExtension("ThreePointBelt", "ThreePointBelt")]
        public bool ThreePointBelt { get; set; }

        [EntityPropertyExtension("RolloverProtect", "RolloverProtect")]
        public bool RolloverProtect { get; set; }

        [EntityPropertyExtension("ABS", "ABS")]
        public bool ABS { get; set; }

        [EntityPropertyExtension("AirbagAmount", "AirbagAmount")]
        public int AirbagAmount { get; set; }

        [EntityPropertyExtension("CarriageScope", "CarriageScope")]
        public bool CarriageScope { get; set; }

        [EntityPropertyExtension("CarType", "CarType")]
        public string CarType { get; set; }

        [EntityPropertyExtension("TrailerNo", "TrailerNo")]
        public string TrailerNo { get; set; }

        [EntityPropertyExtension("TrailerLoadWeight", "TrailerLoadWeight")]
        public float TrailerLoadWeight { get; set; }

        [EntityPropertyExtension("TrailerSize", "TrailerSize")]
        public string TrailerSize { get; set; }

        [EntityPropertyExtension("TrailerTotalWeight", "TrailerTotalWeight")]
        public float TrailerTotalWeight { get; set; }

        [EntityPropertyExtension("TrailerEntireWeight", "TrailerEntireWeight")]
        public float TrailerEntireWeight { get; set; }

        [EntityPropertyExtension("TrailerTypeNo", "TrailerTypeNo")]
        public string TrailerTypeNo { get; set; }

        [EntityPropertyExtension("TrailerBoardlotDate", "TrailerBoardlotDate")]
        public DateTime? TrailerBoardlotDate { get; set; }

        [EntityPropertyExtension("TrailerVin", "TrailerVin")]
        public string TrailerVin { get; set; }

        [EntityPropertyExtension("TrailerNextYearCheckDate", "TrailerNextYearCheckDate")]
        public DateTime? TrailerNextYearCheckDate { get; set; }

        [EntityPropertyExtension("CreateTime", "CreateTime")]
        public DateTime? CreateTime { get; set; }

        [EntityPropertyExtension("UpdateTime", "UpdateTime")]
        public DateTime? UpdateTime { get; set; }

        [EntityPropertyExtension("CreateUser", "CreateUser")]
        public string CreateUser { get; set; }

        [EntityPropertyExtension("UpdateUser", "UpdateUser")]
        public string UpdateUser { get; set; }

        [EntityPropertyExtension("Str1", "Str1")]
        public string Str1 { get; set; }

        [EntityPropertyExtension("Str2", "Str2")]
        public string Str2 { get; set; }

        [EntityPropertyExtension("Str3", "Str3")]
        public string Str3 { get; set; }

        [EntityPropertyExtension("Str4", "Str4")]
        public string Str4 { get; set; }

        [EntityPropertyExtension("Str5", "Str5")]
        public string Str5 { get; set; }

        [EntityPropertyExtension("Str6", "Str6")]
        public string Str6 { get; set; }

        [EntityPropertyExtension("Str7", "Str7")]
        public string Str7 { get; set; }

        [EntityPropertyExtension("Str8", "Str8")]
        public string Str8 { get; set; }

        [EntityPropertyExtension("Str9", "Str9")]
        public string Str9 { get; set; }

        [EntityPropertyExtension("Str10", "Str10")]
        public string Str10 { get; set; }

        [EntityPropertyExtension("Str11", "Str11")]
        public string Str11 { get; set; }

        [EntityPropertyExtension("Str12", "Str12")]
        public string Str12 { get; set; }

        [EntityPropertyExtension("Str13", "Str13")]
        public string Str13 { get; set; }

        [EntityPropertyExtension("Str14", "Str14")]
        public string Str14 { get; set; }

        [EntityPropertyExtension("Str15", "Str15")]
        public string Str15 { get; set; }

        [EntityPropertyExtension("Str16", "Str16")]
        public string Str16 { get; set; }

        [EntityPropertyExtension("Str17", "Str17")]
        public string Str17 { get; set; }

        [EntityPropertyExtension("Str18", "Str18")]
        public string Str18 { get; set; }

        [EntityPropertyExtension("Str19", "Str19")]
        public string Str19 { get; set; }

        [EntityPropertyExtension("Str20", "Str20")]
        public string Str20 { get; set; }

        [EntityPropertyExtension("Datetime1", "Datetime1")]
        public DateTime? Datetime1 { get; set; }

        [EntityPropertyExtension("Datetime2", "Datetime2")]
        public DateTime? Datetime2 { get; set; }

        [EntityPropertyExtension("Datetime3", "Datetime3")]
        public DateTime? Datetime3 { get; set; }

        [EntityPropertyExtension("Datetime4", "Datetime4")]
        public DateTime? Datetime4 { get; set; }

        [EntityPropertyExtension("Datetime5", "Datetime5")]
        public DateTime? Datetime5 { get; set; }

        [EntityPropertyExtension("Bit1", "Bit1")]
        public bool Bit1 { get; set; }

        [EntityPropertyExtension("Bit2", "Bit2")]
        public bool Bit2 { get; set; }

        [EntityPropertyExtension("Bit3", "Bit3")]
        public bool Bit3 { get; set; }

        [EntityPropertyExtension("CarBodyPhoto", "CarBodyPhoto")]
        public string CarBodyPhoto { get; set; }

        [EntityPropertyExtension("CarFrontPhoto", "CarFrontPhoto")]
        public string CarFrontPhoto { get; set; }

        [EntityPropertyExtension("CarBackPhoto", "CarBackPhoto")]
        public string CarBackPhoto { get; set; }

        [EntityPropertyExtension("CarFloorPhoto", "CarFloorPhoto")]
        public string CarFloorPhoto { get; set; }

        [EntityPropertyExtension("url", "url")]
        public string url { get; set; }

        [EntityPropertyExtension("urls", "urls")]
        public List<string> urls { get; set; }
    }
}
