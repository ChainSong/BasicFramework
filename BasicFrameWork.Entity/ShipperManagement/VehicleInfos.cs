using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicFramework.Common;

namespace BasicFramework.Entity.ShipperManagement
{
    public class VehicleInfos
    {
        [EntityPropertyExtension("ID", "ID")]
        public long ID { get; set; }

        [EntityPropertyExtension("CarNo", "CarNo")]
        public string CarNo { get; set; }

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
        public string DrivedJourney { get; set; }

        [EntityPropertyExtension("Qualify", "Qualify")]
        public string Qualify { get; set; }

        [EntityPropertyExtension("BoardlotDate", "BoardlotDate")]
        public DateTime? BoardlotDate { get; set; }

        [EntityPropertyExtension("CarAge", "CarAge")]
        public int? CarAge { get; set; }

        [EntityPropertyExtension("CarNumType", "CarNumType")]
        public string CarNumType { get; set; }

        [EntityPropertyExtension("FuelType", "FuelType")]
        public string FuelType { get; set; }

        [EntityPropertyExtension("CarBodyColor", "CarBodyColor")]
        public string CarBodyColor { get; set; }

        [EntityPropertyExtension("Manufacturer", "Manufacturer")]
        public string Manufacturer { get; set; }

        [EntityPropertyExtension("NextYearCheckDate", "NextYearCheckDate")]
        public DateTime? NextYearCheckDate { get; set; }

        [EntityPropertyExtension("Velocity_transducers", "Velocity_transducers")]
        public string Velocity_transducers { get; set; }

        [EntityPropertyExtension("StartServiceDate", "StartServiceDate")]
        public DateTime? StartServiceDate { get; set; }

        [EntityPropertyExtension("InsuranceEndDate", "InsuranceEndDate")]
        public DateTime? InsuranceEndDate { get; set; }

        [EntityPropertyExtension("EntireCarWeight", "EntireCarWeight")]
        public float? EntireCarWeight { get; set; }

        [EntityPropertyExtension("MainRoute", "MainRoute")]
        public string MainRoute { get; set; }

        [EntityPropertyExtension("LoadWeight", "LoadWeight")]
        public float? LoadWeight { get; set; }

        [EntityPropertyExtension("LoadPerson", "LoadPerson")]
        public int? LoadPerson { get; set; }

        [EntityPropertyExtension("Size", "Size")]
        public string Size { get; set; }

        [EntityPropertyExtension("TotalWeight", "TotalWeight")]
        public float? TotalWeight { get; set; }

        [EntityPropertyExtension("TractionWeight", "TractionWeight")]
        public float? TractionWeight { get; set; }

        [EntityPropertyExtension("SafetyBeltAmount", "SafetyBeltAmount")]
        public int? SafetyBeltAmount { get; set; }

        [EntityPropertyExtension("BackUpBuzze", "BackUpBuzze")]
        public bool? BackUpBuzze { get; set; }

        [EntityPropertyExtension("TheTankerOilSpillProtectionDevice", "TheTankerOilSpillProtectionDevice")]
        public bool? TheTankerOilSpillProtectionDevice { get; set; }

        [EntityPropertyExtension("OilSpillPreventiontools", "OilSpillPreventiontools")]
        public bool? OilSpillPreventiontools { get; set; }

        [EntityPropertyExtension("ReflectBar", "ReflectBar")]
        public bool? ReflectBar { get; set; }

        [EntityPropertyExtension("HighSideStopLamps", "HighSideStopLamps")]
        public bool? HighSideStopLamps { get; set; }

        [EntityPropertyExtension("DangerousMark", "DangerousMark")]
        public bool? DangerousMark { get; set; }

        [EntityPropertyExtension("BackProtection", "BackProtection")]
        public bool? BackProtection { get; set; }

        [EntityPropertyExtension("ThreePointBelt", "ThreePointBelt")]
        public bool? ThreePointBelt { get; set; }

        [EntityPropertyExtension("RolloverProtect", "RolloverProtect")]
        public bool? RolloverProtect { get; set; }

        [EntityPropertyExtension("ABS", "ABS")]
        public bool? ABS { get; set; }

        [EntityPropertyExtension("AirbagAmount", "AirbagAmount")]
        public bool? AirbagAmount { get; set; }

        [EntityPropertyExtension("CarriageScope", "CarriageScope")]
        public bool? CarriageScope { get; set; }

        [EntityPropertyExtension("CarType", "CarType")]
        public string CarType { get; set; }

        [EntityPropertyExtension("TrailerNo", "TrailerNo")]
        public string TrailerNo { get; set; }

        [EntityPropertyExtension("TrailerLoadWeight", "TrailerLoadWeight")]
        public float? TrailerLoadWeight { get; set; }

        [EntityPropertyExtension("TrailerSize", "TrailerSize")]
        public string TrailerSize { get; set; }

        [EntityPropertyExtension("TrailerTotalWeight", "TrailerTotalWeight")]
        public float? TrailerTotalWeight { get; set; }

        [EntityPropertyExtension("TrailerEntireWeight", "TrailerEntireWeight")]
        public float? TrailerEntireWeight { get; set; }

        [EntityPropertyExtension("TrailerTypeNo", "TrailerTypeNo")]
        public string TrailerTypeNo { get; set; }

        [EntityPropertyExtension("TrailerBoardlotDate", "TrailerBoardlotDate")]
        public DateTime? TrailerBoardlotDate { get; set; }

        [EntityPropertyExtension("TrailerVin", "TrailerVin")]
        public string TrailerVin { get; set; }

        [EntityPropertyExtension("TrailerNextYearCheckDate", "TrailerNextYearCheckDate")]
        public DateTime? TrailerNextYearCheckDate { get; set; }

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

        [EntityPropertyExtension("DateTime1", "DateTime1")]
        public DateTime? DateTime1 { get; set; }

        [EntityPropertyExtension("DateTime2", "DateTime2")]
        public DateTime? DateTime2 { get; set; }

        [EntityPropertyExtension("DateTime3", "DateTime3")]
        public DateTime? DateTime3 { get; set; }

        [EntityPropertyExtension("int1", "int1")]
        public int? int1 { get; set; }

        [EntityPropertyExtension("int2", "int2")]
        public int? int2 { get; set; }

        [EntityPropertyExtension("int3", "int3")]
        public int? int3 { get; set; }

        [EntityPropertyExtension("float1", "float1")]
        public float? float1 { get; set; }

        [EntityPropertyExtension("float2", "float2")]
        public float? float2 { get; set; }

        [EntityPropertyExtension("float3", "float3")]
        public float? float3 { get; set; }

        [EntityPropertyExtension("CreateTime", "CreateTime")]
        public DateTime? CreateTime { get; set; }

        [EntityPropertyExtension("UpdateTime", "UpdateTime")]
        public DateTime? UpdateTime { get; set; }

        [EntityPropertyExtension("CreateUser", "CreateUser")]
        public string CreateUser { get; set; }

        [EntityPropertyExtension("UpdateUser", "UpdateUser")]
        public string UpdateUser { get; set; }

        [EntityPropertyExtension("InputFileFront", "InputFileFront")]
        public string InputFileFront { get; set; }

        [EntityPropertyExtension("InputFileBack", "InputFileBack")]
        public string InputFileBack { get; set; }

        [EntityPropertyExtension("InputFileFloor", "InputFileFloor")]
        public string InputFileFloor { get; set; }
    }
}
