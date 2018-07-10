using BasicFramework.Common;

namespace BasicFramework.Entity
{
    public class Region
    {
        [EntityPropertyExtension("ID", "ID")]
        public long ID { get; set; }

        [EntityPropertyExtension("Name", "Name")]
        public string Name { get; set; }

        [EntityPropertyExtension("Code", "Code")]
        public string Code { get; set; }

        [EntityPropertyExtension("SupperID", "SupperID")]
        public long SupperID { get; set; }

        [EntityPropertyExtension("Grade", "Grade")]
        public int Grade { get; set; }

        [EntityPropertyExtension("IsParent", "IsParent")]
        public bool IsParent { get; set; }
    }
}