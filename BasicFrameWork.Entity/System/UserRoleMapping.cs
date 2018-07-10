using System;
using BasicFramework.Common;

namespace BasicFramework.Entity
{
    public class UserRoleMapping
    {
        [EntityPropertyExtension("ID", "ID")]
        public long ID { get; set; }

        [EntityPropertyExtension("UserID", "UserID")]
        public long UserID { get; set; }

        [EntityPropertyExtension("RoleID", "RoleID")]
        public long RoleID { get; set; }

        [EntityPropertyExtension("CreateDate", "CreateDate")]
        public DateTime CreateDate { get; set; }

        [EntityPropertyExtension("State", "State")]
        public bool State { get; set; }
    }
}
