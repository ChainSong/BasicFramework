using System;
using BasicFramework.Common;

namespace BasicFramework.Entity
{
    public class Role
    {
        [EntityPropertyExtension("ID", "ID")]
        public long ID { get; set; }

        [EntityPropertyExtension("Name", "Name")]
        public string Name { get; set; }

        [EntityPropertyExtension("Description", "Description")]
        public string Description { get; set; }

        [EntityPropertyExtension("State", "State")]
        public bool? State { get; set; }

        [EntityPropertyExtension("CreateDate", "CreateDate")]
        public DateTime CreateDate { get; set; }
    }
}