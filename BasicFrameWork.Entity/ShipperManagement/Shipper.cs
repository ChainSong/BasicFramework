using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicFramework.Common;

namespace BasicFramework.Entity
{
    public class Shipper
    {
        [EntityPropertyExtension("ID", "ID")]
        public long ID { get; set; }

        [EntityPropertyExtension("Name", "Name")]
        public string Name { get; set; }

        [EntityPropertyExtension("LegalRepresentative", "LegalRepresentative")]
        public string LegalRepresentative { get; set; }

        [EntityPropertyExtension("LegalRepresentativeConta", "LegalRepresentativeConta")]
        public string LegalRepresentativeConta { get; set; }

        [EntityPropertyExtension("PersonInCharge", "PersonInCharge")]
        public string PersonInCharge { get; set; }

        [EntityPropertyExtension("PersonInChargeContact", "PersonInChargeContact")]
        public string PersonInChargeContact { get; set; }

        [EntityPropertyExtension("Attribution", "Attribution")]
        public string Attribution { get; set; }

        [EntityPropertyExtension("TransportMode", "TransportMode")]
        public string TransportMode { get; set; }

        [EntityPropertyExtension("RegisteredCapital", "RegisteredCapital")]
        public string RegisteredCapital { get; set; }

        [EntityPropertyExtension("RegisteredCapitalRange", "RegisteredCapitalRange")]
        public string RegisteredCapitalRange { get; set; }

        [EntityPropertyExtension("AnnualTurnover", "AnnualTurnover")]
        public string AnnualTurnover { get; set; }

        [EntityPropertyExtension("AnnualTurnoverRange", "AnnualTurnoverRange")]
        public string AnnualTurnoverRange { get; set; }

        [EntityPropertyExtension("SixCard", "SixCard")]
        public string SixCard { get; set; }

        [EntityPropertyExtension("FrontEndAddress", "FrontEndAddress")]
        public string FrontEndAddress { get; set; }

        [EntityPropertyExtension("OfficeArea", "OfficeArea")]
        public string OfficeArea { get; set; }

        [EntityPropertyExtension("WarehouseArea", "WarehouseArea")]
        public string WarehouseArea { get; set; }

        [EntityPropertyExtension("WarehouseAreaRange", "WarehouseAreaRange")]
        public string WarehouseAreaRange { get; set; }

        [EntityPropertyExtension("NumberOfEmployees", "NumberOfEmployees")]
        public string NumberOfEmployees { get; set; }

        [EntityPropertyExtension("NumberOfCustomerService", "NumberOfCustomerService")]
        public string NumberOfCustomerService { get; set; }

        [EntityPropertyExtension("NumberOfStevedores", "NumberOfStevedores")]
        public string NumberOfStevedores { get; set; }

        [EntityPropertyExtension("ForkliftsUsage", "ForkliftsUsage")]
        public string ForkliftsUsage { get; set; }

        [EntityPropertyExtension("LoadingPlatform", "LoadingPlatform")]
        public string LoadingPlatform { get; set; }

        [EntityPropertyExtension("TrunkOfVehicle", "TrunkOfVehicle")]
        public string TrunkOfVehicle { get; set; }

        [EntityPropertyExtension("TrunkOfVehicleRange", "TrunkOfVehicleRange")]
        public string TrunkOfVehicleRange { get; set; }

        [EntityPropertyExtension("TrunkOfVehicleType", "TrunkOfVehicleType")]
        public string TrunkOfVehicleType { get; set; }

        [EntityPropertyExtension("DeliveryOfVehicle", "DeliveryOfVehicle")]
        public string DeliveryOfVehicle { get; set; }

        [EntityPropertyExtension("DeliveryOfVehicleRange", "DeliveryOfVehicleRange")]
        public string DeliveryOfVehicleRange { get; set; }

        [EntityPropertyExtension("DeliveryOfVehicleType", "DeliveryOfVehicleType")]
        public string DeliveryOfVehicleType { get; set; }

