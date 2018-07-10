using System.Data;
using Microsoft.SqlServer.Server;
using SqlTypes = global::System.Data.SqlTypes;

namespace BasicFramework.Entity
{
    public class AttachmentsToDb : SqlDataRecord
    {
        public AttachmentsToDb(Attachment attachment)
            : base(s_metadata)
        {
            SetSqlString(0, attachment.GroupID);
            SetSqlString(1, attachment.Url);
            SetSqlString(2, attachment.ActualNameInServer);
            SetSqlString(3, attachment.DisplayName);
            SetSqlString(4, attachment.Extension);
            SetSqlDateTime(5, attachment.CreateDate);
            SetSqlInt64(6, attachment.CreateUserID);
            SetSqlString(7, attachment.Creator);
            SetSqlBoolean(8, attachment.IsAudit ?? false);
            SetSqlString(9, attachment.Remark);
            SetSqlString(10, attachment.Str1);
            SetSqlString(11, attachment.Str2);
            SetSqlString(12, attachment.Str3);
            SetSqlString(13, attachment.Str4);
            SetSqlString(14, attachment.Str5);
            SetSqlDateTime(15, attachment.DateTime1 ?? SqlTypes.SqlDateTime.Null);
            SetSqlDateTime(16, attachment.DateTime2 ?? SqlTypes.SqlDateTime.Null);
            SetSqlBoolean(17, attachment.Bit1 ?? SqlTypes.SqlBoolean.Null);
            SetSqlInt64(18, attachment.Bigint1 ?? SqlTypes.SqlInt64.Null);
            SetSqlInt32(19, attachment.Int1 ?? SqlTypes.SqlInt32.Null);
            
        }

        private static readonly SqlMetaData[] s_metadata =
        {
            new SqlMetaData("GroupID", SqlDbType.NVarChar, 50),
            new SqlMetaData("Url", SqlDbType.NVarChar, 500),
            new SqlMetaData("ActualName", SqlDbType.NVarChar, 50),
            new SqlMetaData("DisplayName", SqlDbType.NVarChar, 50),
            new SqlMetaData("Extension", SqlDbType.NVarChar, 50),
            new SqlMetaData("CreateDate", SqlDbType.DateTime),
            new SqlMetaData("CreateUserID", SqlDbType.BigInt),
            new SqlMetaData("Creator", SqlDbType.NVarChar, 50),
            new SqlMetaData("IsAudit", SqlDbType.Bit),
            new SqlMetaData("Remark",SqlDbType.NVarChar,50),
            new SqlMetaData("Str1",SqlDbType.NVarChar,50),
            new SqlMetaData("Str2",SqlDbType.NVarChar,50),
            new SqlMetaData("Str3",SqlDbType.NVarChar,50),
            new SqlMetaData("Str4",SqlDbType.NVarChar,100),
            new SqlMetaData("Str5",SqlDbType.NVarChar,500),
            new SqlMetaData("DateTime1", SqlDbType.DateTime),
            new SqlMetaData("DateTime2", SqlDbType.DateTime),
            new SqlMetaData("Bit1", SqlDbType.Bit),
            new SqlMetaData("Bigint1", SqlDbType.BigInt),
            new SqlMetaData("Int1", SqlDbType.Int)
        };
    }
}