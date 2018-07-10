using BasicFramework.Common;

namespace BasicFramework.Entity
{
    public class ApplicationConfig
    {
        [EntityPropertyExtension("ID", "ID")]
        public long ID { get; set; }

        [EntityPropertyExtension("Code", "Code")]
        public string Code { get; set; }

        [EntityPropertyExtension("Name", "Name")]
        public string Name { get; set; }

        [EntityPropertyExtension("IdentifyType", "IdentifyType")]
        public string IdentifyType { get; set; }
    }
}