        [EntityPropertyExtension("TermialOfVehicle", "TermialOfVehicle")]
        public string TermialOfVehicle { get; set; }

        [EntityPropertyExtension("TermialOfVehicleType", "TermialOfVehicleType")]
        public string TermialOfVehicleType { get; set; }

        [EntityPropertyExtension("FrequencyOfDeparture", "FrequencyOfDeparture")]
        public string FrequencyOfDeparture { get; set; }

        [EntityPropertyExtension("GoodsStructure", "GoodsStructure")]
        public string GoodsStructure { get; set; }

        [EntityPropertyExtension("InsuranceCompanies", "InsuranceCompanies")]
        public string InsuranceCompanies { get; set; }

        [EntityPropertyExtension("InsuranceType", "InsuranceType")]
        public string InsuranceType { get; set; }

        [EntityPropertyExtension("SumInsured", "SumInsured")]
        public string SumInsured { get; set; }

        [EntityPropertyExtension("ValidityPeriod", "ValidityPeriod")]
        public string ValidityPeriod { get; set; }

        [EntityPropertyExtension("CargoDamageControl", "CargoDamageControl")]
        public string CargoDamageControl { get; set; }

        [EntityPropertyExtension("CargoDamageHanding", "CargoDamageHanding")]
        public string CargoDamageHanding { get; set; }

        [EntityPropertyExtension("PartnershipTypes", "PartnershipTypes")]
        public string PartnershipTypes { get; set; }

        [EntityPropertyExtension("BlackListReason", "BlackListReason")]
        public string BlackListReason { get; set; }

        [EntityPropertyExtension("CompanyImage", "CompanyImage")]
        public string CompanyImage { get; set; }

        [EntityPropertyExtension("StaffQuality", "StaffQuality")]
        public string StaffQuality { get; set; }

        [EntityPropertyExtension("OnsiteCustomerService", "OnsiteCustomerService")]
        public string OnsiteCustomerService { get; set; }

        [EntityPropertyExtension("Rating", "Rating")]
        public string Rating { get; set; }

        [EntityPropertyExtension("Recommended", "Recommended")]
        public string Recommended { get; set; }

        [EntityPropertyExtension("Remark", "Remark")]
        public string Remark { get; set; }

        [EntityPropertyExtension("AttachmentGroupID", "AttachmentGroupID")]
        public string AttachmentGroupID { get; set; }

        [EntityPropertyExtension("Creator", "Creator")]
        public string Creator { get; set; }

        [EntityPropertyExtension("CreateTime", "CreateTime")]
        public DateTime? CreateTime { get; set; }

        [EntityPropertyExtension("Updator", "Updator")]
        public string Updator { get; set; }

        [EntityPropertyExtension("UpdateTime", "UpdateTime")]
        public DateTime? UpdateTime { get; set; }

        [EntityPropertyExtension("Status", "Status")]
        public bool? Status { get; set; }

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

        [EntityPropertyExtension("DateTime1", "DateTime1")]
        public DateTime? DateTime1 { get; set; }

        [EntityPropertyExtension("DateTime2", "DateTime2")]
        public DateTime? DateTime2 { get; set; }

        [EntityPropertyExtension("DateTime3", "DateTime3")]
        public DateTime? DateTime3 { get; set; }

        [EntityPropertyExtension("DateTime4", "DateTime4")]
        public DateTime? DateTime4 { get; set; }

        [EntityPropertyExtension("DateTime5", "DateTime5")]
        public DateTime? DateTime5 { get; set; }

        [EntityPropertyExtension("Bigint1", "Bigint1")]
        public long? Bigint1 { get; set; }

        [EntityPropertyExtension("Int1", "Int1")]
        public int? Int1 { get; set; }

        [EntityPropertyExtension("Bit1", "Bit1")]
        public bool? Bit1 { get; set; }

        [EntityPropertyExtension("Url", "Url")]
        public string Url { get; set; }
    }
}
