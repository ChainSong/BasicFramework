using System;
using BasicFramework.Common;

namespace BasicFramework.Entity
{
    [Serializable] 
    public class User
    {
        [EntityPropertyExtension("ID", "ID")]
        public long ID { get; set; }

        [EntityPropertyExtension("Name", "Name")]
        public string Name { get; set; }

        [EntityPropertyExtension("DisplayName", "DisplayName")]
        public string DisplayName { get; set; }

        [EntityPropertyExtension("Password", "Password")]
        public string Password { get; set; }

        [EntityPropertyExtension("State", "State")]
        public bool? State { get; set; }

        [EntityPropertyExtension("Sex", "Sex")]
        public char Sex { get; set; }

        [EntityPropertyExtension("Tel", "Tel")]
        public string Tel { get; set; }

        [EntityPropertyExtension("Mobile", "Mobile")]
        public string Mobile { get; set; }

        [EntityPropertyExtension("Email", "Email")]
        public string Email { get; set; }

        [EntityPropertyExtension("CreateDate", "CreateDate")]
        public DateTime CreateDate { get; set; }

        [EntityPropertyExtension("UserType", "UserType")]
        public int? UserType { get; set; }

        [EntityPropertyExtension("RoleID", "RoleID")]
        public long RoleID { get; set; }

    }
}