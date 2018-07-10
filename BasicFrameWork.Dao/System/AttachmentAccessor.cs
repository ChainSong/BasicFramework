using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BasicFramework.Common;
using BasicFramework.Entity;

namespace BasicFramework.Dao
{
    public class AttachmentAccessor : BaseAccessor
    {
        public IEnumerable<Attachment> AddAttachments(IEnumerable<Attachment> attachments, bool IsCoverOld)
        {
            using (SqlConnection conn = new SqlConnection(BaseAccessor._dataBase.ConnectionString))
            {
                IList<Attachment> result = new List<Attachment>();
                SqlCommand cmd = new SqlCommand("Proc_AddOrUpdateAttachment", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Attachments", attachments == null ? null : attachments.Select(attachment => new AttachmentsToDb(attachment)));
                cmd.Parameters[0].SqlDbType = SqlDbType.Structured;
                cmd.Parameters.AddWithValue("@IsCoverOld", IsCoverOld);
                cmd.Parameters[1].SqlDbType = SqlDbType.Bit;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Attachment()
                        {
                            ID = reader.GetInt64(0),
                            GroupID = reader.GetString(1),
                            Url = reader.GetString(2),
                            ActualNameInServer = reader.GetString(3),
                            DisplayName = reader.GetString(4),
                            Extension = reader.GetString(5),
                            CreateDate = reader.GetDateTime(6),
                            CreateUserID = reader.GetInt64(7),
                            Creator = reader.GetString(8),
                            IsAudit = reader.GetBoolean(9)
                        });
                }

                return result;
            }
        }

        public Attachment DeleteAttachment(long id)
        {
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@ID", DbType.Int64, id, ParameterDirection.Input),
            };
            return this.ExecuteDataTable("Proc_DeleteAttachmentByID", dbParams).ConvertToEntity<Attachment>();
        }

        public Attachment GetAttachmentByID(long id)
        {
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@ID", DbType.Int64, id, ParameterDirection.Input),
            };
            return this.ExecuteDataTable("Proc_GetAttachmentByID", dbParams).ConvertToEntity<Attachment>();
        }

        public IEnumerable<Attachment> GetAttachmentsByGroupID(string groupID)
        {
            DbParam[] dbParams = new DbParam[]{
                new DbParam("@GroupID", DbType.String, groupID, ParameterDirection.Input),
            };
            return this.ExecuteDataTable("Proc_GetAttachmentsByGroupID", dbParams).ConvertToEntityCollection<Attachment>();
        }
    }
}