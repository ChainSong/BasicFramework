using BasicFramework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFramework.Entity.ShipperManagement.DriverManagement
{
    public class Driver
    {
        [EntityPropertyExtension("ID", "ID")]
        public long ID { get; set; }

        [EntityPropertyExtension("VID", "VID")]
        public string VID { get; set; }

        [EntityPropertyExtension("VehicleNo", "VehicleNo")]
        public string VehicleNo { get; set; }

        [EntityPropertyExtension("DriverName", "DriverName")]
        public string DriverName { get; set; }

        [EntityPropertyExtension("DriverBirthday", "DriverBirthday")]
        public DateTime DriverBirthday { get; set; }

        [EntityPropertyExtension("DriverPhone", "DriverPhone")]
        public string DriverPhone { get; set; }

        [EntityPropertyExtension("DriverLogisticsCompany", "DriverLogisticsCompany")]
        public string DriverLogisticsCompany { get; set; }

        [EntityPropertyExtension("DriverStartServeForRunbowDate", "DriverStartServeForRunbowDate")]
        public DateTime DriverStartServeForRunbowDate { get; set; }

        [EntityPropertyExtension("DriverIDCard", "DriverIDCard")]
        public string DriverIDCard { get; set; }

        [EntityPropertyExtension("DriverLogisticsContactPerson", "DriverLogisticsContactPerson")]
        public string DriverLogisticsContactPerson { get; set; }

        [EntityPropertyExtension("DriverCardNo", "DriverCardNo")]
        public string DriverCardNo { get; set; }

        [EntityPropertyExtension("DriverLogisticsCompanyContactPhone", "DriverLogisticsCompanyContactPhone")]
        public string DriverLogisticsCompanyContactPhone { get; set; }

        [EntityPropertyExtension("DriverCardType", "DriverCardType")]
        public string DriverCardType { get; set; }

        [EntityPropertyExtension("DriverIsServing", "DriverIsServing")]
        public bool DriverIsServing { get; set; }

        [EntityPropertyExtension("DriverRegistrationNo", "DriverRegistrationNo")]
        public string DriverRegistrationNo { get; set; }

        [EntityPropertyExtension("DriverRegistrationCardSignedAddress", "DriverRegistrationCardSignedAddress")]
        public string DriverRegistrationCardSignedAddress { get; set; }

        [EntityPropertyExtension("DriverNextYearCheckDate", "DriverNextYearCheckDate")]
        public DateTime DriverNextYearCheckDate { get; set; }

        [EntityPropertyExtension("DriverFirstTimeGetCardDate", "DriverFirstTimeGetCardDate")]
        public DateTime DriverFirstTimeGetCardDate { get; set; }

        [EntityPropertyExtension("DriverNextYearCheckBodyDate", "DriverNextYearCheckBodyDate")]
        public DateTime DriverNextYearCheckBodyDate { get; set; }

        [EntityPropertyExtension("DriverServiceArea", "DriverServiceArea")]
        public string DriverServiceArea { get; set; }

        [EntityPropertyExtension("DriverCarNo", "DriverCarNo")]
        public string DriverCarNo { get; set; }

        [EntityPropertyExtension("DriverMainRoute", "DriverMainRoute")]
        public string DriverMainRoute { get; set; }

        [EntityPropertyExtension("CreateTime", "CreateTime")]
        public DateTime? CreateTime { get; set; }

        [EntityPropertyExtension("CreateUser", "CreateUser")]
        public string CreateUser { get; set; }

        [EntityPropertyExtension("UpdateTime", "UpdateTime")]
        public DateTime? UpdateTime { get; set; }

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



      //    //[ID]
      //,[DriverName]
      //,[DriverBirthday]
      //,[DriverPhone]
      //,[DriverLogisticsCompany]
      //,[DriverStartServeForRunbowDate]
      //,[DriverIDCard]
      //,[DriverLogisticsContactPerson]
      //,[DriverCardNo]
      //,[DriverLogisticsCompanyContactPhone]
      //,[DriverCardType]
      //,[DriverIsServing]
      //,[DriverRegistrationNo]
      //,[DriverRegistrationCardSignedAddress]
      //,[DriverNextYearCheckDate]
      //,[DriverFirstTimeGetCardDate]
      //,[DriverNextYearCheckBodyDate]
      //,[DriverServiceArea]
      //,[DriverCarNo]
      //,[DriverMainRoute]
      //,[CreateTime]
      //,[CreateUser]
      //,[UpdateTime]
      //,[UpdateUser]
      //,[Str1]
      //,[Str2]
      //,[Str3]
      //,[Str4]
      //,[Str5]
      //,[Str6]
      //,[Str7]
      //,[Str8]
      //,[Str9]
      //,[Str10]
      //,[Str11]
      //,[Str12]
      //,[Str13]
      //,[Str14]
      //,[Str15]
      //,[Str16]
      //,[Str17]
      //,[Str18]
      //,[Str19]
      //,[Str20]
      //,[Datetime1]
      //,[Datetime2]
      //,[Datetime3]
      //,[Datetime4]
      //,[Datetime5]
      //,[Bit1]
      //,[Bit2]
      //,[Bit3]
    }
}
