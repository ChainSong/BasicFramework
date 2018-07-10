using BasicFramework.Common;

namespace BasicFramework.Entity
{
    public class Config
    {
        [EntityPropertyExtension("ID", "ID")]
        public long ID { get; set; }

        [EntityPropertyExtension("ProjectID", "ProjectID")]
        public long ProjectID { get; set; }

        [EntityPropertyExtension("Code", "Code")]
        public string Code { get; set; }

        [EntityPropertyExtension("Name", "Name")]
        public string Name { get; set; }

        [EntityPropertyExtension("IdentifyType", "IdentifyType")]
        public string IdentifyType { get; set; }

        [EntityPropertyExtension("AsDefault", "AsDefault")]
        public bool AsDefault { get; set; }
    }
}